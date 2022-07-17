using ReferenceApi.Exceptions;
using ReferenceApi.Helper;
using System.Runtime.Serialization;

namespace ReferenceApi.Managers
{
    public class RegistryManager : IRegistryManager
    {
        private readonly IUnitOfWork unitOfWork;
        public RegistryManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void UserRegistry(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidUserOrPassword("Invalid username or password");
            }
            else
            {
                if (unitOfWork.userInfoRepository.GetUser(userName) == null)
                {
                    var hash = SecurePasswordHasher.Hash(password);
                    unitOfWork.userInfoRepository.AddNewUser(userName, hash);
                }
                else
                {
                    throw new AlreadyExistsException("The user name you have chosen already exists");
                }
            }
        }
    }
}
