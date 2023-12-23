using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfierObject
{
    public abstract record AgentForManipulationDto
    {
        [Required(ErrorMessage = "agent name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
        public string Name { get; init; }
        [Required(ErrorMessage = "agent PhoneNum is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the phone is 20 characters.")]
        public string PhoneNum { get; init; }
        [Required(ErrorMessage = "agent picture is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the picture is 50 characters.")]
        public string PictureUrl { get; init; }
    }
}
