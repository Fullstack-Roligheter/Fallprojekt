using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class IncomeDTO
    {
        public int UserId { get; set; }
        public string? IncomeName { get; set; }
        public int Amount { get; set; }

        public DateTime Created { get; set; }
        public string IncomeCategory { get; set; }

    }
}
