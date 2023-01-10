using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Features.ReportBug.API
{
    public interface IReportBugApiCommand
    {
        [Post("/bugs")]
        Task<ReportBugResponse> Execute([Body(buffered: true)] ReportBugRequest bug);
    }
}
