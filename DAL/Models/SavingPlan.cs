using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SavingPlan
    {
        [Key]
        public int SavingId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
