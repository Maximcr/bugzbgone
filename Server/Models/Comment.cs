﻿using System;
using System.ComponentModel.DataAnnotations;
using Contracts;

namespace Models
{
    public class Comment : IDates
    {
        [Key]
        public int Id { get; set; }

        public UserProfile Creator { get; set; }
        public string Content { get; set; }
        public Bug BaseItem { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}