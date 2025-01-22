


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

  internal List<Restaurant> GetAllRestaurants()
  {
    List<Restaurant> restaurants = _repository.GetAllRestaurants();
    return restaurants;
  }

  internal Restaurant GetRestaurantById(int restaurantId)
  {
    Restaurant restaurant = _repository.GetRestaurantById(restaurantId);

    if (restaurant == null) throw new Exception($"Invalid restaurant id: {restaurantId}");

    return restaurant;
  }
}
