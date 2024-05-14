





using System.Data.Common;

namespace chore_score_csharp.Repositories;


public class ChoresRepository
{
  private readonly IDbConnection _db;
  public ChoresRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Chore CreateChore(Chore choreData)
  {
    string sql = @"
INSERT INTO
chores(name, description, room, isCompleted, assignedTo)
VALUES(@Name, @Description, @Room, @IsCompleted, @AssignedTo);

SELECT * FROM chores WHERE id = LAST_INSERT_ID();";

    Chore chore = _db.Query<Chore>(sql, choreData).FirstOrDefault();

    return chore;



    //      string sql = @"
    // INSERT INTO 
    // cats(name, age, color, hasPolydactylity) 
    // VALUES(@Name, @Age, @Color, @HasPolydactylity);

    // SELECT * FROM cats WHERE id = LAST_INSERT_ID();";

    // Cat cat = _db.Query<Cat>(sql, catData).FirstOrDefault(); // return the first row found, or return null

    // return cat;
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