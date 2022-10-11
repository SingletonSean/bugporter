using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.API.Functions
{
    public class ReportBugRequest
    {
        public string Summary { get; set; }
        public string Description { get; set; }
    }
}
