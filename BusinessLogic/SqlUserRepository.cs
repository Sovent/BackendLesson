using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessLogic
{
	public class SqlUserRepository : IUserRepository
	{
		private IDbConnection dbConnection;
		public SqlUserRepository(string connectionString)
		{
			dbConnection = new SqlConnection(connectionString);
			dbConnection.Open();
		}

		public void InsertUser(User user)
		{
			using (var transaction = dbConnection.BeginTransaction())
			{
				dbConnection.Execute("INSERT INTO Users VALUES (@id, @name)", new
				{
					id = user.Id,
					name = user.Name
				}, transaction);
				transaction.Commit();
			}
			
		}

		public User LoadUser(Guid id)
		{
			var result = dbConnection.QueryFirstOrDefault("SELECT * FROM Users WHERE Id=@id", new { id });
			if (result == null)
			{
				return null;
			}

			return new User(result.Id, result.Name);
		}
	}
}
