



namespace help_reviews.Services;

public class ReportsService
{
  public ReportsService(ReportsRepository reportsRepository)
  {
    _reportsRepository = reportsRepository;
  }
  private readonly ReportsRepository _reportsRepository;

  internal Report CreateReport(Report reportData)
  {
    Report report = _reportsRepository.Create(reportData);
    return report;
  }

}
