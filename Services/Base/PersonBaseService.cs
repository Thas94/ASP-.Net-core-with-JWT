using TestAPI.Entities.Clinical;

namespace TestAPI.Services.Base
{
    public class PersonBaseService : BaseService
    {
        public readonly persondetails_dataContext _DataContext;

        public PersonBaseService(ILogger logger, persondetails_dataContext context) : base(logger)
        {
            _DataContext = context;
        }
    }
}
