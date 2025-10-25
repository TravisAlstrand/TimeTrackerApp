using SQLite;

using ProjectTimeTracker.Models;

namespace ProjectTimeTracker.Services;

public class SessionService
{
  private readonly SQLiteAsyncConnection _database;

  public SessionService(string dbPath)
  {
    _database = new SQLiteAsyncConnection(dbPath);
    _database.CreateTableAsync<Session>().Wait();
  }

  public Task<List<Session>> GetSessionsAsync()
  {
    return _database.Table<Session>().ToListAsync();
  }

  public Task<int> SaveSessionAsync(Session session)
  {
    if (session.Id != 0)
      return _database.UpdateAsync(session);
    else
      return _database.InsertAsync(session);
  }

  public Task<int> DeleteSessionAsync(Session session)
  {
    return _database.DeleteAsync(session);
  }
}