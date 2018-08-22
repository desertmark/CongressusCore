using System;


namespace CongressusCore.Areas.Posts.Models {
    public class Comment {
        public int Id { get; set; }
        public string text { get; set; }
        public Post Post { get; set; }
        public DateTime CreatedAt { get;set; }

    }
}