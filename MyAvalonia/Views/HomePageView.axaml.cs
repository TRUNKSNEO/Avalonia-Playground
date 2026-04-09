using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Threading.Tasks;

namespace MyAvalonia.Views;

public partial class HomePageView : UserControl
{

	public HomePageView()
	{
		InitializeComponent();
	}

	private async Task SmoothScroll(double delta)
	{
		double start = ForecastScroll.Offset.X;
		double target = start + delta;

		for (int i = 0; i < 4; i++)
		{
			double step = start + (target - start) * (i / 4.0);
			ForecastScroll.Offset = new Vector(step, ForecastScroll.Offset.Y);
			await Task.Delay(1);
		}
	}


	private async void ScrollLeft(object? sender, RoutedEventArgs e)
	{
		await SmoothScroll(-200);
	}

	private async void ScrollRight(object? sender, RoutedEventArgs e)
	{
		await SmoothScroll(200);
	}

}