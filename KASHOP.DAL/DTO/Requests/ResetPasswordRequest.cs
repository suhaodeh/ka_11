﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.DTO.Requests
{
    class ResetPasswordRequest
    {
        public string NewPassword { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
    }
}
