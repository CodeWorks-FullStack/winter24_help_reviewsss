using help_reviews.Interfaces;

namespace help_reviews.Repositories;

public class ReportsRepository : IRepository<Report>
{
  private readonly IDbConnection _db;

  public ReportsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Report Create(Report rawData)
  {
    string sql = @"
    INSERT INTO
    reports(title, body, score, img_url, creator_id, restaurant_id)
    VALUES(@Title, @Body, @Score, @ImgUrl, @CreatorId, @RestaurantId);

    SELECT
    reports.*,
    accounts.*
    FROM reports
    JOIN accounts ON accounts.id = reports.creator_id
    WHERE reports.id = LAST_INSERT_ID();";

    Report report = _db.Query(sql, (Report report, Profile account) =>
    {
      report.Creator = account;
      return report;
    }, rawData).SingleOrDefault();

    return report;
  }

  public void Delete(int id)
  {
    throw new NotImplementedException();
  }

  public List<Report> GetAll()
  {
    throw new NotImplementedException();
  }

  public Report GetById(int id)
  {
    throw new NotImplementedException();
  }

  public void Update(Report updateData)
  {
    throw new NotImplementedException();
  }
}

