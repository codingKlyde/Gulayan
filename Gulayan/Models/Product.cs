using System.ComponentModel.DataAnnotations;

namespace Gulayan.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductDescription { get; set; }
        public DateTime ProductExpirationDate { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public DateTime ProductProductionDate { get; set; }
        public int ProductStock { get; set; }
        public string ProductType { get; set; }
        public float ProductWeight { get; set; }
    }
}