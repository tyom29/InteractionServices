using InteractionService.Domain;
using InteractionService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Mapping
{
    public class MessageMapping:AutoMapper.Profile
    {
        public MessageMapping()
        {
            CreateMap<MessageRequest, MessageRequestModel>();
            CreateMap<MessageRequestModel, MessageRequest>().ForMember(x => x.Recipient, y => y.MapFrom(z => z.Messages[0].recipient))
                                                            .ForMember(x => x.MessageId, y => y.MapFrom(z => z.Messages[0].messageId))
                                                            .ForMember(x => x.Originator, y => y.MapFrom(z => z.Messages[0].sms.originator))
                                                            .ForMember(x => x.Content, y => y.MapFrom(z => z.Messages[0].sms.content.text));
        }
    }
}
