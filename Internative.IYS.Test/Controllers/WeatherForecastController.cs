using Internative.IYS.Core.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internative.IYS.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [Route("/test")]
        public async Task<IActionResult> Test()
        {
            var getTokenResponse = await IysApiClient.GetTokenRequest(new Core.Models.Request.IysTokenRequest
            {
                username = "your-user-name",
                password = "your-password",
                grant_type = "password"
            }, "https://api.iys.org.tr/");

            return Ok(getTokenResponse);
        }
    }
}
