using Bugporter.Client.Features.ReportBug.API;
using Bugporter.Client.Shared.Commands;
using Bugporter.Core.Features.ReportBug;
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
        private readonly IReportBugApiCommand _reportBugApiCommand;

        public ReportBugCommand(ReportBugFormViewModel viewModel, IReportBugApiCommand reportBugApiCommand)
        {
            _viewModel = viewModel;
            _reportBugApiCommand = reportBugApiCommand;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            ReportBugRequest request = new ReportBugRequest()
            {
                Summary = _viewModel.Summary,
                Description = _viewModel.Description,
            };

            try
            {
                ReportBugResponse response = await _reportBugApiCommand.Execute(request);

                await Application.Current.MainPage.DisplayAlert("Success", $"Successfully reported bug #{response.Id}!", "Ok");
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Failed to report bug.", "Ok");
            }
        }
    }
}
