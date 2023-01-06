using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        // Giris islemi gerceklestirdiginde iligli kullanıcın claimlerini bulup jwt ile donderecek
    }
}
