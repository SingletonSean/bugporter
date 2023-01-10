using Bugporter.Core.Features.ReportBug;
using Refit;

namespace Bugporter.Client.Features.ReportBug.API
{
    public interface IReportBugApiCommand
    {
        [Post("/bugs")]
        Task<ReportBugResponse> Execute([Body(buffered: true)] ReportBugRequest bug);
    }
}
