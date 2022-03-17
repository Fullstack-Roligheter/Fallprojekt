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
        public string PlanStartDate { get; set; }
        public string PlanEndDate { get; set; }

    }
}
