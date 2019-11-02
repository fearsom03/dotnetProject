using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Milestone_1.models
{
    public class User  
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "login")]
        public string login { get; set; }

        [Display(Name = "password")]
        public string password { get; set; }

        public  UserData UserData { get; set; }

        //public User(int id, string login, string password)
        //{
        //    this.id = id;
        //    this.login = login;
        //    this.password = password;
           
        //}

      
    }
}
