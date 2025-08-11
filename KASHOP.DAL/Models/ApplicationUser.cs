﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace KASHOP.DAL.Models
{
  public  class ApplicationUser :IdentityUser

    {
        public string FullName { get; set; }
        public string? City{ get; set; }
        public string? Street { get; set; }
        public string? CodeResetPassword { get; set; }
        public DateTime? PasswordResetCodeExpiry { get; set; }
 
    }
}
