using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dgtsc.Models
{
    public class PlayerClass_Model
    {
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Name { get { return FirstName + " " + LastName; } }
        public string Number { get; set; }
        public int PDGAnum { get; set; }
    }
}