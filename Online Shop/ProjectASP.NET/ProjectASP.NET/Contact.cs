using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectASP.NET
{
    [MetadataType(typeof(ContactMetaData))]
    public partial class Contact
    {

        public class ContactMetaData
        {
            [Required(ErrorMessage = "First Name Required")]
            public string Firstname { get; set; }
            [Required(ErrorMessage = "Last Name Required")]
            public string Lastname { get; set; }
            [Required(ErrorMessage = "Address Required")]
            public string Address { get; set; }
            [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Phone Number should contain only numbers")]
            public string Phone { get; set; }
            [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "eMail is not in proper format")]
            [Required(ErrorMessage = "Email Required")]
            public string Email { get; set; }
            [Required(ErrorMessage = "City Name Required")]
            public string City { get; set; }
        }
    }
}