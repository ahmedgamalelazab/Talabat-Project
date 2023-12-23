using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Agent
    {
        public Guid AgentId { get; set; }
        [MaxLength(50)]
        [Required]
        [NotNull]
        [Column(TypeName = "varchar")]
        public string? Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        
        public string? PhoneNum { get; set; }
        [DataType(DataType.ImageUrl)]
        
        public string? PictureUrl{ get; set; }
    }
}
