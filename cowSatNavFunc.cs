using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CowSatNav.Function
{
    public static class cowSatNavFunc
    {
        [FunctionName("cowSatNavFunc")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string url = "http://api.open-notify.org/iss-now.json";
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var response = await httpClient.GetStringAsync(url);
                return new OkObjectResult(response);
            }
        }
    }
}
