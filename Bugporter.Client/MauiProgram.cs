using Bugporter.Client.Features.ReportBug;
using Bugporter.Client.Pages.ReportBug;
using Bugporter.Client.Pages.SignIn;
using Bugporter.Client.Pages.SignUp;

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

            return builder.Build();
        }
    }
}