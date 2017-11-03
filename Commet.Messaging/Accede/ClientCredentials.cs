using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comet.SMS
{
    public class ClientCredentials
    {
        public static string ClientSecret { get; set; }
        public static string ClientId { get; set; }
        public static string GetSecret()
        {
            return ClientSecret;
        }
        public static string GetClientId()
        {
            return ClientId;
        }
    }
}
