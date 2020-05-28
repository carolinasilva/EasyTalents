using EasyTalents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyTalents.Infra.Configurations
{
    public class WorkingTimeConfiguration : IEntityTypeConfiguration<WorkingTime>
    {
        public void Configure(EntityTypeBuilder<WorkingTime> builder)
        {
            builder.ToTable("WorkingTime");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).IsRequired();

            builder.HasData(
                new { Id = 1, Description = "Up to 4 hours per day / Até 4 horas por dia" },
                new { Id = 2, Description = "4 to 6 hours per day / De 4 á 6 horas por dia" },
                new { Id = 3, Description = "6 to 8 hours per day /De 6 á 8 horas por dia" },
                new { Id = 4, Description = "Up to 8 hours a day (are you sure?) / Acima de 8 horas por dia (tem certeza?)" },
                new { Id = 5, Description = "Only weekends / Apenas finais de semana" }
            );
        }
    }
}
