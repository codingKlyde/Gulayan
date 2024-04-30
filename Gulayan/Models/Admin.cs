using System.ComponentModel.DataAnnotations;

namespace Gulayan.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
    }
}