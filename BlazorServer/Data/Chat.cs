using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data;

public class Chat
{
    /// <summary>
    /// The ID of this chat.
    /// </summary>
    [Key]
    public int ChatID;

    public required List<ApplicationUser> UserIds;
}
