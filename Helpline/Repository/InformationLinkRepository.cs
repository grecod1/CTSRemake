using Helpline.Data;
using Helpline.Models;
using Helpline.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Repository
{    
    public class InformationLinkRepository : IInformationLinkRepository
    {
        private HelplineDbContext _dbContext;

        public InformationLinkRepository()
        {
            _dbContext = new HelplineDbContext();
        }

        protected void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        //This method is used for the Information Links View, not the Administartor View that handles Information Links
        public IEnumerable<InformationLink> GetInformationLinks()
        {
            IEnumerable<InformationLink> informationLinks = _dbContext.InformationLinks.Where(i => i.IsActive == true).ToList();

            return informationLinks;
        }

    }
}