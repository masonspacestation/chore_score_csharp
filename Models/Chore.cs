namespace chore_score_csharp.Models;

public class Chore
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Room { get; set; }
  public bool IsComplete { get; set; }
  public string AssignedTo { get; set; }
  public string Description { get; set; }
}