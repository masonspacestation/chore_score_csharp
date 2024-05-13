


namespace chore_score_csharp.Services;


public class ChoresService
{
  private readonly ChoresRepository _repository;

  public ChoresService(ChoresRepository repository)
  {
    _repository = repository;
  }

  internal string DestroyChoreById(int choreId)
  {
    Chore choreToDestroy = GetChoreById(choreId);
    _repository.DestroyChoreById(choreId);

    return $"{choreToDestroy.Name} has been taken off of the list";

  }

  internal List<Chore> GetAllChores()
  {
    List<Chore> chores = _repository.GetAllChores();
    return chores;
  }

  internal Chore GetChoreById(object choreId)
  {
    Chore chore = _repository.GetChoreById(choreId);

    if (chore == null)
    {
      throw new Exception($"Chore {choreId} does not exist");
    }
    return chore;
  }
}