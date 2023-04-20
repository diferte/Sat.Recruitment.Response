namespace Sat.Recruitment.Helpers
{
    public class Enums
    {

        public class UserType
        {
            public static readonly string Normal = "Normal";
            public static readonly string SuperUser = "SuperUser";
            public static readonly string Premium = "Premium";
        }

        public class Messages
        {
            public static readonly string Error = "Error:";
            public static readonly string Executing = "Executing {Action} {Model}";
            public static readonly string Created = "User Created";
            public static readonly string CreatedOnFile = "User Created on File";
            public static readonly string Duplicated = "The user is duplicated";
            public static readonly string ModelNoValid = "API failure: Model is not valid";
            public static readonly string MoneyGif = "Validate money Gif {Action} {Model}";
        }
    }
}