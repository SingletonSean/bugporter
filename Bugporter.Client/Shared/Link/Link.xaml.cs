namespace Bugporter.Client.Shared.Link;

public partial class Link : ContentView
{
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(Link), string.Empty);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static readonly BindableProperty RouteProperty =
        BindableProperty.Create(nameof(Route), typeof(string), typeof(Link), string.Empty);

    public string Route
    {
        get => (string)GetValue(RouteProperty);
        set => SetValue(RouteProperty, value);
    }

    public Link()
	{
		InitializeComponent();
	}

    private async void Link_Pressed(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(Route);
    }
}