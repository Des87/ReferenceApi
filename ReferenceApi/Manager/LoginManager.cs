using ReferenceApi.Helper;

namespace ReferenceApi.Manager
{
    public class LoginManager
    {
        private readonly UserInfoRepository userInfoRepository;
        private readonly Tokenhelper tokenhelper;
        public LoginManager()
        {
            userInfoRepository = new UserInfoRepository();
            tokenhelper = new Tokenhelper();
        }
        public async Task<string> UserLogin(string userName, string password)
        {
            try
            {
                var userInfo = userInfoRepository.GetUser(userName);
                var result = SecurePasswordHasher.Verify(password, userInfo.Password);
                string token = "";
                if (result)
                {
                    token = await tokenhelper.GenerateJSONWebToken(userInfo);
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
