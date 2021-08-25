using System;
using System.Collections.Generic;
using System.Text;

namespace DS.Domain.ClientControll
{
    public class Notification
    {
        public string errorMessage { get; }

        public Notification(string message)
        {
            errorMessage = message;
        }
    }
}
