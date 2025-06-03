using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTZainIqbal
{
	internal class Motorcycle : Vehicle
	{
		public Motorcycle(int id, string name, double rentalprice, string category, string type, bool isreserved) : base(id, name, rentalprice, category, type, isreserved)
		{

		}
	}
}
