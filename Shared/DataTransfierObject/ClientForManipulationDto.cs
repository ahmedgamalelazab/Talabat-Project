using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfierObject
{
    public abstract record ClientForManipulationDto
    {
        [Required(ErrorMessage = "Client name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Client description is a required field.")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Name is 150 characters.")]
        public string? Description { get; init; }
        [Required(ErrorMessage = "Client picture is a required field.")]
        [MaxLength(1000, ErrorMessage = "Maximum length for the Name is 1000 characters.")]
        public string? PhotoPath { get; set; }
        [Required(ErrorMessage = "Client Working_Hour is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Working_Hour is 30 characters.")]
        public string? StartWork{ get; init; }
        [Required(ErrorMessage = "Client Working_Hour is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Working_Hour is 30 characters.")]
        public string? EndWork { get; init; }
        [Required(ErrorMessage = "Client Number of branch is a required field.")]
        public int NoOfBranch { get; init; }
        [MaxLength(50, ErrorMessage = "Maximum length for the website is 50 characters.")]
        public string? Website { get; init; }
        [Required(ErrorMessage = "Client phone is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the phone number is 20 characters.")]
        public string? PhoneNum { get; init; }
        [Required(ErrorMessage = "Client Working_Hour is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Working_Hour is 30 characters.")]
        public string? TypeOfClient { get; init; }
        [Required(ErrorMessage = "Client avaraible is a required field.")]
        public bool Avaraiable { get; init; }
        
    }
}
