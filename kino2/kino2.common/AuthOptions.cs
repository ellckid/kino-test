using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace kino2.Common
{
    public class AuthOptions
    {
        public string Issuer { get; set; }  // тот кто сгенерировал токен
        public string Audience { get; set; } // назначение токена
        public string Secret { get; set; } // строка для генерации шифрования
        public int TokenLifeTime { get; set; } // время жизни токена

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}