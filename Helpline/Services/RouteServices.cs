using Helpline.Models;
using Helpline.Repository;
using Helpline.ViewModels;
using Helpline.ViewModels.RouteViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;

namespace Helpline.Services
{
    /// <summary>
    /// This Service Class contains a list of methods that 
    /// involve updating and creating new route models under 
    /// a ticket.
    /// </summary>
    public class RouteServices
    {
        private UnitOfWork _data;

        public RouteServices()
        {
            _data = new UnitOfWork();
        }

        #region public methods that involve the creation and update of routes and other related items

        /// <summary>
        /// Create New Route
        /// </summary>
        /// <param name="model">View model that holds form data</param>
        public void Create(UpdateTicketViewModel model)
        {
            try
            {
                int routeId = createRoute(model.RouteCategoryId, model.ProgramId, model.AssignedUserName, model.TicketId);
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", "Create Route", exception.Message, model.AssignedUserName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", "Create Route", exception.Message, model.AssignedUserName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", "Create Route", exception.Message, model.AssignedUserName);
                throw;
            }
        }

        /// <summary>
        /// This creates a new route as well, but the difference is that this 
        /// happens when the ticket updates and either the Program 
        /// or Routing Category changes.
        /// </summary>
        /// <param name="model">Update Ticket View Model used when the Ticket gets updated</param>
        /// <returns>returns true if at least one email was sent</returns>
        public void Update(UpdateTicketViewModel model)
        {
            try
            {
                Route dbRoute = _data.Routes
                    .GetFirst(r => r.TicketId == model.TicketId && r.IsActive, 
                    "RoutingCategory", "Program");     

                if (dbRoute == null 
                    || dbRoute.RoutingCategoryId != model.RouteCategoryId 
                    || dbRoute.ProgramId != model.ProgramId)
                {
                    /*If there is no prior route or if the routing category
                      or program changed then all previous routes get 
                    detactivated and a new route gets created.*/

                    IList<Route> preExistingRoutes = _data.Routes
                        .GetList(r => r.TicketId == model.TicketId);

                    foreach(Route preExistingRoute in preExistingRoutes)
                    {
                        //Deactivate all pre-existing routes
                        preExistingRoute.IsActive = false;
                        preExistingRoute.LastModifiedBy_UserName = model.AssignedUserName;
                        preExistingRoute.ModifiedDate = DateTime.Now;

                        _data.Routes.Edit(preExistingRoute);
                        _data.Save();
                    }                   

                    //Create new route
                    int routeId = createRoute(categoryId: model.RouteCategoryId, 
                        programId: model.ProgramId, 
                        userName: model.AssignedUserName, 
                        ticketId: model.TicketId);

                    /*Get the resolved category id. If the category 
                     is resolved then the ticket gets marked as complete. */
                    int resolvedId = _data.RoutingCategories
                        .GetFirst(rc => rc.Name == "Resolved")
                        .Id;

                    if (model.RouteCategoryId == resolvedId)
                    {
                        //Ticket is complete if category is resolved
                        
                        model.StatusId = _data.Statuses
                            .GetFirst(s => s.Name == "Complete")
                            .Id;

                        Ticket ticket = _data.Tickets
                            .GetFirst(t => t.Id == model.TicketId);

                        ticket.StatusId = model.StatusId;
                        ticket.LastModifiedBy_UserName = model.AssignedUserName;
                        ticket.ModifiedDate = DateTime.Now;

                        _data.Tickets.Edit(ticket);
                        _data.Save();                        
                    }                    
                }                
            }
            catch (EntityException exception)
            {
                _data.ErrorRepository.LogError("Entity Exception", "Update Route", exception.Message, model.AssignedUserName);
                throw;
            }
            catch (NullReferenceException exception)
            {
                _data.ErrorRepository.LogError("Null Reference Exception", "Update Route", exception.Message, model.AssignedUserName);
                throw;
            }
            catch (Exception exception)
            {
                _data.ErrorRepository.LogError("Unknown", "Update Route", exception.Message, model.AssignedUserName);
                throw;
            }
        }        

        #endregion


        #region private methods the create and update database objects

        //This private method is called by both the public Post and Update Method, involves the creation of a Route
        private int createRoute(int categoryId, int programId, string userName, int ticketId)
        {
            Route route = new Route()
            {
                RoutingCategoryId = categoryId,
                TicketId = ticketId,
                ProgramId = programId,                
                IsActive = true,
                CreatedBy_UserName = userName,
                CreationDate = DateTime.Now,
                LastModifiedBy_UserName = userName,
                ModifiedDate = DateTime.Now
            };

            _data.Routes.Create(route);
            _data.Save();

            return route.Id;
        }

        #endregion

    }
}