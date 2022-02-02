using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class ExpenseDTO
    {
        public int Amount { get; set; }
        public string Recipient { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }
}
