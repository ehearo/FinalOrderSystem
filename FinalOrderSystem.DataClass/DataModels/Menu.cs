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
		public string Name { get; set; }
		public string Image { get; set; }
		public string Price { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public DateTime CreateDateTime { get; set; }
		public DateTime ModifyDateTime { get; set; }
	}
}
