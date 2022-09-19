﻿using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Category
    {
        [Key] // <-- Kör med Data annotations tills vidare bara för att vara tydlig
        public Guid Id { get; set; }
        public string Name { get; set; }


        public Guid? UserId { get; set; }
        public User? User { get; set; } // En User kan ha många Categories ("MÅNGA" SIDAN HÄR)
    }

}
