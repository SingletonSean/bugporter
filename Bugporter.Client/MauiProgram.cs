using Bugporter.Client.Entities.Users;
using Bugporter.Client.Features.ReportBug;
using Bugporter.Client.Features.ReportBug.API;
using Bugporter.Client.Features.SignIn;
using Bugporter.Client.Features.SignUp;
using Bugporter.Client.Pages.ReportBug;
using Bugporter.Client.Pages.SignIn;
using Bugporter.Client.Pages.SignUp;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Microsoft.Extensions.Configuration;
using Refit;
using System.Reflection;
using System.Text.Json;

namespace Bugporter.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.AddAppSettings();

            builder.Services.AddSingleton<CurrentUserAuthHttpMessageHandler>();

            string bugporterApiBaseUrl = builder.Configuration.GetValue<string>("BUGPORTER_API_BASE_URL");
            builder.Services
                .AddRefitClient<IReportBugApiCommand>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(bugporterApiBaseUrl))
                .AddHttpMessageHandler<CurrentUserAuthHttpMessageHandler>();

            builder.Services.AddTransient<ReportBugViewModel>();
            builder.Services.AddTransient<ReportBugFormViewModel>();
            builder.Services.AddTransient<ReportBugView>(
                s => new ReportBugView(s.GetRequiredService<ReportBugViewModel>()));

            builder.Services.AddTransient<SignInFormViewModel>();
            builder.Services.AddTransient<SignInViewModel>();
            builder.Services.AddTransient<SignInView>(
                s => new SignInView(s.GetRequiredService<SignInViewModel>()));

            builder.Services.AddTransient<SignUpFormViewModel>();
            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddTransient<SignUpView>(
                s => new SignUpView(s.GetRequiredService<SignUpViewModel>()));

            string firebaseApiKey = builder.Configuration.GetValue<string>("FIREBASE_API_KEY");
            string firebaseAuthDomain = builder.Configuration.GetValue<string>("FIREBASE_AUTH_DOMAIN");
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = firebaseApiKey,
                AuthDomain = firebaseAuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));
            builder.Services.AddSingleton<CurrentUserStore>();

            return builder.Build();
        }

        private static void AddAppSettings(this MauiAppBuilder builder)
        {
            using Stream stream = Assembly
                .GetExecutingAssembly()
                .GetManifestResourceStream("Bugporter.Client.appsettings.json");

            if (stream != null)
            {
                IConfigurationRoot config = new ConfigurationBuilder()
                    .AddJsonStream(stream)
                    .Build();
                builder.Configuration.AddConfiguration(config);
            }
        }
    }
}