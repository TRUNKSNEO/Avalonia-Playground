using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyAvalonia;

public partial class ErrorWindow : Window
{
	public ErrorWindow()
	{
		InitializeComponent();
	}

	private void Close_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
	{
		Close();
	}
}