using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.API.Features.ReportBug
{
    public class NewBug
    {
        public string Summary { get; }
        public string Description { get; }

        public NewBug(string summary, string description)
        {
            Summary = summary;
            Description = description;
        }
    }
}
