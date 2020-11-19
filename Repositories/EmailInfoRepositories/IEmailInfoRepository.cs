using InteractionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Repositories.EmailInfoRepositories
{
    public interface IEmailInfoRepository
    {
        EmailInfo CreateEmailInfo(EmailInfo emailInfo);
    }
}
