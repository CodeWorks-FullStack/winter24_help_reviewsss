namespace help_reviews.Repositories;

public class ReportsRepository
{
  private readonly IDbConnection _db;

  public ReportsRepository(IDbConnection db)
  {
    _db = db;
  }
}

