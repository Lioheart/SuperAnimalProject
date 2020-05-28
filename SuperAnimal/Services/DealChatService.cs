using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SuperAnimal.Data;
using SuperAnimal.Hubs;
using SuperAnimal.Models;
using SuperAnimal.Services.ServiceResponses;
using SuperAnimal.ViewModels.DealChat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperAnimal.Services
{
    public class DealChatService : BaseService
    {

        private readonly IHubContext<ChatHub> _chatHub;

        public DealChatService(ILogger<DealChatService> logger, ApplicationDbContext context, IHubContext<ChatHub> chatHub)
            : base(logger, context)
        {
            _chatHub = chatHub;

        }

        public async Task<ServiceResponse<DealChatIndexViewModel>> JoinChat(AppUser loggedUser, int petId, string connectionId)
        {
            var pet = Context.Pets.Include(x => x.User)
                .FirstOrDefault(x => x.Id == petId);

            if (pet == null)
                return ServiceResponse<DealChatIndexViewModel>.Error("Can not find pet");

            Chat chat = FindExistChat(loggedUser, pet);

            if (chat == null)
            {
                chat = CreateNewChat(loggedUser, pet);
            }

            await _chatHub.Groups.AddToGroupAsync(connectionId, chat.Id);

            var viewModel = GetChatDealIndexViewModel(chat);

            return ServiceResponse<DealChatIndexViewModel>.Ok(viewModel);
        }

        private Chat FindExistChat(AppUser loggedUser, Pet pet)
        {
            return Context.Chats.Include(x => x.Messages).FirstOrDefault(x =>
                            (x.StartUserId == loggedUser.Id && x.SecondUserId == pet.UserId)
                            ||
                            (x.StartUserId == pet.UserId && x.SecondUserId == loggedUser.Id)
                        );
        }

        private Chat CreateNewChat(AppUser loggedUser, Pet pet)
        {
            Chat chat = new Chat()
            {
                StartUser = loggedUser,
                SecondUser = pet.User,
                StartDateTime = DateTime.Now,
                Messages = new List<Message>()
            };
            Context.Chats.Add(chat);
            Context.SaveChanges();
            return chat;
        }

        private DealChatIndexViewModel GetChatDealIndexViewModel(Chat chat)
            => new DealChatIndexViewModel { Chat = chat };
    }
}
