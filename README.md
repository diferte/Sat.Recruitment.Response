# Sat.Recruitment Response

--- Changelog
- Change the launchUrl weatherforecast to CreateUser
- Renamed swagger definition "My API V1" to "Sat API V1" on startup.cs
- Modified startup.cs class by changing access to swagger and adding documentation
- Modify launchSettings.json file to run swagger at startup
- Added project Sat.Recruitment.Models
- Create model User with data anotations
- Added project Sat.Recruitment.Helpers
- Added Enum Class
- Removed ValidateErrors Method
- Email normalized with RegularExpression on model
- Added CsvToModel and removed UsersController2.cs
- Removed variable isDuplicated
- The "Duplicate user" validation is changed to a LinQ validation
- Added project Sat.Recruitment.Business
- Remove Result class
- Modify test1.cs to UsersControllerTest.cs
- Added ValidateWrongUserModel, GetUserCreated, GetUserDuplicated, ValidateMoneyGiftSuperUserMoreThan100, ValidateMoneyGiftSuperUserLessThan100, ValidateMoneyGiftNormalMoreThan100, ValidateMoneyGiftNormalLessThan100, ValidateMoneyGiftPremiumMoreThan100 to unit test project


--- Dependencys
- Install sdk version .net Core 3.1
