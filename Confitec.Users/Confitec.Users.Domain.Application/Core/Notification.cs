using Confitec.Users.Domain.Core.Enums;

namespace Confitec.Users.Domain.Application.Core
{
    public class Notification
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }

        public Notification(string message, NotificationType type)
        {
            Message = message;
            Type = type;
        }
    }
}
