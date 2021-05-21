using Confitec.Users.Domain.Application.Core;
using Confitec.Users.Domain.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Confitec.Users.Domain.Application.Configurations
{
    public class ResponseService : IResponseService
    {
        private const string NotificationsFile = "/notifications.json";
        private const string Iso88591 = "ISO-8859-1";

        public ResponseService(string contentRootPath)
        {
            var file = CreateNotificationsUrl(contentRootPath);

            if (string.IsNullOrEmpty(file)) return;

            var rootObject = JObject.Parse(file);

            var source = JsonConvert.DeserializeObject<NotificationCatalog>(rootObject.ToString());

            Repository = source.Notifications.Select(notification =>
            {
                return (notification.Key, Messages: notification.Values.ToDictionary(c => c.Culture, c => c.Value));
            }).ToDictionary(x => x.Key, x => x.Messages);
        }

        public Dictionary<string, Dictionary<string, string>> Repository { get; }

        private static string CreateNotificationsUrl(string contentPath)
        {
            var path = contentPath + NotificationsFile;

            return File.Exists(path) ? File.ReadAllText(path, Encoding.GetEncoding(Iso88591)) : string.Empty;
        }

        public Response GetBadResponse(string key, string culture)
        {
            var message = GetNotification(key, culture);
            
            var response = new Response();
            
            var notification = new Notification(message, NotificationType.Error);
            response.AddNotification(notification);

            return response;
        }

        public string GetNotification(string key, string culture)
        {
            Repository.TryGetValue(key, out var cultures);
            if (cultures != null)
            {
                cultures.TryGetValue(culture, out var notification);
                return notification;
            }
                
            return "";
        }

        public Response GetSuccessResponse(string key, string culture)
        {
            var message = GetNotification(key, culture);

            var response = new Response();

            var notification = new Notification(message, NotificationType.Success);
            response.AddNotification(notification);

            return response;
        }

        public Response GetSuccessResponse(object result = null)
        {
           return new Response { Result = result};
        }

        internal class NotificationCatalog
        {
            [JsonProperty("notifications")] internal Notification[] Notifications { get; set; }

            internal class Notification
            {
                [JsonProperty("key")] internal string Key { get; set; }
                [JsonProperty("values")] internal Message[] Values { get; set; }

                internal class Message
                {
                    [JsonProperty("culture")] internal string Culture { get; set; }

                    [JsonProperty("value")] internal string Value { get; set; }
                }
            }
        }
    }
}
