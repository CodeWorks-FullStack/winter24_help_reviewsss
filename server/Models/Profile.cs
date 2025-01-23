using System.ComponentModel.DataAnnotations;

namespace help_reviews.Models;

public class Profile : RepoItem<string>
{
  public string Name { get; set; }
  [Url] public string Picture { get; set; }
}