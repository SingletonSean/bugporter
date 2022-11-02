using Bugporter.API.Features.ReportBug.GitHub;
using FirebaseAdmin;
using FirebaseAdminAuthentication.DependencyInjection.Extensions;
using Google.Apis.Auth.OAuth2;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(Bugporter.API.Startup))]

namespace Bugporter.API
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfiguration configuration = builder.GetContext().Configuration;

            string firebaseConfig = configuration.GetValue<string>("FIREBASE_CONFIG");
            FirebaseApp firebaseApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromJson(firebaseConfig)
            });
            builder.Services.AddSingleton(firebaseApp);
            builder.Services.AddFirebaseAuthentication();

            builder.Services.Configure<GitHubRepositoryOptions>(o =>
            {
                o.Owner = configuration.GetValue<string>("GITHUB_REPOSITORY_OWNER");
                o.Name = configuration.GetValue<string>("GITHUB_REPOSITORY_NAME");
            });

            string gitHubToken = configuration.GetValue<string>("GITHUB_TOKEN");

            builder.Services.AddSingleton(new GitHubClient(new ProductHeaderValue("bugporter-api"))
            {
                Credentials = new Credentials(gitHubToken)
            });

            builder.Services.AddSingleton<CreateGitHubIssueCommand>();
        }
    }
}
