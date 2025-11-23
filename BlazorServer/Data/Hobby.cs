using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data;

public class Hobby
{
    [Key]
    public int HobbyId { get; set; }

    public required string HobbyName { get; set; }

    public List<ApplicationUser>? Users { get; set; }

    public List<ApplicationUser>? Favorite1Users { get; set; }

    public List<ApplicationUser>? Favorite2Users { get; set; }

    public List<ApplicationUser>? Favorite3Users { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Hobby hobby && hobby.HobbyId == HobbyId;
    }

    public override int GetHashCode()
    {
        return HobbyId.GetHashCode();
    }
}
