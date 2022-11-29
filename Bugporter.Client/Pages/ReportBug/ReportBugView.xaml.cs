namespace Bugporter.Client.Pages.ReportBug;

public partial class ReportBugView : ContentPage
{
	public ReportBugView(object bindingContext)
	{
		InitializeComponent();

		BindingContext = bindingContext;
    }
}