using InteractionService.Model;
using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Service.SMSService
{
    public interface ISmsService
    {
        string Send(MessageRequestModel request);
    }
}
