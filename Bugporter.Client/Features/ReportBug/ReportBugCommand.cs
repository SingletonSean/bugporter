using Bugporter.Client.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugporter.Client.Features.ReportBug
{
    public class ReportBugCommand : AsyncCommandBase
    {
        private readonly ReportBugFormViewModel _viewModel;

        public ReportBugCommand(ReportBugFormViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            
        }
    }
}
