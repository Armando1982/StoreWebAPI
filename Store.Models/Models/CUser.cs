﻿using System.ComponentModel.DataAnnotations;

namespace Store.Models.Models
{
    public class CUser
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
