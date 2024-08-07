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
        public const string ISSUER = "KartowkaMarkowkaHub"; // издатель токена

        public const string AUDIENCE = "KartowkaMarkowkaHub.Web"; // потребитель токена

        const string KEY = "mysecretsdasdasdasdkeyasdasdasdasdasda";   // ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
