using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Price
    {
        [Key]
        public int PriceID { get; set; }
       
        public string ProductPrice { get; set; }

        [Required, Column("Created", TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [Required]
        public virtual Product Product { get; set; }

        public int ProductID { get; set; }
    }
}