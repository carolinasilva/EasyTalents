using EasyTalents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyTalents.Infra.Configurations
{
    public class CandidateBestTimesConfiguration : IEntityTypeConfiguration<CandidateBestTimes>
    {
        public void Configure(EntityTypeBuilder<CandidateBestTimes> builder)
        {
            builder.ToTable("CandidateBestTimes");
            builder.HasKey(p => new { p.CandidateId, p.BestTimeId });
            builder.HasOne(pt => pt.Candidate).WithMany(f => f.BestTimes).HasForeignKey(fk => fk.CandidateId);
            builder.HasOne(pt => pt.BestTime).WithMany().HasForeignKey(f => f.BestTimeId);
        }
    }
}
