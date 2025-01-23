using System.ComponentModel.DataAnnotations;

namespace help_reviews.Models;

public class Restaurant : RepoItem<int>
{
  public string Name { get; set; }
  [Url, MaxLength(3000)] public string ImgUrl { get; set; }
  [MaxLength(2000)] public string Description { get; set; }
  public int Visits { get; set; }
  public bool? IsShutdown { get; set; } //nullable
  public string CreatorId { get; set; }
  public Profile Owner { get; set; }
  public int ReportCount { get; set; }
}