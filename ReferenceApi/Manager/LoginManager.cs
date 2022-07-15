using ReferenceApi.Helper;

namespace ReferenceApi.Manager
{
    public class LoginManager : ILoginManager
    {
        private readonly IUnitOfWork unitOfWork;
        public LoginManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<string> UserLogin(string userName, string password)
        {
            try
            {
                var userInfo = unitOfWork.userInfoRepository.GetUser(userName);
                var result = SecurePasswordHasher.Verify(password, userInfo.Password);
                string token = "";
                if (result)
                {
                    token = await unitOfWork.tokenhelper.GenerateJSONWebToken(userInfo);
                }
                return token;
            }
            catch (Exception)
            {
                //TODO logging
                throw;
            }

        }
    }
}
