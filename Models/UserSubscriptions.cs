using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class UserSubscriptions
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
       
        public DateTime EndDate { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        //---------------------------------------------------

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        //---------------------------------------------------

        public int SubscriptionPlanId { get; set; }
    }
}