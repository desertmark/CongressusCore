using CongressusCore.Areas.Base;
using CongressusCore.Areas.Posts.Models;
using CongressusCore.Contexts;

namespace CongressusCore.Areas.Posts.Repositories {
    public class PostRepository : BaseRepository<Post> {
        public PostRepository(MyDbContext Context): base(Context) {
        }
    }
}