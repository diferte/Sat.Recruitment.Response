using Sat.Recruitment.Helpers;
using Sat.Recruitment.Models;
using System;

namespace Sat.Recruitment.Business
{
    public class UserBO
    {
        public User ValidateMoneyGif(User newUser)
        {

            switch (newUser.UserType)
            {

                //If new user is normal and has more than USD100
                case var value when value == Enums.UserType.Normal:
                    if (newUser.Money > 100)
                        newUser.Money += newUser.Money * Convert.ToDecimal(0.12);
                    else if (newUser.Money > 10 && newUser.Money < 100)
                        newUser.Money += newUser.Money * Convert.ToDecimal(0.8);

                    break;

                //If new user is SuperUser and has more than USD100
                case var value when value == Enums.UserType.SuperUser:
                    if (newUser.Money > 100)
                        newUser.Money += newUser.Money * Convert.ToDecimal(0.20);

                    break;

                //If new user is Premium and has more than USD100
                case var value when value == Enums.UserType.Premium:
                    if (newUser.Money > 100)
                        newUser.Money += newUser.Money * 2;

                    break;

            }

            return newUser;
        }

     
    }
}