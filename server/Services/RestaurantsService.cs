
namespace help_reviews.Services;

public class RestaurantsService
{
  public RestaurantsService(RestaurantsRepository repository)
  {
    _repository = repository;
  }
  private readonly RestaurantsRepository _repository;

  internal Restaurant CreateRestaurant(Restaurant restaurantData)
  {
    Restaurant restaurant = _repository.CreateRestaurant(restaurantData);
    return restaurant;
  }
}
