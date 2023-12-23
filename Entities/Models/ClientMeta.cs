using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Models
{
    public class Client : BaseEntity
    {
        public string? Name{ get; set; }
        public string? Description{ get; set; }
        public string PictureUrl { get; set; }
        public string StartWork { get; set; }
        public string EndWork { get; set; }
        public int NoOfBranch{ get; set; }
        public string? Website{ get; set; }
        public string? PhoneNum { get; set; }
        public decimal MinOrder { get; set; }
        public Avaraible Avaraible { get; set; }
        public int ClientTypeId { get; set; }
        public ClientType? ClientType { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
