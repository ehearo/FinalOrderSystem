using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalOrderSystem.DataClass.DataModels
{
	public class Menu
	{
		public Guid SID { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Image { get; set; } = string.Empty;
		public string Price { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public DateTime CreateDateTime { get; set; }
		public DateTime ModifyDateTime { get; set; }
	}
}
