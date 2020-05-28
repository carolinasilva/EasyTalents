using EasyTalents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyTalents.Infra.Configurations
{
    public class CandidateWorkingTimesConfiguration : IEntityTypeConfiguration<CandidateWorkingTimes>
    {
        public void Configure(EntityTypeBuilder<CandidateWorkingTimes> builder)
        {
            builder.ToTable("CandidateWorkingTimes");
            builder.HasKey(p => new { p.CandidateId, p.WorkingTimeId });
            builder.HasOne(pt => pt.Candidate).WithMany(f => f.WorkingTimes).HasForeignKey(fk => fk.CandidateId);
            builder.HasOne(pt => pt.WorkingTime).WithMany().HasForeignKey(fk => fk.WorkingTimeId);
        }
    }
}
