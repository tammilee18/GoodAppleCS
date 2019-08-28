using System;
using System.ComponentModel.DataAnnotations;

namespace GoodApple.Models {   
    public class Connection {
        [Key]
        public int ConnectionId {get;set;}
        public int FollowedId {get;set;}
        public User Followed {get;set;}
        public int FollowerId {get;set;}
        public User Follower {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}