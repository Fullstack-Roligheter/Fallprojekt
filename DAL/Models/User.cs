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
        public int UserAge { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }


        public ICollection<Budget>? Budgets { get; set; } //En User kan ha många Budgets ("EN" SIDAN HÄR)

    }
}
