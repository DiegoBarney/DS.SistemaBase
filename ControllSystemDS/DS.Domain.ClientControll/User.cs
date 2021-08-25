using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DS.Domain.ClientControll
{
    public class User : EntityBase
    {
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}
