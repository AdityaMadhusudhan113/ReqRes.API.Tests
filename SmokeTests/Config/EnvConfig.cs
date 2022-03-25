

using Microsoft.Extensions.Configuration;

namespace SmokeTests.Config
{
    public class EnvConfig
    {
        
            private IConfigurationRoot config;
            public string BASE_URL { get; }

            public EnvConfig()
            {
                config = new ConfigurationBuilder().AddJsonFile("config.json",true).Build();
               BASE_URL = config.GetSection("BASE_URL").Value;
            }

        
    }
}
