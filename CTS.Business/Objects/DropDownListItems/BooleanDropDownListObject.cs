using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpline.Objects.DropDownListObjects
{
    /// <summary>
    /// This is used as list items in 
    /// a drop down list that return boolean 
    /// values. 
    /// </summary>
    public class BooleanDropDownListObject
    {        
        /// <summary>
        /// Value of the option.
        /// </summary>
        public bool Value { get; set; }
        
        /// <summary>
        /// The text displayed in the option.
        /// </summary>
        public string Name { get; set; }

        public BooleanDropDownListObject(bool value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}