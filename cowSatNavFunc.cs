using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace CowSatNav.Function
{
    public static class cowSatNavFunc
    {
        [FunctionName("cowSatNavFunc")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string responseMessage = "This HTTP triggered function executed successfully. Pass a name in the query string for a personalized response.";
            string url = "http://api.open-notify.org/iss-now.json";
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var response = await httpClient.GetStringAsync(url);
                return new OkObjectResult(response);
                responseMessage = response;
            }
            return new OkObjectResult(responseMessage);
        }
    }
}
