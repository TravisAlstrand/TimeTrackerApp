using SQLite;

namespace ProjectTimeTracker.Models;

[Table("Sessions")]
public class Session
{
  [PrimaryKey, AutoIncrement] public int Id { get; set; }
  public string ProjectName { get; set; } = String.Empty;
  public DateTime StartTime { get; set; }
  public DateTime EndTime { get; set; }
  public double DurationMinutes { get; set; }
}