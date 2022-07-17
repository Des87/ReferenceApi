using Moq;
using ReferenceApi;
using ReferenceApi.Managers;
using ReferenceApi.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq.Expressions;
using ReferenceApi.Models;
using ReferenceApi.Helper;

namespace Test
{
    public class LoginManagerTest
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private Mock<IUserInfoRepository> userInfoRepositoryMock;
        private readonly ITokenhelper tokenHelper;
        private readonly LoginManager loginManager;
        public LoginManagerTest()
        {
            this.userInfoRepositoryMock = new();
            this.tokenHelper = new Tokenhelper();
            this.unitOfWorkMock = new();
            this.loginManager = new LoginManager(unitOfWorkMock.Object);
        }

        [Fact]
        public async Task UserLoginThrowExceptionIfParamsEmpty()
        {
            UserInfo userInfo = null;
            string name = "as4d";
            unitOfWorkMock.Setup(x => x.userInfoRepository.GetUser(name)).Returns(userInfo);
            Assert.Throws<InvalidUserOrPassword>(() => loginManager.UserLogin("",""));
            Assert.Throws<InvalidUserOrPassword>(() => loginManager.UserLogin(name, "asd"));
        }
        [Fact]
        public async Task UserLoginCreateToken()
        {
            string password = "admin";
            var hash = SecurePasswordHasher.Hash(password);
            UserInfo userInfo = new UserInfo()
            {
                Id = Guid.NewGuid(),
                LoginName = "admin",
                Password = hash
            };
            unitOfWorkMock.Setup(x => x.userInfoRepository.GetUser(userInfo.LoginName)).Returns(userInfo);
            unitOfWorkMock.Setup(x => x.tokenhelper).Returns(tokenHelper);
            var res = loginManager.UserLogin(userInfo.LoginName, password);
            Assert.NotNull(res);
            Assert.IsType<string>(res);
        }
    }
}
