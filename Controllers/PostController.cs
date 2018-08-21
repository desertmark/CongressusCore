using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CongressusCore.Contexts;
using CongressusCore.Models;

namespace CongressusCore.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public MyDbContext Db = new MyDbContext();
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            // return new List<Post> { 
            //     new Post() {
            //         Id = 1,
            //         Description = "A post",
            //         CreationDate = DateTime.UtcNow
            //     },
            //     new Post() {
            //         Id = 2,
            //         Description = "Another post",
            //         CreationDate = DateTime.Now
            //     },
            // };
            return Db.Posts.ToList();
        }
    }
}
