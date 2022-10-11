using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.API.Features.ReportBug.GitHub
{
    public class CreateGitHubIssueQuery
    {
        private readonly ILogger<CreateGitHubIssueQuery> _logger;

        public CreateGitHubIssueQuery(ILogger<CreateGitHubIssueQuery> logger)
        {
            _logger = logger;
        }

        public async Task<ReportedBug> Execute(NewBug newBug)
        {
            _logger.LogInformation("Creating GitHub issue");

            // Create GitHub issue
            ReportedBug reportedBug = new ReportedBug("1", "Very Bad Bug", "The div on the home page is not centered");

            _logger.LogInformation("Successfully created GitHub issue {Id}", reportedBug.Id);

            return reportedBug;
        }
    }
}
