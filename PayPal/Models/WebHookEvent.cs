//using Educational_Medical_platform.PayPal.Models;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PayPal.Models
//{
//    //public class WebHookEvent
//    //{
//    //    public string id { get; set; }
//    //    public DateTime create_time { get; set; }
//    //    public string resource_type { get; set; }
//    //    public string event_type { get; set; }
//    //    public string summary { get; set; }

//    //    public Resource resource { get; set; }
//    //}

//    //public class Resource
//    //{
//    //    public string id { get; set; }  
//    //    public string plan_id { get; set; }
//    //    public string status { get; set; }
//    //    public Subscriber subscriber { get; set; }
//    //    public DateTime start_time { get; set; }
//    //    public DateTime update_time { get; set; }
//    //    public BillingInfo billing_info { get; set; }
//    //}
//    //public class Subscriber
//    //{
//    //    public string email_address { get; set; }
//    //    public string payer_id { get; set; }
//    //    public Name name { get; set; }
//    //}

//    //public class Name
//    //{
//    //    public string given_name { get; set; }
//    //    public string surname { get; set; }
//    //}

//    //public class BillingInfo
//    //{
//    //    public decimal outstanding_balance { get; set; }
//    //    public DateTime next_billing_time { get; set; }
//    //}

//    public class WebHookEvent
//    {
//        public string Id { get; set; }
//        public string EventVersion { get; set; }
//        public DateTime CreateTime { get; set; }
//        public string ResourceType { get; set; }
//        public string ResourceVersion { get; set; }
//        public string EventType { get; set; }
//        public string Summary { get; set; }
//        public Resource Resource { get; set; }
//        public List<Link> Links { get; set; }
//    }

//    public class Resource
//    {
//        public string Quantity { get; set; }
//        public Subscriber Subscriber { get; set; }
//        public DateTime CreateTime { get; set; }
//        public bool PlanOverridden { get; set; }
//        public Amount ShippingAmount { get; set; }
//        public DateTime StartTime { get; set; }
//        public DateTime UpdateTime { get; set; }
//        public BillingInfo BillingInfo { get; set; }
//        public List<Link> Links { get; set; }
//        public string Id { get; set; }
//        public string PlanId { get; set; }
//        public string Status { get; set; }
//        public DateTime StatusUpdateTime { get; set; }
//    }

//    public class Subscriber
//    {
//        public string EmailAddress { get; set; }
//        public string PayerId { get; set; }
//        public Name Name { get; set; }
//        public ShippingAddress ShippingAddress { get; set; }
//    }

//    public class Name
//    {
//        public string GivenName { get; set; }
//        public string Surname { get; set; }
//        public string FullName { get; set; }
//    }

//    public class ShippingAddress
//    {
//        public Name Name { get; set; }
//        public Address Address { get; set; }
//    }

//    public class Address
//    {
//        public string AddressLine1 { get; set; }
//        public string AddressLine2 { get; set; }
//        public string AdminArea2 { get; set; }
//        public string AdminArea1 { get; set; }
//        public string PostalCode { get; set; }
//        public string CountryCode { get; set; }
//    }

//    //public class Amount
//    //{
//    //    public string CurrencyCode { get; set; }
//    //    public string Value { get; set; }
//    //}

//    public class BillingInfo
//    {
//        public Amount OutstandingBalance { get; set; }
//        public List<CycleExecution> CycleExecutions { get; set; }
//        public DateTime NextBillingTime { get; set; }
//        public DateTime FinalPaymentTime { get; set; }
//        public int FailedPaymentsCount { get; set; }
//    }

//    public class CycleExecution
//    {
//        public string TenureType { get; set; }
//        public int Sequence { get; set; }
//        public int CyclesCompleted { get; set; }
//        public int CyclesRemaining { get; set; }
//        public int CurrentPricingSchemeVersion { get; set; }
//        public int TotalCycles { get; set; }
//    }

//    public class Link
//    {
//        public string Href { get; set; }
//        public string Rel { get; set; }
//        public string Method { get; set; }
//        public string EncType { get; set; }
//    }




//}
