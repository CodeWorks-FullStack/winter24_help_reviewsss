


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

  private List<Restaurant> GetAllRestaurants()
  {
    List<Restaurant> restaurants = _repository.GetAll();
    return restaurants;
  }

  // NOTE this is an overload. two methods can share the same name, but different methods can run based on types of parameters, number of parameters, or a combination of the two
  internal List<Restaurant> GetAllRestaurants(string userId)
  {
    List<Restaurant> restaurants = GetAllRestaurants(); // calls the private method

    // FindAll is the C# list method equivalent of the js filter array method
    // checks if the logged in user is the owner of the restaurant OR if the restaurant is not shut down
    return restaurants.FindAll(restaurant => restaurant.CreatorId == userId || restaurant.IsShutdown == false);
  }

  private Restaurant GetRestaurantById(int restaurantId)
  {
    Restaurant restaurant = _repository.GetById(restaurantId);

    if (restaurant == null) throw new Exception($"Invalid restaurant id: {restaurantId}");

    return restaurant;
  }

  // OVERLOAD
  internal Restaurant GetRestaurantById(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId); // private method

    if (restaurant.CreatorId != userId && restaurant.IsShutdown == true) throw new Exception($"Invalid restaurant id: {restaurantId} 😉");

    return restaurant;
  }

  internal Restaurant IncrementVisits(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId, userId);

    if (restaurant.CreatorId != userId)
    {
      restaurant.Visits++;
      // DON'T FORGET TO UPDATE THE DATABASE
      _repository.IncrementVisits(restaurant);
    }

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

  internal string DeleteRestaurant(int restaurantId, string userId)
  {
    Restaurant restaurant = GetRestaurantById(restaurantId);

    if (restaurant.CreatorId != userId) throw new Exception("YOU CANNOT DELETE ANOTHER USER'S RESTAURANT, AMIGO");

    _repository.Delete(restaurantId);

    return $"Deleted {restaurant.Name}";
  }
}
