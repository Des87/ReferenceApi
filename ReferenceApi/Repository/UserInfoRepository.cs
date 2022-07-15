using ReferenceApi.Models;

namespace ReferenceApi
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly UserInfoDb userInfoDb;

        public UserInfoRepository(UserInfoDb userInfoDb)
        {
            this.userInfoDb = userInfoDb;
        }
        public void AddNewUser(string userName, string password)
        {
            userInfoDb.UserInfo.Add(new UserInfo() { Id = Guid.NewGuid(), LoginName = userName, Password = password });
            userInfoDb.SaveChanges();
        }
        public UserInfo GetUser(string username)
        {
            return userInfoDb.UserInfo.FirstOrDefault(x => x.LoginName == username);
        }
    }
}
