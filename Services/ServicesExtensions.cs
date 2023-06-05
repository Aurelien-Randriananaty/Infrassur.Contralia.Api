using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Web;
using System.Threading.Tasks;
//using System.Net.Http.Formatting;
using System.Xml;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace Infrassur.Contralia.Api.Service
{
	public static class ServicesExtensions
	{
		private static readonly string URL = ConfigurationManager.AppSettings["API_CONTRALIA_URL"];
		private static readonly String PROXY_HOST = ConfigurationManager.AppSettings["CLIENT_PROXY_HOST"];
		private static readonly int PROXY_PORT = int.Parse(ConfigurationManager.AppSettings["CLIENT_PROXY_PORT"]);
		private static readonly String LOGIN = ConfigurationManager.AppSettings["API_CONTRALIA_LOGIN"];
		private static readonly String PASSWORD = ConfigurationManager.AppSettings["API_CONTRALIA_PASSWORD"];

		/// <summary>
		/// Calls a Contralia API and returns result as string
		/// </summary>
		/// <param name="apiPath">API URL</param>
		/// <param name="httpMethod">HTTP method to use</param>
		/// <param name="formData">Call parameters as multipart form data</param>
		/// <returns>HTTP request result as string</returns>
		public static async Task<T> GetResponseAsType<T>(String apiPath, HttpMethod httpMethod, MultipartFormDataContent formData, string requestReference)
		{
			String uri = URL + apiPath;

			HttpClientHandler handler = checkedProxy(PROXY_HOST, PROXY_PORT);

			T result = default;
			using (HttpClient client = new HttpClient(handler))
			{
				// Set login and password
				var credentials = Encoding.ASCII.GetBytes(LOGIN + ":" + PASSWORD);
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
				// Ajouter la référence client en tant qu'en-tête
				if (!string.IsNullOrEmpty(requestReference)) 
				{
					client.DefaultRequestHeaders.Add("requestReference", requestReference);
				}

				HttpResponseMessage response;

				// Check HTTP method to use
				if (httpMethod == HttpMethod.Post)
				{
					// Send POST request with parameters and retrieve result as string
					response = await client.PostAsync(new Uri(uri), formData);
				}
				else
				{
					// Send GET request and retrieve result as string
					response = await client.GetAsync(new Uri(uri));
				}
				if (!response.IsSuccessStatusCode)
				{
					string errorContent = await response.Content.ReadAsStringAsync();
					throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}\nError content: {errorContent}");
				}
				string htmlContent = await response.Content.ReadAsStringAsync();

				string jsonContent = ExtractJsonFromHtml(htmlContent);
				
				// Deserialize the extracted JSON content
				result = JsonConvert.DeserializeObject<T>(jsonContent);
				
			}

			return result;
		}

		/// <summary>
		/// Calls a Contralia API and returns result as file
		/// </summary>
		/// <param name="apiPath">API URL</param>
		/// <param name="httpMethod">HTTP method to use</param>
		/// <param name="formData">Call parameters as multipart form data</param>
		/// <param name="path">Output file path</param>
		public static void GetResponseAsFile(String apiPath, HttpMethod httpMethod, MultipartFormDataContent formData, String path)
		{
			String uri = URL + apiPath;

			HttpClientHandler handler = checkedProxy(PROXY_HOST, PROXY_PORT);

			Stream result = null;

			using (HttpClient client = new HttpClient(handler))
			{
				// Set login and password
				var credentials = Encoding.ASCII.GetBytes(LOGIN + ":" + PASSWORD);
				client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

				// Check HTTP method to use
				if (httpMethod == HttpMethod.Post)
				{
					// Send POST request with parameters and retrieve result stream
					result = client.PostAsync(new Uri(uri), formData).Result.Content.ReadAsStreamAsync().Result;
				}
				else
				{
					// Send GET request and retrieve result stream
					result = client.GetAsync(new Uri(uri)).Result.Content.ReadAsStreamAsync().Result;
				}
				// Copy response stream into specified file
				using (Stream fileStream = File.Open(path, FileMode.Append, FileAccess.Write))
				{
					result.CopyTo(fileStream);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="PROXY_HOST"></param>
		/// <param name="PROXY_PORT"></param>
		/// <returns></returns>
		private static HttpClientHandler checkedProxy(string PROXY_HOST, int PROXY_PORT)
		{
			// Init HTTP client with login and password
			HttpClientHandler handler = new HttpClientHandler();
			// Set proxy if any
			if (!String.IsNullOrWhiteSpace(PROXY_HOST))
			{
				handler.Proxy = new WebProxy(PROXY_HOST, PROXY_PORT);
				handler.UseProxy = true;
			}

			return handler;
		}

		private static string ExtractJsonFromHtml(string htmlContent)
		{
			HtmlDocument htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(htmlContent);

			// Find the HTML element that contains the JSON content
			// Adjust the XPath expression based on the structure of your HTML response
			HtmlNode jsonNode = htmlDoc.DocumentNode.SelectSingleNode("//script[@type='application/json']");

			if (jsonNode != null)
			{
				// Extract the JSON content from the HTML element
				string jsonContent = jsonNode.InnerText;
				return jsonContent;
			}

			// If the JSON content is not found, you can handle it accordingly (e.g., throw an exception, return null)

			return null;
		}


	}

}