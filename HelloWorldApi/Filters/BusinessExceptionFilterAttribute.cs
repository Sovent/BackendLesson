using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldApi.Filters
{
    public class BusinessExceptionFilterAttribute : ExceptionFilterAttribute
    {
		public override void OnException(ExceptionContext context)
		{
			var exception = context.Exception;
			switch (exception)
			{
				case InvalidOperationException notFound:
					context.Result = new NotFoundObjectResult(notFound.Message);
					break;
				default:
					context.Result = new BadRequestObjectResult(exception.Message);
					break;
			}

			context.ExceptionHandled = true;
		}
	}
}
