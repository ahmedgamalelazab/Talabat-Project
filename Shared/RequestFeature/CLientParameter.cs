using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeature
{
    public class CLientParameter : RequestParameters
    {
        public CLientParameter()
        {
            OrderBy = "name";
        }
        public string? SearchTerm { get; set; }

    }
}
