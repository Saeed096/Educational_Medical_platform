using System.ComponentModel.DataAnnotations;

namespace Educational_Medical_platform.DTO.PayPal
{
    public class CreateSubscribtionDTO
    {
        [Required]
        public string UserId { get; set; }

        //public string PlanId { get; set; }

        [Required]
        [RegularExpression(@"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        public string SubscriberEmail { get; set; }

        [Required]
        public string SubscriberFirstName { get; set; }

        [Required]
        public string SubscriberLastName { get; set; }
    }
}