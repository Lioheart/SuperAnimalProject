using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, string userId, string chatId)
        {
            //await Clients<IC>.User(userId, user, message, timeStamp)
            
        }
    }
}
