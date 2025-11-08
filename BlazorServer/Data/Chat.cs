using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data;

public class Chat
{
    [Key]
    public int ChatId { get; set; }

    public required List<ApplicationUser> UserIds { get; set; }
}
