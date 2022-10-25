using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISavingPlanService
    {
        void CreateSavingPlan(SavingPlanDTO saving);
        List<GetSavingPlanDTO> ListAllPlan(UserIdDTO user);
        void UpdatePlan(EditSavingPlanDTO editPlan);
        void DeletePlan(Guid id);


       
    }
}
