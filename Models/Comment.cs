using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodApple.Models {
    public class Comment {
        [Key]
        public int CommentId {get;set;}

        public string Content {get;set;}
        public int CreatorId {get;set;}
        public User Creator {get;set;}
        public int ProjectId {get;set;}
        public Project Project {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}