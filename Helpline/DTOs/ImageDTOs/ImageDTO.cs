using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.DTOs.ImageDTOs
{
    /// <summary>
    /// This is the DTO used to transfer image data 
    /// to the Images View.
    /// </summary>
    public class ImageDTO
    {
        public int Id { get; set; }
        public byte[] Charset { get; set; }
        public string Description { get; set; }
       
    }
}