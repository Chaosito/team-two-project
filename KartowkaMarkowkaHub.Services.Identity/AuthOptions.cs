using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartowkaMarkowkaHub.Services.Identity
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена

        public const string AUDIENCE = "MyAuthClient"; // потребитель токена

        const string KEY = "mysupersecret_secretsecretsecretkey!123";   // ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
