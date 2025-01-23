
using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class RestaurantsRepository : IRepository<Restaurant>
{

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  public Restaurant Create(Restaurant restaurantData)
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

  public List<Restaurant> GetAll()
  {
    string sql = @"
    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants_with_report_count_view restaurants
    JOIN accounts ON accounts.id = restaurants.creator_id
    ORDER BY restaurants.created_at ASC;";

    List<Restaurant> restaurants = _db.Query(sql, (Restaurant restaurant, Profile account) =>
    {
      restaurant.Owner = account;
      return restaurant;
    }).ToList();

    return restaurants;
  }

  public Restaurant GetById(int restaurantId)
  {
    string sql = @"
    SELECT
    restaurants.*,
    accounts.*
    FROM restaurants
    JOIN accounts ON accounts.id = restaurants.creator_id
    WHERE restaurants.id = @restaurantId;";

    Restaurant restaurant = _db.Query(sql, (Restaurant restaurant, Profile account) =>
    {
      restaurant.Owner = account;
      return restaurant;
    }, new { restaurantId }).SingleOrDefault();

    return restaurant;
  }

  public void Update(Restaurant updateData)
  {
    string sql = @"
    UPDATE restaurants
    SET
    name = @Name,
    description = @Description,
    img_url = @ImgUrl,
    is_shutdown = @IsShutdown
    WHERE id = @Id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, updateData);

    if (rowsAffected != 1) throw new Exception($"{rowsAffected} WERE UPDATED AND THAT IS BAD");
  }

  public void Delete(int id)
  {
    string sql = "DELETE FROM restaurants WHERE id = @id LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { id });

    if (rowsAffected != 1) throw new Exception($"{rowsAffected} WERE DELETED AND THAT IS BAD");
  }
}

