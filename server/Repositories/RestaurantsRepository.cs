namespace help_reviews.Repositories;

public class RestaurantsRepository
{

  public RestaurantsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;
}

