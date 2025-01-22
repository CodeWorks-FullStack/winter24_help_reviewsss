using help_reviews.Interfaces;

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

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Restaurant>> CreateRestaurant([FromBody] Restaurant restaurantData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      restaurantData.CreatorId = userInfo.Id;
      Restaurant restaurant = _restaurantsService.CreateRestaurant(restaurantData);
      return Ok(restaurant);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // NOTE not an authorized route
  [HttpGet]
  public async Task<ActionResult<List<Restaurant>>> GetAllRestaurants()
  {
    try
    {
      // even if the route is not authorized, we can still attempt to see who is making the request
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      // NOTE since this route is not authorized, userInfo will be null if the user is not logged in
      List<Restaurant> restaurants = _restaurantsService.GetAllRestaurants(userInfo?.Id); // pass down null if user is not logged in instead of breaking
      return Ok(restaurants);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{restaurantId}")]
  public async Task<ActionResult<Restaurant>> GetRestaurantById(int restaurantId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Restaurant restaurant = _restaurantsService.GetRestaurantById(restaurantId, userInfo?.Id);
      return Ok(restaurant);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpPut("{restaurantId}")]
  public async Task<ActionResult<Restaurant>> UpdateRestaurant(int restaurantId, [FromBody] Restaurant restaurantData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Restaurant restaurant = _restaurantsService.UpdateRestaurant(restaurantId, userInfo.Id, restaurantData);
      return Ok(restaurant);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{restaurantId}")]
  public async Task<ActionResult<string>> DeleteRestaurant(int restaurantId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _restaurantsService.DeleteRestaurant(restaurantId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
