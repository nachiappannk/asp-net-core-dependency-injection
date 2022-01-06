using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Dependency dependency;

        public WeatherForecastController(Dependency dependency)
        {
            this.dependency = dependency;
        }


        [HttpGet]
        public string Get()
        {
            return this.dependency.GetOutput();
        }
    }


    public class Dependency
    {
        public string GetOutput()
        {
            return this.GetHashCode().ToString();
        }
    }
}
