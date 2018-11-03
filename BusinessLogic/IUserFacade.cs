namespace BusinessLogic
{
	public interface IUserFacade
	{
		string CreateUser(string user);

		string GetUser(string id);
	}
}