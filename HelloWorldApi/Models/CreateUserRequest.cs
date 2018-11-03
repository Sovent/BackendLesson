using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldApi.Models
{
    public class CreateUserRequest
    {
		[Required]
		public string Email { get; set; }

		[Required]
		[StringLength(50, MinimumLength = 8)]
		public string Password { get; set; }
    }
}
