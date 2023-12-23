using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransfierObject
{
    public class ClientDto:BaseEntity
    {
        public string Name { get; set; } 
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string StartWork { get; set; }
        public string EndWork { get; set; }
        public int NoOfBranch { get; set; }
        public string Website { get; set; }
        public string PhoneNum { get; set; }
        public decimal MinOrder { get; set; }
        public string Avaraible { get; set; }
        public int ClientTypeId { get; set; }
        public string ClientType { get; set; }
    }
}
