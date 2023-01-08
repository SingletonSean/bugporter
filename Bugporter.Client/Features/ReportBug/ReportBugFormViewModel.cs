using Bugporter.Client.Features.ReportBug.API;
using Bugporter.Client.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bugporter.Client.Features.ReportBug
{
    public class ReportBugFormViewModel : ViewModelBase
    {
		private string _summary;
		public string Summary
		{
			get
			{
				return _summary;
			}
			set
			{
				_summary = value;
				OnPropertyChanged(nameof(Summary));
			}
		}

		private string _description;
		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
				OnPropertyChanged(nameof(Description));
			}
		}

        public ICommand ReportBugCommand { get; }

		public ReportBugFormViewModel(IReportBugApiCommand reportBugApiCommand)
		{
			ReportBugCommand = new ReportBugCommand(this, reportBugApiCommand);
		}
    }
}
