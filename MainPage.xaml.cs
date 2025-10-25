using System;
using System.Timers;
using Microsoft.Maui.Controls;

namespace ProjectTimeTracker
{
  public partial class MainPage : ContentPage
  {
    private DateTime _startTime;
    private System.Timers.Timer? _timer;
    private bool _isRunning = false;

    public MainPage()
    {
      InitializeComponent();
    }

    private void OnStartClicked(object sender, EventArgs e)
    {
      if (!_isRunning)
      {
        _startTime = DateTime.Now;
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += Timer_Elapsed;
        _timer.Start();

        _isRunning = true;
        StartButton.IsEnabled = false;
        StopButton.IsEnabled = true;
      }
    }

    private void OnStopClicked(object sender, EventArgs e)
    {
      if (_isRunning)
      {
        _timer?.Stop();
        _timer?.Dispose();
        _isRunning = false;

        StartButton.IsEnabled = true;
        StopButton.IsEnabled = false;
      }
    }

    private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
      TimeSpan elapsed = DateTime.Now - _startTime;

      // Update UI on main thread
      MainThread.BeginInvokeOnMainThread(() =>
      {
        TimerLabel.Text = elapsed.ToString(@"hh\:mm\:ss");
      });
    }
  }
}
