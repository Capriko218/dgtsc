using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dgtsc.Data.Models
{
	public class PlayerItem
	{
		public int Id { get; set; }
		public int GameId { get; set; }
		public string Name { get; set; }
		public int? PartnerId { get; set; }
		public string PartnerName { get; set; }
	}
}