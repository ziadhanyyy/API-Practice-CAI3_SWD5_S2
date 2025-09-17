using Blog_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogApiController : ControllerBase
    {
        public readonly BolgAPIDBContext dbcontext;
        public BlogApiController(BolgAPIDBContext context)
        {
            dbcontext = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            try
            {
                var posts = await dbcontext.Posts.ToListAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

