using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CompositionRoot
    {
		public static CompositionRoot Configure()
		{
			return new CompositionRoot()
			{
				UserFacade = new UserFacade()
			};
		}

		public IUserFacade UserFacade { get; private set; }
    }
}
