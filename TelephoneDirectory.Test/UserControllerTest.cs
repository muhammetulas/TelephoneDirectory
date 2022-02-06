using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using TelephoneDirectory.Controllers;
using TelephoneDirectory.Data.Entities;
using TelephoneDirectory.Data.Entities.ApiRequest;
using TelephoneDirectory.Data.Entities.ApiResponse;
using TelephoneDirectory.Services.Interfaces;
using Xunit;

namespace TelephoneDirectory.Test
{
    public class UserControllerTest
    {
        readonly Mock<IUserService> mockUserService;

        public UserControllerTest()
        {
            mockUserService = new Mock<IUserService>();
        }

        [Fact]
        public void WhenCreateUserShouldReturnHttpOk()
        {
            mockUserService.Setup(x => x.Create(It.IsAny<CreateUserRequest>()));

            var userController = new UserController(mockUserService.Object);

            var userInformations = new List<UserInformationRequest>();
            userInformations.Add(new UserInformationRequest
            {
                InformationContent = "Test",
                UserInformationType = Data.Helpers.Enums.UserInformationTypes.Location
            });

            var response = userController.CreateUser(new CreateUserRequest
            {
                FirmName = "Test",
                Name = "Test",
                SurName = "Test",
                UserInformations = userInformations
            });

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void WhenDeleteUserShouldReturnHttpOk()
        {
            mockUserService.Setup(x => x.Delete(It.IsAny<int>()));

            var userController = new UserController(mockUserService.Object);

            var response = userController.DeleteUser(1);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void WhenAddInformationToUserShouldReturnHttpOk()
        {
            mockUserService.Setup(x => x.AddUserInfrmation(It.IsAny<UserInformationRequest>()));

            var userController = new UserController(mockUserService.Object);

            var response = userController.AddInformationToUser(new UserInformationRequest
            {
                InformationContent = "Test",
                UserId = 1,
                UserInformationType = Data.Helpers.Enums.UserInformationTypes.PhoneNumber
            });

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void WhenDeleteInformationToUserShouldReturnHttpOk()
        {
            mockUserService.Setup(x => x.DeleteUserInfrmation(It.IsAny<int>(), It.IsAny<int>()));

            var userController = new UserController(mockUserService.Object);

            var response = userController.DeleteInformationToUser(1, 1);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void WhenGetUsersShouldNotNull()
        {
            var userResponse = new List<User>();
            userResponse.Add(new User
            {
                FirmName = "Test",
                Name = "Test",
                SurName = "Test",
                Uuid = 1
            });

            mockUserService.Setup(x => x.GetUsers()).Returns(userResponse);

            var userController = new UserController(mockUserService.Object);

            var response = userController.GetUsers();

            Assert.NotNull(response);
        }

        [Fact]
        public void WhenGetUserAndDetailShouldNotNull()
        {
            var userDetail = new UserResponse
            {
                FirmName = "Test",
                Name = "Test",
                SurName = "Test"
            };

            mockUserService.Setup(x => x.GetUserById(It.IsAny<int>())).Returns(userDetail);

            var userController = new UserController(mockUserService.Object);

            var response = userController.GetUserAndDetail(1);

            Assert.NotNull(response);
        }
    }
}