using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Models
{
    /// <summary>
    /// Used to store error logs.
    /// </summary>
    public class ErrorLog
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Task { get; set; }
        public string Message { get; set; }    
        public string UserName { get; set; }
        public DateTime Time { get; set; }
    }
}