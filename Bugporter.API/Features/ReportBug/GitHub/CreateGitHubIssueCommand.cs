using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.API.Features.ReportBug.GitHub
{
    public class CreateGitHubIssueCommand
    {
        private readonly GitHubClient _gitHubClient;
        private readonly GitHubRepositoryOptions _gitHubRepositoryOptions;
        private readonly ILogger<CreateGitHubIssueCommand> _logger;

        public CreateGitHubIssueCommand(
            GitHubClient gitHubClient, 
            IOptions<GitHubRepositoryOptions> gitHubRepositoryOptions, 
            ILogger<CreateGitHubIssueCommand> logger)
        {
            _gitHubClient = gitHubClient;
            _gitHubRepositoryOptions = gitHubRepositoryOptions.Value;
            _logger = logger;
        }

        public async Task<ReportedBug> Execute(NewBug newBug)
        {
            _logger.LogInformation("Creating GitHub issue");

            // Create GitHub issue
            NewIssue newIssue = new NewIssue(newBug.Summary)
            {
                Body = newBug.Description
            };
            Issue createdIssue = await _gitHubClient.Issue.Create(
                _gitHubRepositoryOptions.Owner, 
                _gitHubRepositoryOptions.Name, 
                newIssue);

            _logger.LogInformation("Successfully created GitHub issue {Number}", createdIssue.Number);

            return new ReportedBug(
                createdIssue.Number.ToString(),
                createdIssue.Title,
                createdIssue.Body);
        }
    }
}
