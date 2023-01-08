using Refit;

namespace Bugporter.Client.Features.ReportBug.API
{
    public interface IReportBugApiCommand
    {
        [Post("/bugs")]
        Task<ReportBugResponse> Execute(ReportBugRequest bug);
    }
}
