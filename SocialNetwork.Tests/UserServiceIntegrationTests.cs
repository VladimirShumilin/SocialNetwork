using Moq;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Tests
{
    internal class UserServiceIntegrationTests
    {
        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void AddFriendMustThrowUserNotFoundException()
        {
  
            var userService = new UserService();
            Assert.Throws<UserNotFoundException>(() => userService.AddFriend("test@test.com", 10));
        }

        [Test]
        public void AddFriendMustSuccsses()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(p => p.FindByEmail("test@test.com")).Returns(new UserEntity() { id=10 });

            var userService = new UserService(mock.Object);

            var userAuthenticationData = new UserAuthenticationData()
            {
                Email = "t@test.com"
            };

            Assert.DoesNotThrow(()=>userService.AddFriend("test@test.com",10));
        }

    }
}
