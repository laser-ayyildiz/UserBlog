using System;
using Microsoft.AspNetCore.Mvc;

namespace UserBlogAPI.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}