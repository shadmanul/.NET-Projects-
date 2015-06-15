using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET
{
    [MetadataType(typeof(LoginMetaData))]
    public partial class LoginInfo
    {
        public class LoginMetaData
        {
            [Required(ErrorMessage = "Username Required")]
            public String Username { get; set; }
            [DataType(DataType.Password)]
            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Please enter a password of minimum 8 character,including an uppercase,lowercase and special character")]
            [Required(ErrorMessage = "Password Required")]
            public String Password { get; set; }
        }
    }
}