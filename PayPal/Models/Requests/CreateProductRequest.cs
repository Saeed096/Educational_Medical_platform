﻿namespace PayPal.Models.Requests
{
    public class CreateProductRequest
    {
        public string name { get; set; }

        public string type { get; set; }

        public string id { get; set; }

        public string description { get; set; }

        public string category { get; set; }

        public string image_url { get; set; }

        public string home_url { get; set; }
    }
}