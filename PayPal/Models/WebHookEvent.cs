using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPal.Models
{
    public class WebHookEvent
    {
        public string id { get; set; }
        public DateTime create_time { get; set; }
        public string resource_type { get; set; }
        public string event_type { get; set; }
        public string summary { get; set; }

        public Resource resource { get; set; }
    }

    public class Resource
    {
        public string id { get; set; }  
        public string plan_id { get; set; }
        public string status { get; set; }
        public Subscriber subscriber { get; set; }
        public DateTime start_time { get; set; }
        public DateTime update_time { get; set; }
        public BillingInfo billing_info { get; set; }
    }
    public class Subscriber
    {
        public string email_address { get; set; }
        public string payer_id { get; set; }
        public Name name { get; set; }
    }

    public class Name
    {
        public string given_name { get; set; }
        public string surname { get; set; }
    }

    public class BillingInfo
    {
        public decimal outstanding_balance { get; set; }
        public DateTime next_billing_time { get; set; }
    }
}
