using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CongressusCore.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using CongressusCore.Areas.Posts.Models;
using CongressusCore.Areas.Posts.Repositories;
using CongressusCore.Areas.Users.Models;
using System.Security.Claims;

namespace CongressusCore.Areas.Auth
{
    [Produces("application/json")]
    [Route("api/account")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly MyDbContext Db;
        public AccountController(MyDbContext db) {
            Db = db;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(this.GetCurrentUser(Db));
        }
    }

    public static class ControllerExtension {
        public static User GetCurrentUser(this Controller controller, MyDbContext db) {
            try
            {
                var userId = controller.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var user = db.Users.SingleOrDefault(u => u.Id.ToString() == userId);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
