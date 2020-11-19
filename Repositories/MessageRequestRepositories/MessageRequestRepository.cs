using InteractionService.Data;
using InteractionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Repositories.MessageRequestRepositories
{
    public class MessageRequestRepository : IMessageRequestRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public MessageRequestRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public MessageRequest CreateMessageRequest(MessageRequest messageRequest)
        {
            _applicationDbContext.MessageRequests.Add(messageRequest);

            _applicationDbContext.SaveChanges();
            return messageRequest;
        }
    }
}
