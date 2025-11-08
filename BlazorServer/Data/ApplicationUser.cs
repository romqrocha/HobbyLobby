using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlazorServer.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public required string DisplayName { get; set; }

    public string? ProfilePictureURL { get; set; }

    public string? BannerURL { get; set; }

    public required string Country { get; set; }

    public List<Hobby>? Hobbies { get; set; }

    [ForeignKey(DbTableNames.Hobby)]
    public int FavoriteHobby1ID { get; set; }

    /// <summary>
    /// This user's favorite hobby.
    /// </summary>
    public Hobby? FavoriteHobby1 { get; set; }

    [ForeignKey(DbTableNames.Hobby)]
    public int FavoriteHobby2ID { get; set; }

    /// <summary>
    /// This user's 2nd favorite hobby.
    /// </summary>
    public Hobby? FavoriteHobby2 { get; set; }

    [ForeignKey(DbTableNames.Hobby)]
    public int FavoriteHobby3ID { get; set; }

    /// <summary>
    /// This user's 3rd favorite hobby.
    /// </summary>
    public Hobby? FavoriteHobby3 { get; set; }

    public string? BcitEmail { get; set; }

    public bool BcitEmailIsVerified { get; set; }

    /// <summary>
    /// The date when this user's account was made.
    /// </summary>
    public DateTime DateRegistered { get; set; }
}
