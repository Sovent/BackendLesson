using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic;
using HelloWorldApi.Filters;
using HelloWorldApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorldApi.Controllers
{
    public class UsersController : Controller
    {
		private readonly IUserFacade _facade;

		public UsersController(IUserFacade facade)
		{
			_facade = facade;
		}

		[HttpGet]
		[Route("users")]
		public string[] GetUsers()
		{
			return new[] { "Vasya", "Petya" };
		}

		[HttpGet]
		[Route("users/{id}")]
		[BusinessExceptionFilter]
		public ActionResult GetUser(Guid id)
		{
			var user = repo.LoadUser(id);
			return Ok(user);
		}

		[HttpDelete]
		[Route("users/{id}")]
		public ActionResult DeleteUser(string id, [FromBody]string reason)
		{
			if (id == "1")
			{
				return NotFound();
			}
			
			return Ok($"User with id {id} deleted with reason {reason}");
		}

		[HttpPost]
		[Route("users")]
		public ActionResult CreateUser([FromBody]string request)
		{
			var id = Guid.NewGuid();
			var newUser = new User(id, request);
			repo.InsertUser(newUser);
			return Ok(id);
		}
    }
}