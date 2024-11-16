using Educational_Medical_platform.PayPal.Models.Responses;
using Newtonsoft.Json;

namespace Educational_Medical_platform.PayPal.Models
{
  
        public class webhookEvent
        {
            public string Id { get; set; }

            [JsonProperty("event_version")] 
            public string EventVersion { get; set; }

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("resource_version")]
        public string ResourceVersion { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }
            public string Summary { get; set; }
            public Resource Resource { get; set; }
            public List<Link> Links { get; set; }
        }

        public class Resource
        {

        [JsonProperty("create_time")]
        public DateTime CreateTime { get; set; }

        [JsonProperty("purchase_units")]
        public List<PurchaseUnit> PurchaseUnits { get; set; }
            public List<Link> Links { get; set; }
            public string Id { get; set; }

        [JsonProperty("payment_source")]
        public PaymentSource PaymentSource { get; set; }
            public string Intent { get; set; }
            public Payer Payer { get; set; }
            public string Status { get; set; }
        }

        public class PurchaseUnit
        {

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }
            public Amount Amount { get; set; }
            public Payee Payee { get; set; }
            public Shipping Shipping { get; set; }
        public List<Item> items { get; set; }

    }

    public class Amount
        {

        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }
            public string Value { get; set; }
        }

        public class Payee
        {

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }
            public string MerchantId { get; set; }
        }

        public class Shipping
        {
            public Name Name { get; set; }
            public Address Address { get; set; }
        }

        public class Name
        {

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("given_name")]
        public string GivenName { get; set; }
            public string Surname { get; set; }
        }

        public class Address
        {

        [JsonProperty("address_line_1")]
        public string AddressLine1 { get; set; }

        [JsonProperty("address_line_2")]
        public string AddressLine2 { get; set; }

        [JsonProperty("admin_area_2")]
        public string AdminArea2 { get; set; }

        [JsonProperty("admin_area_1")]
        public string AdminArea1 { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        }

        public class PaymentSource
        {
            public Paypal Paypal { get; set; }
        }

        public class Paypal
        {

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("account_status")]
        public string AccountStatus { get; set; }
            public Name Name { get; set; }
            public Address Address { get; set; }
        }

        public class Payer
        {
            public Name Name { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("payer_id")]
        public string PayerId { get; set; }
            public Address Address { get; set; }
        }

        public class Link
        {
            public string Href { get; set; }
            public string Rel { get; set; }
            public string Method { get; set; }
        }

    }