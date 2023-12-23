using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class ClientKPIData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int NumOfOrderPerWeek { get; set; }
        public int NumOfOrderPerMonth { get; set; }
        public decimal TotalMoneyPerWeek { get; set; }
        public decimal TotalMoneyPerMonth { get; set; }
        public decimal Bonus{ get; set; }
        public decimal deduct { get; set; }
    }
}
