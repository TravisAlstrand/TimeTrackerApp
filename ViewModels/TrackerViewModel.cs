using System.Collections.ObjectModel;
using ProjectTimeTracker.Models;
using ProjectTimeTracker.Services;

namespace ProjectTimeTracker.ViewModels;

public class TrackerViewModel
{
  private readonly SessionService _sessionService;
  private Session? _currentSession;

  public ObservableCollection<Session> Sessions { get; } = new();

  public TrackerViewModel(SessionService sessionService)
  {
    _sessionService = sessionService;
  }

  public async Task LoadSessionsAsync()
  {
    var sessions = await _sessionService.GetSessionsAsync();
    Sessions.Clear();
    foreach (var session in sessions)
    {
      Sessions.Add(session);
    }
  }

  public void StartSession(string projectName)
  {
    _currentSession = new Session
    {
      ProjectName = projectName,
      StartTime = DateTime.Now
    };
  }

  public async Task StopSessionAsync()
  {
    if (_currentSession != null)
    {
      _currentSession.EndTime = DateTime.Now;
      _currentSession.DurationMinutes = (_currentSession.EndTime - _currentSession.StartTime).TotalMinutes;
      await _sessionService.SaveSessionAsync(_currentSession);
      Sessions.Add(_currentSession);
      _currentSession = null;
    }
  }
}