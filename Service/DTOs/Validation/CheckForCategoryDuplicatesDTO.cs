using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class CheckForCategoryDuplicatesDTO
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string CategoryName { get; set; }
    }
}
