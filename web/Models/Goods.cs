using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace webnet.Models
{
    [Table("Good")]
    public class Goods
    {
        [Key]
        public int GoodId { get; set; }
        public string GoodName { get; set; } = "";
        public int GoodPrice { get; set; }
        public int? GoodOldPrice { get; set; }
        public int? GoodDiscount { get; set; }
        public string GoodDescription { get; set; } = "";
        public string GoodImage { get; set; } = "";
        public string ProductType { get; set; } = "";
        public int ProductVolume { get; set; }
        public string ProductCategory { get; set; } = "";
        public string ProductCountry { get; set; } = "";
        public string? ProductDopCharact { get; set; } = "";
        public string GoodShortDescription { get; set; } = "";
    }
}