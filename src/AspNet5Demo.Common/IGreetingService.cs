using Microsoft.Framework.Configuration;

namespace AspNet5Demo.Common
{
    public interface IGreetingService
    {
        string GetGreeting();
    }

    public class GreetingService : IGreetingService
    {
        private readonly IConfiguration _config;

        public GreetingService(IConfiguration config)
        {
            _config = config;
        }

        public string GetGreeting()
        {
            return _config["greeting"];
        }
    }
}
