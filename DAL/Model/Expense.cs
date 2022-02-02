using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        [ForeignKey("User")]
        public int UserRefId { get; set; }
        public User User { get; set; }
        public int Amount { get; set; }

        [ForeignKey("Category")]
        public int CategoryRefId { get; set; }
        public Category Category { get; set; }

        public string Recipient { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpenseDate { get; set; }

        [MaxLength(50)]
        public string? Comment { get; set; }


    }
}
