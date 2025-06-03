using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTZainIqbal
{
	internal class Car : Vehicle
	{
		public Car(int id, string name, double rentalprice, string category, string type, bool isreserved) : base(id, name, rentalprice, category, type, isreserved)
		{
		
		}
	}
}
