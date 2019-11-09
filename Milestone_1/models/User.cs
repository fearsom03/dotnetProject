using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace Milestone_1.models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Min Lenth 4")]
        [MaxLength(20,ErrorMessage ="Too much login letters dont be disaster to our server")]
        [Remote(action: "Create", controller: "User")]
        [Display(Name = "login")]
        public string login { get; set; }
        [Required]
        [MinLength(8,ErrorMessage ="Min Lenth 8")]
        
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
