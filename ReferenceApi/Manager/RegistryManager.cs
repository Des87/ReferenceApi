using ReferenceApi.Helper;

namespace ReferenceApi.Manager
{
    public class RegistryManager
    {
        private readonly UserInfoRepository userInfoRepository;
        public RegistryManager()
        {
            userInfoRepository = new UserInfoRepository();
        }

        public void UserRegistry(string userName, string password)
        {
            try
            {
                var hash = SecurePasswordHasher.Hash(password);
                userInfoRepository.AddNewUser(userName, hash);
            }
            catch (Exception)
            {
                //TODO logging
                throw;
            }
       
        }
    }
}
