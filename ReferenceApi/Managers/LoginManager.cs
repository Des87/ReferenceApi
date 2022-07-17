using ReferenceApi.Exceptions;
using ReferenceApi.Helper;
using ReferenceApi.Models;

namespace ReferenceApi.Managers
{
    public class LoginManager : ILoginManager
    {
        private readonly IUnitOfWork unitOfWork;
        public LoginManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public string UserLogin(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidUserOrPassword("Invalid username or password");
            }
            else
            {
                var userInfo = unitOfWork.userInfoRepository.GetUser(userName);
                if (userInfo == null)
                {
                    throw new InvalidUserOrPassword("Invalid username or password");
                }
                else
                {
                        return GetToken(password, userInfo);
                }
            }
        }

        private string GetToken(string password, UserInfo userInfo )
        {
            var result = SecurePasswordHasher.Verify(password, userInfo.Password);
            if (result)
            {
                return unitOfWork.tokenhelper.GenerateJSONWebToken(userInfo);
            }
            throw new InvalidUserOrPassword("Invalid username or password");
        }
    }
}
