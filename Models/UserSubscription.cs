using Educational_Medical_platform.Helpers;
using Shoghlana.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Medical_platform.Models
{
    public class UserSubscription
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
       
        public DateTime EndDate { get; set; }

        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }

        public SubscriptionStatus Status { get; set; }

        //---------------------------------------------------

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        //---------------------------------------------------

        public string SubscriptionPlanId { get; set; }
    }
}