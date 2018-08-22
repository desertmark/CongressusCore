using System;
using System.Collections.Generic;

namespace CongressusCore.Areas.Posts.Models {
    public class Post {
        public Post() {
            Comments = new HashSet<Comment>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set;}
        public ICollection<Comment> Comments { get; set; }
    }
}
