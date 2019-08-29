using System;
using System.Collections.Generic;

namespace GoodApple.Models {
    public class WrapperModel {
        public User LoggedInUser {get;set;}
        public List<Project> AllProjects {get;set;}
        public List<Donation> MyDonations {get;set;}
        public Project newProject {get;set;}
        public Project ThisProject {get;set;}
        public Donation NewDonation {get;set;}
    }
}