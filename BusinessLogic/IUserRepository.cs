using System;

namespace BusinessLogic
{
	public interface IUserRepository
	{
		void InsertUser(User user);
		User LoadUser(Guid id);
	}
}