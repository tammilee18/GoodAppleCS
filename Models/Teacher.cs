using System.Collections.Generic;

namespace GoodApple.Models {
    public class Teacher: User {
        public string District {get;set;}
        public string School {get;set;}
        public string Subject {get;set;}
        List <Project> Projects {get;set;}
        List <Connection> Connections {get;set;}
        List<Comment> Comments {get;set;}
    }
}