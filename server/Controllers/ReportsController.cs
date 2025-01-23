namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
  public ReportsController(ReportsService reportsService, Auth0Provider auth0Provider)
  {
    _reportsService = reportsService;
    _auth0Provider = auth0Provider;
  }
  private readonly Auth0Provider _auth0Provider;
  private readonly ReportsService _reportsService;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Report>> CreateReport([FromBody] Report reportData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      reportData.CreatorId = userInfo.Id;
      Report report = _reportsService.CreateReport(reportData);
      return Ok(report);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
