using DS.Domain.ClientControll;
using System.Collections.Generic;

namespace IntegrationTest.DS.ClientControllSystem.Response
{
    public class ResponseGetUser : ResponseBase
    {
        public List<User> data { get; set; }
    }
}
