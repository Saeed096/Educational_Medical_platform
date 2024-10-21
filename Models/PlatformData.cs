namespace Educational_Medical_platform.Models
{
    public class PlatformData
    {
        public int Id { get; set; }

        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescribtion { get; set; }

        public string? PlanId { get; set; }
        public string? PlanName { get; set; }
        public string? PlanDescription { get; set; }

        public decimal? PlanFixedPricePerMonth { get; set; }
        public decimal? PlanSetupFee { get; set; }
        public decimal? PlanTaxesPercentage { get; set; }
    }
}