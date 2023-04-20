using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Models;
using System;
using System.Security.Cryptography;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerTest
    {

        private UsersController usersController() {
            using var logFactory = LoggerFactory.Create(builder => builder.AddConsole());
            var logger = logFactory.CreateLogger<UsersController>();


            var configuration =
               new ConfigurationBuilder()
                   .AddJsonFile("testsettings.json")
                   .AddEnvironmentVariables().Build();

           return new UsersController(logger, configuration);
        }


        [Fact]
        public void ValidateWrongUserModel()
        {
            var controller = usersController();

            Random rnd = new Random();

            //Wrong email
            User user = new User()
            {
                Address = "",
                Email = "Agustina@gmail.com",
                Money = 80,
                Name = "",
                Phone = "+17888254187",
                UserType = "SuperUser"
            };

            var result = controller.Create(user);

            var badRequestResult = result as BadRequestObjectResult;

            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);

        }

        [Fact]
        public void GetUserCreated()
        {
            var controller = usersController();

            Random rnd = new Random();

            User user = new User()
            {
                Address = "Km 3" + rnd.Next(50),
                Email = "test" + +rnd.Next(50)  + "@gmail.com",
                Money = 30 + rnd.Next(50),
                Name = "Edward" + rnd.Next(50),
                Phone = "+17888254187" + rnd.Next(50),
                UserType = "SuperUser"
            };

            var result = controller.Create(user);

            var createdResult = result as CreatedResult;

            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);

        }

        [Fact]
        public void GetUserDuplicated()
        {
            var controller = usersController();

            User user = new User()
            {
                Address = "Km 3 via chiapaya",
                Email = "Agustina@gmail.com",
                Money = 80,
                Name = "Edward",
                Phone = "+17888254187",
                UserType = "SuperUser"
            };

            var result = controller.Create(user);

            var badRequestResult = result as BadRequestObjectResult;

            Assert.NotNull(badRequestResult);
            Assert.Equal(400, badRequestResult.StatusCode);
        }

        [Fact]
        public void ValidateMoneyGiftSuperUserMoreThan100()
        {
            var controller = usersController();

            Random rnd = new Random();

            User user = new User()
            {
                Address = "Km 3" + rnd.Next(50),
                Email = "test" + +rnd.Next(50) + "@gmail.com",
                Money = 150,
                Name = "Edward" + rnd.Next(50),
                Phone = "+17888254187" + rnd.Next(50),
                UserType = "SuperUser"
            };

            var result = controller.Create(user);

            var createdResult = result as CreatedResult;
            var newUser = createdResult.Value as User;

            Assert.NotNull(createdResult);
            Assert.Equal(180, newUser.Money);

        }

        [Fact]
        public void ValidateMoneyGiftSuperUserLessThan100()
        {
            var controller = usersController();

            Random rnd = new Random();

            User user = new User()
            {
                Address = "Km 3" + rnd.Next(50),
                Email = "test" + +rnd.Next(50) + "@gmail.com",
                Money = 80,
                Name = "Edward" + rnd.Next(50),
                Phone = "+17888254187" + rnd.Next(50),
                UserType = "SuperUser"
            };

            var result = controller.Create(user);

            var createdResult = result as CreatedResult;
            var newUser = createdResult.Value as User;

            Assert.NotNull(createdResult);
            Assert.Equal(80, newUser.Money);

        }


        [Fact]
        public void ValidateMoneyGiftNormalMoreThan100()
        {
            var controller = usersController();

            Random rnd = new Random();

            User user = new User()
            {
                Address = "Km 3" + rnd.Next(50),
                Email = "test" + +rnd.Next(50) + "@gmail.com",
                Money = 150,
                Name = "Edward" + rnd.Next(50),
                Phone = "+17888254187" + rnd.Next(50),
                UserType = "Normal"
            };

            var result = controller.Create(user);

            var createdResult = result as CreatedResult;
            var newUser = createdResult.Value as User;

            Assert.NotNull(createdResult);
            Assert.Equal(168, newUser.Money);

        }

        [Fact]
        public void ValidateMoneyGiftNormalLessThan100()
        {
            var controller = usersController();

            Random rnd = new Random();

            User user = new User()
            {
                Address = "Km 3" + rnd.Next(50),
                Email = "test" + +rnd.Next(50) + "@gmail.com",
                Money = 50,
                Name = "Edward" + rnd.Next(50),
                Phone = "+17888254187" + rnd.Next(50),
                UserType = "Normal"
            };

            var result = controller.Create(user);

            var createdResult = result as CreatedResult;
            var newUser = createdResult.Value as User;

            Assert.NotNull(createdResult);
            Assert.Equal(90, newUser.Money);

        }

        [Fact]
        public void ValidateMoneyGiftPremiumMoreThan100()
        {
            var controller = usersController();

            Random rnd = new Random();

            User user = new User()
            {
                Address = "Km 3" + rnd.Next(50),
                Email = "test" + +rnd.Next(50) + "@gmail.com",
                Money = 150,
                Name = "Edward" + rnd.Next(50),
                Phone = "+17888254187" + rnd.Next(50),
                UserType = "Premium"
            };

            var result = controller.Create(user);

            var createdResult = result as CreatedResult;
            var newUser = createdResult.Value as User;

            Assert.NotNull(createdResult);
            Assert.Equal(450, newUser.Money);

        }

    }
}
