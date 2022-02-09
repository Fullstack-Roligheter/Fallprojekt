﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class AddExpenseDTO
    {
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string? Recipient { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
    }
}