using Helpline.DTOs.ImageDTOs;
using Helpline.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Helpline.Controllers.API
{
    public class ImageAPIController : ApiController
    {
        private TicketServices _ticketServices;
        private UserServices _userServices;

        public ImageAPIController()
        {
            _ticketServices = new TicketServices();
            _userServices = new UserServices();
        }

        [HttpGet]
        public IEnumerable<ImageDTO> GetImages(int id)
        {
            // The id parameter is the id of the ticket.

            return _ticketServices.GetImageDTOs(id);
        }

        [HttpPost]
        public IHttpActionResult Create()
        {
            //Make sure user is authorized.
            bool authorized = _userServices.CanEditInformation(User.Identity.Name);

            /*This statement makes sure that there is at least one file in the request.
             Then it makes sure it does not exceed the file lenth. After that it  makes 
            sure that the file type is either png or jpeg.*/
            bool validFile = HttpContext.Current.Request.Files.Count > 0
                && HttpContext.Current.Request.Files[0].ContentLength < 6000000
                && (HttpContext.Current.Request.Files[0].ContentType == "image/png"
                    || HttpContext.Current.Request.Files[0].ContentType == "image/jpeg");

            //The Ticket Id is originally a string value but gets converted into a int. 
            string sampleIdString = HttpContext.Current.Request.Form.Get("TicketId");
            Int32.TryParse(sampleIdString, out int ticketId);

            bool lessThanSixImages = _ticketServices.CheckImagesCount(ticketId);

            if (validFile && authorized && lessThanSixImages)
            {
                //Makes sure user is authorized and photo is valid. 
                var imageFile = HttpContext.Current.Request.Files[0];

                //Returns a list of the new photos under the sample including the new one added.
                IEnumerable<ImageDTO> response = 
                    _ticketServices.Create(ticketId, imageFile, User.Identity.Name).ToList();

                return Ok(response);

            }
            else
            {
                //If either the use is not authorized of photo is not valid.
                string message = "Reached the limit of uploaded photos. Please remove a photo before " +
                        "adding another file.";

                if (!authorized)
                {
                    message = "You are not authorized to add photos.";
                }
                else if (!lessThanSixImages) 
                {
                    message = "Reached the limit of uploaded photos. Please remove a photo before " +
                        "adding another file.";
                }
                else
                {
                    message = "Improper photo type. Please check if the photo type is jpeg or png, " +
                    "and if the file is not too big.";
                }

                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(message)
                });
            }

        }

        [HttpDelete]
        [Route("api/ImageAPI/Delete/{id}")]
        public IHttpActionResult Remove(int id)
        {
            bool authorized = _userServices.CanEditInformation(User.Identity.Name);
            if (authorized)
            {
                //After photos is deleted return new list of photos minus the one that got deleted.
                IEnumerable<ImageDTO> response = _ticketServices.Remove(id, User.Identity.Name);

                return Ok(response);
            }
            else
            {
                string message = !authorized ?
                    "You are not authorized to add photos." : "Error removing image.";

                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(message)
                });
            }

        }
    }
}
