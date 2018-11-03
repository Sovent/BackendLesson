using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class User
    {
		public User(Guid id, string name)
		{
			Id = id;
			Name = name ?? throw new ArgumentNullException(nameof(name));
		}

		public Guid Id { get; }

		public string Name { get; }
    }
}
