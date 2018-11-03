using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class MongoUserRepository : IUserRepository
	{
		private readonly string mongoConnectionString;

		static MongoUserRepository()
		{
			BsonClassMap.RegisterClassMap<User>(map =>
			{
				map.AutoMap();
				map.SetIgnoreExtraElements(true);
				map.MapIdMember(user => user.Id);
				map.MapMember(user => user.Name);
			});
		}

		public MongoUserRepository(string mongoConnectionString)
		{			
			this.mongoConnectionString = mongoConnectionString;
		}

		public User LoadUser(Guid id)
		{
			var mongoClient = new MongoClient(mongoConnectionString);
			var database = mongoClient.GetDatabase("LOD");
			var collection = database.GetCollection<User>("Hello");
			var foundUser = collection.Find(user => user.Id == id).FirstOrDefault();
			return foundUser;
		}

		public void InsertUser(User user)
		{
			var mongoClient = new MongoClient(mongoConnectionString);
			var database = mongoClient.GetDatabase("LOD");
			var collection = database.GetCollection<User>("Hello");
			collection.InsertOne(user);
		}
    }
}
