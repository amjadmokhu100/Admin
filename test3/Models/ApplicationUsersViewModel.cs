﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test3.Models
{
    public partial class ApplicationUsersViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        //public string Roles { get; set; }

        public bool IsActive { get; set; }

    }
}