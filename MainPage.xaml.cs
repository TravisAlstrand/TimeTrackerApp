using System;
using System.Timers;
using Microsoft.Maui.Controls;
using ProjectTimeTracker.Services;
using ProjectTimeTracker.ViewModels;

namespace ProjectTimeTracker
{
  public partial class MainPage : ContentPage
  {
    private readonly TrackerViewModel _viewModel;

    public MainPage(SessionService sessionService)
    {
      InitializeComponent();
      _viewModel = new TrackerViewModel(sessionService);
      BindingContext = _viewModel;
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
      _viewModel.StartSession(ProjectNameEntry.Text);
    }

    private async void StopButton_Clicked(object sender, EventArgs e)
    {
      await _viewModel.StopSessionAsync();
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();
      await _viewModel.LoadSessionsAsync();
    }
  }
}
