using Bugporter.Client.Shared.Commands;

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
