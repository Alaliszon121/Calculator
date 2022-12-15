namespace Calculator;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(View.CalculatorPage), typeof(View.CalculatorPage));
    }
}
