using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Securtiy.EncryptionHelper
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreteSecurityKey(string securityKey)
        {
            // apide olusturdugumuz anahatarı simetrik key yaptik
            //JWT nin ihtyiac duydugu yapilar
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));   
        }
    }
}
