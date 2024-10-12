namespace PayPal.Models.Responses
{
    public class CreateProductResponse
    {
        public string id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public DateTime create_time { get; set; }

        public List<Link> links { get; set; }
    }
}
