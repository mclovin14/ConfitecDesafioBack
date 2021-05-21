using Confitec.Users.Domain.Application.Core;
using System.Collections.Generic;

namespace Confitec.Users.Domain.Application.Configurations
{
    public interface IResponseService
    {
        Dictionary<string, Dictionary<string, string>> Repository { get; }
        string GetNotification(string key, string culture);
        Response GetSuccessResponse(string key, string culture);
        Response GetSuccessResponse(object result = null);
        Response GetBadResponse(string key, string culture);
    }
}
