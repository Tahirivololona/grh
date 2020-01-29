﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GRH_UI.Models.Login
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginViewModel()
        {
            ErrorMessage = "";
        }
    }
}