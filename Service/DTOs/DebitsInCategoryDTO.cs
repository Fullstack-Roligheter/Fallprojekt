using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class DebitsInCategoryDTO
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<DebitItemInCategoryListDTO> Debits { get; set; }
    }
}