using Moq;
using ReferenceApi;
using ReferenceApi.Exceptions;
using ReferenceApi.Helper;
using ReferenceApi.Managers;
using ReferenceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class RegistryManagerTest
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private Mock<IUserInfoRepository> userInfoRepositoryMock;
        private readonly RegistryManager registryManager;
        public RegistryManagerTest()
        {
            this.userInfoRepositoryMock = new();
            this.unitOfWorkMock = new();
            this.registryManager = new RegistryManager(unitOfWorkMock.Object);
        }


        [Fact]
        public async Task UserRegistryThrowExceptionIfParamsEmpty()
        {
            string password = "admin";
            var hash = SecurePasswordHasher.Hash(password);
            UserInfo userInfo = new UserInfo()
            {
                Id = Guid.NewGuid(),
                LoginName = "ad5min",
                Password = hash
            };
            unitOfWorkMock.Setup(x => x.userInfoRepository.GetUser(userInfo.LoginName)).Returns(userInfo);
            Assert.Throws<InvalidUserOrPassword>(() => registryManager.UserRegistry("", ""));
            Assert.Throws<AlreadyExistsException>(() => registryManager.UserRegistry(userInfo.LoginName, password));
        }
    }
}
