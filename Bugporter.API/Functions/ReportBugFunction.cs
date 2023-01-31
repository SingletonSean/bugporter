using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Bugporter.API.Features.ReportBug.GitHub;
using Bugporter.API.Features.ReportBug;
using FirebaseAdminAuthentication.DependencyInjection.Services;
using Bugporter.Core.Features.ReportBug;
using Microsoft.AspNetCore.Authentication;
using FirebaseAdminAuthentication.DependencyInjection.Models;

namespace Bugporter.API
{
    public class ReportBugFunction
    {
        private readonly CreateGitHubIssueCommand _createGitHubIssueCommand;
        private readonly FirebaseAuthenticationFunctionHandler _authenticationHandler;
        private readonly ILogger<ReportBugFunction> _logger;

        public ReportBugFunction(
            CreateGitHubIssueCommand createGitHubIssueCommand,
            FirebaseAuthenticationFunctionHandler authenticationHandler, 
            ILogger<ReportBugFunction> logger)
        {
            _createGitHubIssueCommand = createGitHubIssueCommand;
            _authenticationHandler = authenticationHandler;
            _logger = logger;
        }

        [FunctionName("ReportBugFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "bugs")] ReportBugRequest request,
            HttpRequest httpRequest)
        {
            AuthenticateResult authenticationResult = await _authenticationHandler.HandleAuthenticateAsync(httpRequest);

            if (!authenticationResult.Succeeded)
            {
                return new UnauthorizedResult();
            }

            string userId = authenticationResult.Principal.FindFirst(FirebaseUserClaimType.ID).Value;
            _logger.LogInformation("Authenticated user {UserId}", userId);

            NewBug newBug = new NewBug(request.Summary, request.Description);

            ReportedBug reportedBug = await _createGitHubIssueCommand.Execute(newBug);

            return new OkObjectResult(new ReportBugResponse()
            {
                Id = reportedBug.Id,
                Summary = reportedBug.Summary,
                Description = reportedBug.Description,
            });
        }
    }
}
