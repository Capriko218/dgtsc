using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dgtsc.Models
{
    public class HomeIndexView_Model
    {
        public List<PlayerClass_Model> Players { get; set; }
        public string GameCode { get; set; }
        public string LocationName { get; set; }
        public DateTime GameDateTime { get; set; }
        [Required(ErrorMessage = "This can't be blank")]
        public string PlayerName { get; set; }
        public int GameId { get; set; }

        public string Error { get; set; }
    }
}