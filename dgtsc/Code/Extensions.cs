using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dgtsc
{
	public static class Extensions
	{

		public static bool IsBlank(this object obj)
		{
			if (obj == null) return true;
			return string.IsNullOrWhiteSpace(obj.ToString());
		}

		public static bool IsNotBlank(this object obj)
		{
			return !obj.IsBlank();
		}
	}
}