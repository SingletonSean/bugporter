using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Bugporter.API.Features.ReportBug.GitHub;
using Bugporter.API.Features.ReportBug;
using Bugporter.API.Functions;

namespace Bugporter.API
{
    public class ReportBugFunction
    {
        private readonly CreateGitHubIssueQuery _createGitHubIssueQuery;
        private readonly ILogger<ReportBugFunction> _logger;

        public ReportBugFunction(CreateGitHubIssueQuery createGitHubIssueQuery, ILogger<ReportBugFunction> logger)
        {
            _createGitHubIssueQuery = createGitHubIssueQuery;
            _logger = logger;
        }

        [FunctionName("ReportBugFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bugs")] ReportBugRequest request)
        {
            NewBug newBug = new NewBug(request.Summary, request.Description);

            ReportedBug reportedBug = await _createGitHubIssueQuery.Execute(newBug);

            return new OkObjectResult(new ReportBugResponse()
            {
                Id = reportedBug.Id,
                Summary = reportedBug.Summary,
                Description = reportedBug.Description,
            });
        }
    }
}
