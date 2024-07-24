using Project.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Project.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
                return NotFound(new Result<int> { Success = false, Message = "Data not found" });

            if (result.Success && result.Value != null)
                return Ok(result);
            if (result.Success && result.Value == null)
                return NotFound(result);


            return BadRequest(result);
        }

    }
}