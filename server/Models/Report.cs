using System.ComponentModel.DataAnnotations;

namespace help_reviews.Models;

public class Report : RepoItem<int>
{
  public string Title { get; set; }
  [MaxLength(2000)] public string Body { get; set; }
  [Range(1, 5)] public int Score { get; set; }
  [Url, MaxLength(3000)] public string ImgUrl { get; set; }
  public int RestaurantId { get; set; }
  public string CreatorId { get; set; }
  public Profile Creator { get; set; }
}