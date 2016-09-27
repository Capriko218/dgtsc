using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dgtsc.Data.Models
{
	public class GameItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int LocationId { get; set; }
		public string JoinCode { get; set; }
		public int? OwnerAccountId { get; set; }
	}
}