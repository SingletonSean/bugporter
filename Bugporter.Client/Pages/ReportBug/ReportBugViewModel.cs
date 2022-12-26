using Bugporter.Client.Features.ReportBug;
using Bugporter.Client.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Pages.ReportBug
{
    public class ReportBugViewModel : ViewModelBase
    {
        public ReportBugFormViewModel ReportBugFormViewModel { get; }

        public ReportBugViewModel(ReportBugFormViewModel reportBugFormViewModel)
        {
            ReportBugFormViewModel = reportBugFormViewModel;
        }
    }
}
