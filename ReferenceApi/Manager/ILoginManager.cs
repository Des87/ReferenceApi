
namespace ReferenceApi.Manager
{
    public interface ILoginManager
    {
        Task<string> UserLogin(string userName, string password);
    }
}