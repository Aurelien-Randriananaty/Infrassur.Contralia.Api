using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Infrassur.Contralia.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services de l'API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

			// configure json formatter			

			config.Formatters.Remove(config.Formatters.XmlFormatter);
			config.Formatters.Add(new BrowserJsonFormatter());

			config.Routes.MapHttpRoute(
				name: "Swagger",
				routeTemplate: "swagger/{*assetPath}",
				defaults: null,
				constraints: null,
				handler: new RedirectHandler((message => message.RequestUri.GetLeftPart(UriPartial.Authority)), "swagger/ui/index")
			);
		}
	}
	public class BrowserJsonFormatter : JsonMediaTypeFormatter
	{
		public BrowserJsonFormatter()
		{
			this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
			this.SerializerSettings.Formatting = Formatting.Indented;
		}

		public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
		{
			base.SetDefaultContentHeaders(type, headers, mediaType);
			headers.ContentType = new MediaTypeHeaderValue("application/json");
		}
	}
}
