

namespace help_reviews.Repositories;

public class RestaurantsRepository
{

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Restaurant CreateRestaurant(Restaurant restaurantData)
  {
    string sql = @"
    INSERT INTO
    restaurants(name, img_url, description, creator_id)
    VALUES(@Name, @ImgUrl, @Description, @CreatorId);

    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creator_id
    WHERE restaurants.id = LAST_INSERT_ID();";

    Restaurant restaurant = _db.Query(sql, (Restaurant restaurant, Profile account) =>
    {
      restaurant.Owner = account;
      return restaurant;
    }, restaurantData).SingleOrDefault();

    return restaurant;
  }

  internal List<Restaurant> GetAllRestaurants()
  {
    string sql = @"
    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creator_id;";

    List<Restaurant> restaurants = _db.Query(sql, (Restaurant restaurant, Profile account) =>
    {
      restaurant.Owner = account;
      return restaurant;
    }).ToList();

    return restaurants;
  }
}

