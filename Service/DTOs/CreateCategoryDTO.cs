﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class CreateCategoryDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}