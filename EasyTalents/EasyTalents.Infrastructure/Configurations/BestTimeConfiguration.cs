using EasyTalents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyTalents.Infra.Configurations
{
    public class BestTimeConfiguration : IEntityTypeConfiguration<BestTime>
    {
        public void Configure(EntityTypeBuilder<BestTime> builder)
        {
            builder.ToTable("BestTime");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).IsRequired();

            builder.HasData(
                new { Id = 1, Description = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)" },
                new { Id = 2, Description = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)" },
                new { Id = 3, Description = "Night (7:00 p.m. to 10:00 p.m.) /Noite (de 19:00 as 22:00)" },
                new { Id = 4, Description = "Dawn (from 10 p.m. onwards) / Madrugada (de 22:00 em diante)" },
                new { Id = 5, Description = "Business (from 08:00 a.m. to 06:00 p.m.) / Comercial (de 08:00 as 18:00)" }
            );
        }
    }
}
