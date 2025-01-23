namespace help_reviews.Services;

public class ReportsService
{
  public ReportsService(ReportsRepository reportsRepository, RestaurantsService restaurantsService)
  {
    _reportsRepository = reportsRepository;
    _restaurantsService = restaurantsService;
  }
  private readonly ReportsRepository _reportsRepository;
  private readonly RestaurantsService _restaurantsService;
  internal Report CreateReport(Report reportData)
  {
    Restaurant restaurant = _restaurantsService.GetRestaurantById(reportData.RestaurantId, reportData.CreatorId);

    if (restaurant.CreatorId == reportData.CreatorId) throw new Exception($"YOU OWN THE {restaurant.Name}, {restaurant.Owner.Name}! YOU CANNOT LEAVE A REPORT FOR YOUR OWN RESTAURANT, SILLY GOOSE!");

    Report report = _reportsRepository.Create(reportData);
    return report;
  }

}
