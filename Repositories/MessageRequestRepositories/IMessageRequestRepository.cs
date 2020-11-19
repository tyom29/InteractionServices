using InteractionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Repositories.MessageRequestRepositories
{
    public interface IMessageRequestRepository
    {
        MessageRequest CreateMessageRequest(MessageRequest messageRequest);
    }
}
