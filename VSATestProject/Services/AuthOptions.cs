using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace VSATestProject.Services;

public class AuthOptions
{
    public const string Issuer = "BookShop"; // издатель токена

    public const string Audience = "Client"; // потребитель токена

    private const string Key = "ultrasecretkey_topsecret131111237"; // ключ для шифрования
    
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
}