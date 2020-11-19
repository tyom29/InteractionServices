using InteractionService.Data;
using InteractionService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteractionService.Repositories.EmailInfoRepositories
{
    public class EmailInfoRepository : IEmailInfoRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmailInfoRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public  EmailInfo CreateEmailInfo(EmailInfo emailInfo)
        {
           
            _applicationDbContext.EmailInfos.Add(emailInfo);

             _applicationDbContext.SaveChanges();
            return emailInfo;
        }
    }
}
