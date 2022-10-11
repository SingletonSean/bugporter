using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.API.Features.ReportBug.GitHub
{
    public class GitHubRepositoryOptions
    {
        public string Owner { get; set; }
        public string Name { get; set; }
    }
}
