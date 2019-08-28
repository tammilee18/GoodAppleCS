using System.Collections.Generic;

namespace GoodApple.Models {
    public class Donor: User {
        List<Donation> Donations {get;set;}
        List<Connection> Connections {get;set;}
        List<Comment> Comments {get;set;}
    }
}