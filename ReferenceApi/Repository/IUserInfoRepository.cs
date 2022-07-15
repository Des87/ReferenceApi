using ReferenceApi.Models;

namespace ReferenceApi
{
    public interface IUserInfoRepository
    {
        void AddNewUser(string userName, string password);
        UserInfo GetUser(string username);
    }
}