using System.ComponentModel.DataAnnotations;

namespace Gulayan
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string DataUsername { get; set; }
        public string DataPassword { get; set; }
    }
}