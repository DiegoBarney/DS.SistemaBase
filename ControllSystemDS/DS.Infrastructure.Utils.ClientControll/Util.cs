using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DS.Infrastructure.Utils.ClientControll
{
    public class Util
    {
        public static T DeserializeJSonElement<T>(Object inputModel)
        {
            string json = inputModel.ToString();
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static String removeCaracteresEspeciais(String s)
        {
            if (s != null && !s.Equals(""))
                return s.Replace(".", "").Replace("-", "").Replace("(", "").Replace(")", "").Replace(" ", "");
            else
                return "";
        }
    }
}
