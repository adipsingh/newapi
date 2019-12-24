using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttachMore.NetGen.Core.Security.Auth
{
    public class TokenAuthOption
    {
        public static string Audience { get; } = "ExpensesAudience";
        public static string Issuer { get; } = "ExpensesIssuer";
        //public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static byte[] newKey = Encoding.ASCII.GetBytes("45c5aadf9ee9459ebc51fe45a2f2e36c");
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(new SymmetricSecurityKey(newKey), SecurityAlgorithms.HmacSha256Signature);

        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromHours(30);
        public static string TokenType { get; } = "Bearer";
    }
}
