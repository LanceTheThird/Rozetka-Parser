using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required, MaxLength(300)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
                 
        public string Description { get; set; }

        public byte[] Image { get; set; }

        public string Picture { get; set; }

    }
}