using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Models;
using Sat.Recruitment.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Helpers.Maps;
using System.IO;
using System.Linq;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using Sat.Recruitment.Business;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IConfiguration _configuration;

        public UsersController(ILogger<UsersController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(User newUser)
        {
            _logger.LogDebug(Enums.Messages.Executing, nameof(Create), newUser);

            //Validate model
            if (!ModelState.IsValid)
            {
                _logger.LogWarning(Enums.Messages.ModelNoValid);
                return BadRequest(ModelState);
            }

            try
            {
                //Validate money gif
                newUser = new UserBO().ValidateMoneyGif(newUser);
                _logger.LogDebug(Enums.Messages.MoneyGif, nameof(Create), newUser);

                //Get user list
                FileToModel CsvToModel = new FileToModel();
                var listUsersFromFile = FileToModel.TransformFile<User, UserMap>(Directory.GetCurrentDirectory() + _configuration.GetSection("UserFilePath").Value);

                //Validate new user
                if (listUsersFromFile.Where(u => u.Email == newUser.Email || u.Phone == newUser.Phone || u.Name == newUser.Name || u.Address == newUser.Address).Any())
                {
                    _logger.LogWarning(Enums.Messages.Duplicated);
                    return BadRequest(Enums.Messages.Duplicated);
                }
                else
                {
                    //Create new user
                    new ModelToFile().TransformFile(Directory.GetCurrentDirectory() + _configuration.GetSection("UserFilePath").Value, newUser);
                    _logger.LogWarning(Enums.Messages.CreatedOnFile);
                }

                return Created(Enums.Messages.Created,newUser);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(Enums.Messages.Error + ex.Message);
                return BadRequest(Enums.Messages.Error + ex.Message);
            }
           
        }

    }
    
}
