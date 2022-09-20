using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; } // En User kan ha många Categories ("MÅNGA" SIDAN HÄR)
    }

}
