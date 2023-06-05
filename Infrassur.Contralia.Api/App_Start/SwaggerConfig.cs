using Infrassur.Contralia.Api.DataTransfertObjects.IndentitiesDto;
using Swashbuckle.Application;
using System.Web.Http;
using System.Xml.Serialization;

namespace Infrassur.Contralia.Api.App_Start
{
	public class SwaggerConfig
	{
		public static void Register()
		{
			var thisAssembly = typeof(SwaggerConfig).Assembly;
			GlobalConfiguration.Configuration.EnableSwagger(c =>
			{
				// Set the Swagger documentation endpoint(s)
				c.SingleApiVersion("v1", "Infrassur Contralia API V1");
				c.IncludeXmlComments(GetXmlCommentsPath()); // Optional: Include XML comments for additional documentation
			})
			.EnableSwaggerUi();
		}

		private static string GetXmlCommentsPath()
		{
			return System.String.Format(@"{0}\bin\YourApiName.XML", System.AppDomain.CurrentDomain.BaseDirectory);
		}
	}
}