

namespace chore_score_csharp.Controllers;


[ApiController]
[Route("api/chores")]


public class ChoresController : ControllerBase
{


  private readonly ChoresService _choresService;

  public ChoresController(ChoresService choresService)
  {
    _choresService = choresService;
  }



  [HttpGet]
  public ActionResult<List<Chore>> GetAllChores()
  {
    try
    {
      List<Chore> chores = _choresService.GetAllChores();
      return Ok(chores);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }


  [HttpGet("{choreId}")]
  public ActionResult<Chore> GetChoreById(int choreId)
  {
    try
    {
      Chore chore = _choresService.GetChoreById(choreId);
      return Ok(chore);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }


  [HttpDelete("{choreId}")]
  public ActionResult<string> DestroyChoreById(int choreId)
  {
    try
    {
      string message = _choresService.DestroyChoreById(choreId);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }




}