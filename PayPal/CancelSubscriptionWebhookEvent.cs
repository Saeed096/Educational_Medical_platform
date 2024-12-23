namespace Educational_Medical_platform.PayPal
{
    public class CancelSubscriptionWebhookEvent
    {
        public string id { get; set; }
        public DateTime create_time { get; set; }
        public string resource_type { get; set; }
        public string event_type { get; set; }
        public string summary { get; set; }
        public Resource resource { get; set; }
        public List<Link> links { get; set; }
        public string event_version { get; set; }
    }



    public class AgreementDetails
    {
        public OutstandingBalance outstanding_balance { get; set; }
        public string num_cycles_remaining { get; set; }
        public string num_cycles_completed { get; set; }
        public DateTime last_payment_date { get; set; }
        public LastPaymentAmount last_payment_amount { get; set; }
        public DateTime final_payment_due_date { get; set; }
        public string failed_payment_count { get; set; }
    }

    public class Amount
    {
        public string value { get; set; }
    }

    public class ChargeModel
    {
        public string type { get; set; }
        public Amount amount { get; set; }
    }

    public class LastPaymentAmount
    {
        public string value { get; set; }
    }

    public class MerchantPreferences
    {
        public SetupFee setup_fee { get; set; }
        public string auto_bill_amount { get; set; }
        public string max_fail_attempts { get; set; }
    }

    public class OutstandingBalance
    {
        public string value { get; set; }
    }

    public class Payer
    {
        public string payment_method { get; set; }
        public string status { get; set; }
        public PayerInfo payer_info { get; set; }
    }

    public class PayerInfo
    {
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string payer_id { get; set; }
        public ShippingAddress shipping_address { get; set; }
    }

    public class PaymentDefinition
    {
        public string type { get; set; }
        public string frequency { get; set; }
        public string frequency_interval { get; set; }
        public Amount amount { get; set; }
        public string cycles { get; set; }
        public List<ChargeModel> charge_models { get; set; }
    }

    public class Plan
    {
        public string curr_code { get; set; }
        public List<object> links { get; set; }
        public List<PaymentDefinition> payment_definitions { get; set; }
        public MerchantPreferences merchant_preferences { get; set; }
    }

    public class Resource
    {
        public AgreementDetails agreement_details { get; set; }
        public string description { get; set; }
        public List<Link> links { get; set; }
        public string id { get; set; }
        public ShippingAddress shipping_address { get; set; }
        public string state { get; set; }
        public Plan plan { get; set; }
        public Payer payer { get; set; }
        public DateTime start_date { get; set; }
    }


}
