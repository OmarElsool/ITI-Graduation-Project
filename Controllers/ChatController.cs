using Airbnb.Data;
using Airbnb.ViewModels;
using Airbnb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Airbnb.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext db;

        public ChatController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = db.Users.FirstOrDefault(u => u.Id == userId);
            var chat = db.Chats.Include(c => c.Message).Include(c => c.User).Where(c => c.User.Contains(currentUser)).ToList();

            ViewBag.currUser = userId;
            return View(chat);
        }
        public IActionResult CreateChat(string ReceiverId)
        {
            if (ReceiverId == null)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentUser = db.Users.FirstOrDefault(u => u.Id == userId);
            var ReceiverUser = db.Users.FirstOrDefault(u => u.Id == ReceiverId);
            var chatExsist = db.Chats.Where(c => c.User.Contains(currentUser) && c.User.Contains(ReceiverUser)).FirstOrDefault();
            if (chatExsist == null)
            {
                var newChat = new Chat
                {
                    ChatName = "New Chat",
                };
                db.Chats.Add(newChat);
                newChat.User.Add(currentUser);
                newChat.User.Add(ReceiverUser);
                db.SaveChanges();
            }
            if (currentUser == null && ReceiverUser == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var chat = db.Chats.Include(c => c.Message).Include(c => c.User).FirstOrDefault(c => c.User.Contains(currentUser) && c.User.Contains(ReceiverUser));
            ViewBag.currUser = userId;
            ViewBag.contactUser = ReceiverUser?.Id;

            return View(chat);
        }
        [HttpPost]
        public IActionResult SendMessage(MessageViewModel model, string ReceiverId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            var msg = new Message()
            {
                ChatId = model.ChatId,
                UserId = model.UserId,
                MsgText = model.Message,
                MsgDate = DateTime.Now
            };
            db.Messages.Add(msg);
            db.SaveChanges();

            var ReceiverUser = db.Users.FirstOrDefault(u => u.Id == ReceiverId);

            return RedirectToAction("CreateChat", new { ReceiverId = ReceiverUser.Id });
        }
    }
}
