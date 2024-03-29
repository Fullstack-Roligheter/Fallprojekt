﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class GEFSBOExpenseDTO
    {
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public string? Recipient { get; set; }
        public string Date { get; set; }
        public string? Comment { get; set; }
    }
}