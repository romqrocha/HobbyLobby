using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data;

public class Hobby
{

    [Key]
    public int HobbyId { get; set; }

    public required string HobbyName { get; set; }

    public List<ApplicationUser>? Users { get; set; }

}
