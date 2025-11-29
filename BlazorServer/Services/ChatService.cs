using System.Security.Claims;
using BlazorServer.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorServer.Services;

public interface IChatService
{
    /// <summary>
    /// Looks for a chat containing the users and ONLY the users from the given IDs.
    /// </summary>
    /// <returns>A chat object if it is found, otherwise null.</returns>
    Task<Chat?> FindChatFromUserIds(List<string> userIds);

    /// <summary>
    /// Tries to create a new chat with the users from the given IDs.
    /// If there is already a chat with those users, it will throw a InvalidOperationException.
    /// </summary>
    /// <exception cref="InvalidOperationException"/>
    Task<Chat> NewUniqueChatFromUserIds(List<string> userIds);

    ApplicationUser? GetOtherUserInChat(Chat chat, string currentUserId);

    Task<List<Chat>> GetAllChatsForUser(string currentUserId);
}

public class ChatService(ApplicationDbContext db, IUserService userService) : IChatService
{
    private readonly ApplicationDbContext db = db;

    private readonly IUserService userService = userService;

    public async Task<Chat?> FindChatFromUserIds(List<string> userIds)
    {
        Chat? chatWithAllGivenUsers = await db
            .Chats.Include(c => c.UserIds)
            .Where(c => c.UserIds.Count == userIds.Count)
            .FirstOrDefaultAsync(chat => chat.UserIds.All(user => userIds.Contains(user.Id)));

        return chatWithAllGivenUsers;
    }

    private async Task<Chat> NewChatFromUserIds(List<string> userIds)
    {
        List<ApplicationUser> chatMembers = [];

        foreach (string userId in userIds)
        {
            ApplicationUser? chatMember = await userService.GetFromId(db, userId);

            if (chatMember is null)
            {
                continue;
            }

            chatMembers.Add(chatMember);
        }

        Chat newChat = new() { UserIds = chatMembers };

        EntityEntry<Chat> newEntry = db.Chats.Add(newChat);
        await db.SaveChangesAsync();

        return newEntry.Entity;
    }

    public async Task<Chat> NewUniqueChatFromUserIds(List<string> userIds)
    {
        Chat? existingChat = await FindChatFromUserIds(userIds);

        if (existingChat is not null)
        {
            throw new InvalidOperationException("Chat with these users already exists");
        }

        return await NewChatFromUserIds(userIds);
    }

    public ApplicationUser? GetOtherUserInChat(Chat chat, string currentUserId)
    {
        return chat.UserIds?.FirstOrDefault(u => u.Id != currentUserId);
    }

    public async Task<List<Chat>> GetAllChatsForUser(string currentUserId)
    {
        return await db.Chats
        .Include(c => c.UserIds)
        .Where(c => c.UserIds.Any(u => u.Id == currentUserId))
        .ToListAsync();
    }
}
