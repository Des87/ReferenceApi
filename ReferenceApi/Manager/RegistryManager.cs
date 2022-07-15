using ReferenceApi.Helper;

namespace ReferenceApi.Manager
{
    public class RegistryManager : IRegistryManager
    {
        private readonly IUnitOfWork unitOfWork;
        public RegistryManager(IUnitOfWork unitOfWork)
        {
            unitOfWork = unitOfWork;
        }

        public void UserRegistry(string userName, string password)
        {
            try
            {
                var hash = SecurePasswordHasher.Hash(password);
                unitOfWork.userInfoRepository.AddNewUser(userName, hash);
            }
            catch (Exception)
            {
                //TODO logging
                throw;
            }

        }
    }
}
