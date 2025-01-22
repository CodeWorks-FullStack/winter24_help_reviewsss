


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
    Restaurant restaurant = _repository.Create(restaurantData);
    return restaurant;
  }

  internal List<Restaurant> GetAllRestaurants()
  {
    List<Restaurant> restaurants = _repository.GetAll();
    return restaurants;
  }

  internal Restaurant GetRestaurantById(int restaurantId)
  {
    Restaurant restaurant = _repository.GetById(restaurantId);

    if (restaurant == null) throw new Exception($"Invalid restaurant id: {restaurantId}");

    return restaurant;
  }

  internal Restaurant UpdateRestaurant(int restaurantId, string userId, Restaurant restaurantData)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId);

    if (restaurant.CreatorId != userId) throw new Exception("YOU CANNOT ALTER ANOTHER USER'S RESTAURANT, PAL");

    restaurant.Name = restaurantData.Name ?? restaurant.Name;
    restaurant.ImgUrl = restaurantData.ImgUrl ?? restaurant.ImgUrl;
    restaurant.Description = restaurantData.Description ?? restaurant.Description;
    restaurant.IsShutdown = restaurantData.IsShutdown ?? restaurant.IsShutdown; // property must be nullable in model for this to work

    _repository.Update(restaurant);

    return restaurant;
  }
}
