using Helpline.Data;
using Helpline.Models;
using Helpline.Repository.Interfaces;
using Helpline.ViewModels.AdminViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private HelplineDbContext _dbContext;

        public AdministratorRepository()
        {
            _dbContext = new HelplineDbContext();
        }

        public AdministratorRepository(HelplineDbContext context)
        {
            _dbContext = context;
        }
        



        

    }
}