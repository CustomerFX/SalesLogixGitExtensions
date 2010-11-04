using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FX.SalesLogix.Modules.GitExtensions.Model
{
	public class Branch
	{
		public Branch()
		{
			this.Current = false;
		}

		public Branch(string Name) : this()
		{
			this.Name = Name;
		}

		public Branch(string Name, bool Current)
		{
			this.Name = Name;
			this.Current = Current;
		}

		public string Name { get; set; }
		public bool Current { get; set; }

		public override string ToString()
		{
			return this.Name;
		}
	}
}
