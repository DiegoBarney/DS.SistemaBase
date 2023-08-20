using Microsoft.AspNetCore.Mvc;
using DS.Domain.ClientControll;

using System.Net;

namespace DS.ClientControllSystem.Core
{
    public abstract class ApiBase : ControllerBase
    {
        protected NotificationContext _notificationContext;

        protected JsonReturn ReturnJson(object retorno, HttpStatusCode status = HttpStatusCode.OK)
        {
            JsonReturn json = new JsonReturn();

            json.StatusCode = (int)status;
            json.Success = false;

            if (_notificationContext.HasNotifications)
            {
                json.Error = _notificationContext.Notifications;
                json.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                if (status == HttpStatusCode.OK)
                {
                    json.Data = retorno;
                    json.Success = true;
                }
                else
                {
                    json.Error = retorno;
                }
            }

            return json;
        }
    }
}
