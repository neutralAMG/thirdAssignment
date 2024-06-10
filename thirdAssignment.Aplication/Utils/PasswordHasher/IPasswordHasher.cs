
namespace thirdAssignment.Aplication.Utils.PasswordHasher
{
    public interface IPasswordHasher
    {
        string hashPasword(string password);
        bool Verification(string passwordHash, string inputPassword);
    }
}
