using System.ComponentModel.DataAnnotations;

namespace Gulayan.Models
{
    public class Member
    {
        [Key]
        public short MemberID { get; set; }
        public string? MembeAddress { get; set; }
        public DateOnly MemberBirthDate { get; set; }
        public string? MemberName { get; set; }
        public string? MemberPhoneNumber { get; set; }
        public int MemberPoints { get; set; }
        public string? MemberType { get; set; }
        /*
         Regular Member: Standard membership with basic benefits.
         Premium Member: Higher tier membership with additional perks, such as discounts or exclusive offers.
         VIP Member: Top-tier membership with the most exclusive benefits and personalized services.
         Family Member: Membership that covers multiple individuals within a family.
         Senior Member: Membership with special benefits for senior citizens.
         */
    }
}