using InteractionService.Domain;
using InteractionService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Service
{
    public interface IEmailInfoService
    {
        string CreateEmailInfo(EmailInfoModel emailInfo);
    }
}
