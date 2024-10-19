namespace Educational_Medical_platform.DTO.PayPal
{
    public class CreateSubscribtionDTO
    {
        public string PlanId { get; set; }

        public string SubscriberEmail { get; set; }

        public string SubscriberFirstName { get; set; }

        public string SubscriberLastName { get; set; }
    }
}