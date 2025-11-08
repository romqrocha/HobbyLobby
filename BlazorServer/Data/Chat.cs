using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data;

public class Chat
{
    [Key]
    public int ChatID;

    public required List<ApplicationUser> UserIds;
}
