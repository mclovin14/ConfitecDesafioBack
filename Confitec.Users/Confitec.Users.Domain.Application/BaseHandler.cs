using Confitec.Users.Domain.Application.Configurations;
using Confitec.Users.Domain.Application.Core;
using System;
using System.Threading.Tasks;

namespace Confitec.Users.Domain.Application
{
    public class BaseHandler
    {
        protected readonly IResponseService _responseService;

        public BaseHandler(IResponseService responseService)
        {
            _responseService = responseService;
        }

        public bool IsNull(object obj)
        {
            return obj == null;
        }

        public async Task<Response> SafeExecuteAsync(Func<Task<Response>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw;
            }
        }
    }
}
