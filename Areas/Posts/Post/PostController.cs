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

namespace CongressusCore.Areas.Posts.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        public readonly PostRepository PostRepository;
        public readonly IConfiguration Config;
        public readonly IHostingEnvironment Env;
        public PostController(PostRepository postRepository, IConfiguration config, IHostingEnvironment env) {
            PostRepository = postRepository;
            Config = config;
            Env = env;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> Get()
        {
            return (await PostRepository.List()).ToList();
        }

        public async Task<ActionResult> Post(Post model) {     
            try {
                await PostRepository.Create(model);
                return Ok();
            }
            catch(Exception e) {
                return StatusCode(500, e);
            }
        }
    }
}
