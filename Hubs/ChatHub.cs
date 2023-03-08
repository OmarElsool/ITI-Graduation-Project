using Airbnb.Data;
using Airbnb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Airbnb.Hubs
{

    [Authorize]
    public class ChatHub : Hub
    {
        public string CurrentUserId { get; set; }

        private readonly ApplicationDbContext db;
        private readonly UserManager<AppUser> userManager;
        public ChatHub(ApplicationDbContext _db, UserManager<AppUser> _userManager, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            userManager = _userManager;
            CurrentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
        public override Task OnConnectedAsync()
        {
            Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }
        public async Task SendMessage(string chatId, string message)
        {
            int _chatId = int.Parse(chatId);
            var currUser = await userManager.FindByIdAsync(CurrentUserId);
            Message msg = new Message
            {
                ChatId = _chatId,
                MsgText = message,
                UserId = currUser.Id,
                MsgDate = DateTime.Now,
            };
            await Clients.Group("chat" + _chatId).SendAsync("SendMessage", currUser, message);
            db.Messages.Add(msg);
            db.SaveChanges();
        }

        //public Task SendMessageToGroup(string sender, string receiver, string message)
        //{
        //    return Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
        //}
    }
}
