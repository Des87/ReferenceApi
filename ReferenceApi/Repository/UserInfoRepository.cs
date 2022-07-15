using ReferenceApi.Models;

namespace ReferenceApi
{
    public class UserInfoRepository
    {
        private readonly UserInfoDb userInfoDb;

        public UserInfoRepository()
        {
            this.userInfoDb = new UserInfoDb();
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
