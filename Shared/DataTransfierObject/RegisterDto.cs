using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfierObject
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName{ get; set; }
        [Required]
        [EmailAddress]
        public string Email{ get; set; }
        [Required]
        [Phone]
        [RegularExpression(@"^(002|\+2)?01[0125][0-9]{8}$")]
        public string PhoneNumber{ get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{10,}$", 
            ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 number, 1 non alphanumeric and at least 6 characters")]
        public string Password{ get; set; }
    }
}
