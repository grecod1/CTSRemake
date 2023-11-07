using Helpline.Repository;
using Helpline.Repository.Interfaces;
using Helpline.Services.Interfaces;
using Helpline.ViewModels.InformationLinkViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Services
{
    public class InformationLinkServices : IInformationLinkServices
    {
        IInformationLinkRepository InformationLinkRepository = new InformationLinkRepository();
        IErrorRepository ErrorRepository = new ErrorRepository();

        public InformationLinkIndexViewModel GetInformationLinkIndex(string userName)
        {
            try
            {
                InformationLinkIndexViewModel model = new InformationLinkIndexViewModel()
                {
                    InformationLinks = InformationLinkRepository.GetInformationLinks()
                };

                return model;
            }
            catch(Exception exception)
            {
                ErrorRepository.LogError("Unknown", "Get List of Information Links", exception.Message, userName);
                throw;
            }
            
        }
    }
}