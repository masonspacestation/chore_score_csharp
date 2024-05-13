




namespace chore_score_csharp.Repositories;


public class ChoresRepository
{
  private readonly IDbConnection _db;
  public ChoresRepository(IDbConnection db)
  {
    _db = db;
  }

  internal void DestroyChoreById(int choreId)
  {
    string sql = "DELETE FROM chores WHERE id = @choreId;";
    _db.Execute(sql, new { choreId });
  }

  internal List<Chore> GetAllChores()
  {
    string sql = "SELECT * FROM chores;";
    List<Chore> chores = _db.Query<Chore>(sql).ToList();

    return chores;
  }

  internal Chore GetChoreById(object choreId)
  {
    string sql = "SELECT * FROM chores WHERE id = @choreId;";
    Chore chore = _db.Query<Chore>(sql, new { choreId }).FirstOrDefault();

    return chore;
  }
}