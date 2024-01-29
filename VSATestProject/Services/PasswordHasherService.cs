using System.Security.Cryptography;
using System.Text;

namespace VSATestProject.Services;

public class PasswordHasherService
{
    public string Md5HashPassword(string password)
    {
        var md5 = MD5.Create();
        var computedHash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
        var hash = Convert.ToBase64String(computedHash);
        return hash;
    }
}