using System;
using BlazorServer.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BlazorServer.Services;

public class MessageService
{

    private ApplicationDbContext _context;



      /// <summary>
  /// The HobbyService constructor which sets the database context.
  /// </summary>
  /// <param name="context">The database context</param>
  public MessageService(ApplicationDbContext context) {
    _context = context;
  }
    // method for inserting a new message into the database

    public Message CreateNewMessage(ApplicationUser sentUser, Chat chat, string content, string sentDate = "", string sentTime = "")
    {
        if (sentDate == null || sentDate == "")
        {
            sentDate = DateOnly.FromDateTime(DateTime.Now).ToString();
        }

        if (sentTime == null || sentTime == "")
        {
            sentTime = TimeOnly.FromDateTime(DateTime.Now).ToString();
        }

        Message newMsg = new Message
        {
            SentUserId = sentUser.Id,
            SentUser = sentUser,
            ChatID = chat.ChatId,
            Chat = chat,
            MessageContent = content,
            SentDate = sentDate,
            SentTime = sentTime
        };

        return newMsg;
        
    }

    public async Task InsertNewMessage(Message msg)
    {
        EntityEntry<Message> newEntry = _context.Messages.Add(msg);
        await _context.SaveChangesAsync();
    }

}
