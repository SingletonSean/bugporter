using Bugporter.Client.Features.ReportBug;
using Bugporter.Client.Features.ReportBug.API;
using Bugporter.Client.Pages.ReportBug;
using Bugporter.Client.Pages.SignIn;
using Bugporter.Client.Pages.SignUp;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Refit;
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
            builder.Services
                .AddRefitClient<IReportBugApiCommand>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://localhost:7071/api"));
            builder.Services.AddTransient<ReportBugViewModel>();
            builder.Services.AddTransient<ReportBugFormViewModel>();
            builder.Services.AddTransient<ReportBugView>(
                s => new ReportBugView(s.GetRequiredService<ReportBugViewModel>()));

            builder.Services.AddTransient<SignInViewModel>();
            builder.Services.AddTransient<SignInView>(
                s => new SignInView(s.GetRequiredService<SignInViewModel>()));

            builder.Services.AddTransient<SignUpViewModel>();
            builder.Services.AddTransient<SignUpView>(
                s => new SignUpView(s.GetRequiredService<SignUpViewModel>()));

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyCU9W14p8vLLdlLikODcGw-xQl4h6csHPo",
                AuthDomain = "bugporter-739c9.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));

            return builder.Build();
        }
    }
}