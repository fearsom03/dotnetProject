﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using Milestone_1.Controllers;

namespace Milestone_1.models
{
    public class Tweets
    {
        [Key]
        public int id { get; set; }

        public int UserDataForeignKey { get; set; }
        [ForeignKey("UserDataForeignKey")]
        public UserData UserData { get; set; }

        [Remote(action: "CreatePost", controller:"Tweet")]
        public string tweetText { get; set; }
        [Required]
        public DateTime post_date { get; set; }

        public IList<Comment> Comments { get; set; }

        public int GroupForeignKey { get; set; }
        [ForeignKey("GroupForeignKey")]
        public Group Group { get; set;}

        //public Tweets(int id, int UserForeignKey, string tweetText, DateTime post_date)
        //{
        //    this.id = id;
        //    this.UserForeignKey = UserForeignKey;
        //    this.tweetText = tweetText;
        //    this.post_date = post_date;
        //}

       
    }
}