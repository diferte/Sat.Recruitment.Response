using CsvHelper.Configuration;
using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Helpers.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(p => p.Name).Index(0);
            Map(p => p.Email).Index(1);
            Map(p => p.Address).Index(2);
            Map(p => p.Phone).Index(3);
            Map(p => p.UserType).Index(4);
            Map(p => p.Money).Index(5);
        }
    }
}
