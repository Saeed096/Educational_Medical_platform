using Educational_Medical_platform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Educational_Medical_platform.Configurations
{
    public class PlatformDataConfiguration : IEntityTypeConfiguration<PlatformData>
    {
        public void Configure(EntityTypeBuilder<PlatformData> builder)
        {
            builder.HasData(
                new PlatformData
                {
                    Id = 1,

                    PlanFixedPricePerMonth = 20m,
                    PlanSetupFee = 2m,
                    PlanTaxesPercentage = 10m,
                });
        }
    }
}