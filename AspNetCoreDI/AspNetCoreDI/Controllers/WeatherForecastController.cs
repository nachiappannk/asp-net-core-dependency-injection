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
        private readonly InnerDependency innerDependency;

        public Dependency(InnerDependency innerDependency)
        {
            this.innerDependency = innerDependency;
        }

        public string GetOutput()
        {
            return this.GetHashCode().ToString() + " " + this.innerDependency.GetOutput();
        }
    }


    public class InnerDependency
    {
        private readonly ILogger<InnerDependency> logger;

        public InnerDependency(ILogger<InnerDependency> logger)
        {
            this.logger = logger;
        }

        public string GetOutput()
        {
            logger.LogInformation("Get Output method is called");
            return this.GetHashCode().ToString();
        }
    }
}
