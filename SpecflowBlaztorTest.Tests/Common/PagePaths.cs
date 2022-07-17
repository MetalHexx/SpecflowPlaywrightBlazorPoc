using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowBlaztorTest.Tests.Common
{
    //TODO: Move the base URL somewhere else that is configurable per env
    public static class PagePaths
    {
        public const string Home = "https://localhost:7264/";
        public const string Counter = "https://localhost:7264/counter";
        public const string WeatherForecast = "https://localhost:7264/fetchdata";
    }
}
