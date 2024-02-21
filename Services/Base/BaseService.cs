using Microsoft.Extensions.Logging;

namespace TestAPI.Services.Base
{
    public class BaseService
    {
        public readonly ILogger _logger;
        
        public BaseService (ILogger logger)
        {
            _logger = logger;
        }
    }
}
