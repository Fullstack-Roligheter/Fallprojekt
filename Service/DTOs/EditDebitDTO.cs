﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class EditDebitDTO
    {
        public Guid DebitId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string? Comment { get; set; }

        public Guid UserId { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? BudgetId { get; set; }
    }
}