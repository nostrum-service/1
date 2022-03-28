using System;

namespace BaseAttribute
{
    internal class NameAttribute : Attribute
    {
		private string name;
		public NameAttribute(string name)
		{
			this.name = name;
		}

		public string Name
		{
			get => name;
			set => name = value;

		}

	}
}