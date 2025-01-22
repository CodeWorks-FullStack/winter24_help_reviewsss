namespace help_reviews.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController : ControllerBase
{
  public RestaurantsController(RestaurantsService restaurantsService, Auth0Provider auth0Provider)
  {
    _restaurantsService = restaurantsService;
    _auth0Provider = auth0Provider;
  }
  private readonly RestaurantsService _restaurantsService;
  private readonly Auth0Provider _auth0Provider;

}
