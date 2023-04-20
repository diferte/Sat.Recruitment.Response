# Sat.Recruitment Response

--- Changelog
- Install sdk version .net Core 3.1
- Change the launchUrl weatherforecast to CreateUser
- Renamed swagger definition "My API V1" to "Sat API V1" on startup.cs
- Modified startup.cs class by changing access to swagger and adding documentation
- Modify launchSettings.json file to run swagger at startup
- Added project Sat.Recruitment.Models
- Create model Result, User
- Added project Sat.Recruitment.Helpers
- Added Enum Class
- Removed ValidateErrors Method
- Email normalized with RegularExpression on model
- Added CsvToModel and removed UsersController2.cs
- Removed variable isDuplicated
- The "Duplicate user" validation is changed to a LinQ validation
