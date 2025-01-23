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

}
