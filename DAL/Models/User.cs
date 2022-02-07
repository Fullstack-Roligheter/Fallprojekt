﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class User
    {

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }





        public ICollection<Budget>? Budgets { get; set; } //En User kan ha många Budgets ("EN" SIDAN HÄR)

    }
}
