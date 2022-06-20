using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class EditSavingPlanDTO
    {
        public int SavingId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
    }
}
