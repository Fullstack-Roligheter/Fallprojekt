using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class GEFSBOCategoryDTO
    {
        public string CategoryName { get; set; }
        public ICollection<GEFSBOCExpensesDTO> Expenses { get; set; }
    }
}