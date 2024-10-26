using System.ComponentModel.DataAnnotations.Schema;

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

        [Column(TypeName = "decimal(10, 2)")]
        public decimal? PlanFixedPricePerMonth { get; set; }
       
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? PlanSetupFee { get; set; }
        
        [Column(TypeName = "decimal(10, 2)")]
        public decimal? PlanTaxesPercentage { get; set; }

        //===========================================

    }
}