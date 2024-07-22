using System.ComponentModel.DataAnnotations;

namespace Gulayan.Models
{
    public class Product
    {
        [Key]
        public short ProductID { get; set; }
        public string? ProductBatchNumber { get; set; }
        public string? ProductCategory { get; set; }
        public string? ProductDescription { get; set; }
        public DateTime ProductExpirationDate { get; set; }
        // public Image ProductImage { get; set; }
        public string? ProductName { get; set; }
        public DateTime ProductRecievedDate { get; set; }
        public string? ProductSupplier { get; set; }
        public int ProductStock { get; set; }
        // public string ProductTag { get; set; }
        /*
         Taste and Texture:
            Sweet
            Bitter
            Crunchy
            Juicy
            Tender
        Health Benefits:
            High in Fiber
            Rich in Vitamins
            Antioxidant
            Low-Calorie
            Anti-Inflammatory
        Organic Status:
            Organic
            Non-Organic
        Regional Origin:
            Local
            Imported
         */
    }
}