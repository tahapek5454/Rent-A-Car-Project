using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; } // ne zaman sonlanacigini belirtecek
    }
}
