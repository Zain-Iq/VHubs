using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTZainIqbal
{
	public class Vehicle
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double RentalPrice { get; set; }
		public string Category { get; set; }
		public string Type { get; set; }
		public bool IsReserved { get; set; }


		public Vehicle(int id, string name, double rentalprice, string category, string type, bool isreserved)
		{
			Id = id;
			Name = name;
			RentalPrice = rentalprice;
			Category = category;
			Type = type;
			IsReserved = isreserved;

			
		}

	}
}
