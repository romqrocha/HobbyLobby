using System;
using System.Threading.Tasks;
using BlazorServer.Data;
using Microsoft.AspNetCore.SignalR;

namespace BlazorServer.Hubs;
    public class ChatHub : Hub
    {
        public const string HubUrl = "/chat";

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? e)
        {
            Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(e);
        }

        // To send message to a group
        // Group name will be the to string of the chatID
        public async Task SendMessageToGroup(string groupName, string message, string sentUserID)
    {
        Console.WriteLine("THE HUB IS HERE. THE CHAT IS CALLED: " + groupName);
        await Clients.Groups(groupName).SendAsync("ReceiveMessage", groupName, message, sentUserID);
    }

    // I think we need to do this every time 
    public async Task AddToGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        Console.WriteLine($"{Context.ConnectionId} has joined");
    }

    public async Task RemoveFromGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        Console.WriteLine($"{Context.ConnectionId} has left");
    }
    }
