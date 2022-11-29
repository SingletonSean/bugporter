using Bugporter.Client.Pages.ReportBug;

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
            builder.Services.AddTransient<ReportBugView>(
                s => new ReportBugView(s.GetRequiredService<ReportBugViewModel>()));

            return builder.Build();
        }
    }
}