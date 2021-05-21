using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Confitec.Users.Domain.Application.Core
{
    public class Response
    {
        private readonly IList<Notification> _notifications = new List<Notification>();

        public IEnumerable<Notification> Notifications { get; }
        public object Result { get; set; }

        public Response() => Notifications = new ReadOnlyCollection<Notification>(_notifications);

        public Response(object result) : this() => Result = result;

        public Response AddNotification(Notification notification)
        {
            _notifications.Add(notification);
            return this;
        }
    }
}