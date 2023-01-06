using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.GuidHelperr
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            //burada yüklediğimiz dosyamız için eşsiz bir isim oluşturduk.
            return Guid.NewGuid().ToString();
            //Guid.NewGuid()=> bu metot bize eşsiz bir değer oluşturdu.                                  
        }
    }
}
