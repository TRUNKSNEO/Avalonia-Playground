using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;
using Microsoft.Extensions.DependencyInjection;
using MyAvalonia.ViewModels;
using System;

namespace MyAvalonia.Views;

public partial class WeatherForecastPageView : UserControl
{
    public WeatherForecastPageView()
    {
        InitializeComponent();

        this.AttachedToVisualTree += OnAttached;
    }

    private void OnAttached(object? sender, VisualTreeAttachmentEventArgs e)
    {
        var vm = DataContext as WeatherForecastPageViewModel;

        if (vm != null)
        {
            vm.OwnerWindow = this.FindAncestorOfType<Window>();
        }
    }
}