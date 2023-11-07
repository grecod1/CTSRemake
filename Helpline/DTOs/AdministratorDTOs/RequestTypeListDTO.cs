using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.AdministratorDTOs
{
    public class RequestTypeListDTO
    {

        /*This DTO is used in the Request Type Index View. 
         This DTO represents individual request types in the 
        data table. */
        public int RequestTypeId { get; set; }
        public string RequestTypeName { get; set; }
        public StatusFieldDTO Status { get; set; }
    }
}