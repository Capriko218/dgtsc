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
		public int Round { get; set; }
		public DateTime GameDateTime { get; set; }

		public int LocationId { get; set; }
		public string LocationName { get; set; }
		public string LocationStreet1 { get; set;}
		public string LocationStreet2 { get; set; }
		public string LocationCity { get; set; }
		public string LocationRegion { get; set; }
		public string LocationCountry { get; set; }
		public string LocationPostal { get; set; }

		public string LocationAddress
		{
			get
			{
				var parts = new List<string>();

				if (LocationStreet1.IsNotBlank()) parts.Add(LocationStreet1);
				if (LocationStreet2.IsNotBlank()) parts.Add(LocationStreet2);
				if (LocationCity.IsNotBlank()) parts.Add(LocationCity);
				if (LocationRegion.IsNotBlank()) parts.Add(LocationRegion);
				if (LocationPostal.IsNotBlank()) parts.Add(LocationPostal);
				if (LocationCountry.IsNotBlank()) parts.Add(LocationCountry);

				if (!parts.Any()) return "(none)";

				return string.Join(", ", parts);
			}
		}

		public string Location
		{
			get
			{
				var parts = new List<string>();

				if (LocationName.IsNotBlank()) parts.Add(LocationName);
				if (LocationAddress.IsNotBlank()) parts.Add(LocationAddress);

				if (!parts.Any()) return "(none)";

				return string.Join(", ", parts);
			}
		}

		public string JoinCode { get; set; }

		public int? OwnerAccountId { get; set; }
		public string OwnerFirstName { get; set; }
		public string OwnerLastName { get; set; }
	}
}