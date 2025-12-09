using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;

namespace StayHard.Application.Domains.Users.Models.Entities { }

public class User
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }

    public User() { }

    public User(string name, string email, string passwordHash)
    {
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
    }

    public static string ReturnHashedPassword(string password)
    {
        byte[] data = MD5.HashData(Encoding.UTF8.GetBytes(password));
        StringBuilder sBuilder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        return sBuilder.ToString();
    }

}