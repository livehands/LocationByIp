using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace LocationByIP
{
    public static class LocationByIP
    {
        [FunctionName("LocationViaIP")]
        public static async Task<IActionResult> Run(
           [HttpTrigger(AuthorizationLevel.Function, "get", Route = "locationbyip")] HttpRequest req,
           ILogger log)
        {
            string IPServiceEndpoint = Environment.GetEnvironmentVariable("IPLocationUri"); //"https://geolocation-db.com/jsonp";

            HttpClient client = new HttpClient();

            string clientIP = req.HttpContext.Connection.RemoteIpAddress.ToString();

            if (IPServiceEndpoint.EndsWith('/'))
            {
                IPServiceEndpoint = IPServiceEndpoint + clientIP;
            }
            else
            {
                IPServiceEndpoint = $"{IPServiceEndpoint}/{clientIP}";
            }

            var data = await client.GetStringAsync(IPServiceEndpoint);

            return new OkObjectResult(data);
        }
    }
}
