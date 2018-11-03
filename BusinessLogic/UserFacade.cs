using System;

namespace BusinessLogic
{
    public class UserFacade : IUserFacade
	{
		public string CreateUser(string user)
		{
			return "created user";
		}

		public string GetUser(string id)
		{
			throw new InvalidOperationException("User not found");
		}
    }
}
