using System;
namespace CongressusCore.Areas.Posts.Models.Post {
    public class Post {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set;}
    }
}
