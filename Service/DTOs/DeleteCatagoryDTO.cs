using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class DeleteCategoryDTO
    {
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
    }
}