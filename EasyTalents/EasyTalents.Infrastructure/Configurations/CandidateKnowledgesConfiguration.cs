using EasyTalents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyTalents.Infra.Configurations
{
    public class CandidateKnowledgesConfiguration : IEntityTypeConfiguration<CandidateKnowledges>
    {
        public void Configure(EntityTypeBuilder<CandidateKnowledges> builder)
        {
            builder.ToTable("CandidateKnowledges");
            builder.HasKey(p => new { p.CandidateId, p.KnowledgeId });
            builder.Property(p => p.Rate).IsRequired();
            builder.HasOne(pt => pt.Candidate).WithMany(f => f.Knowledges).HasForeignKey(fk => fk.CandidateId);
            builder.HasOne(pt => pt.Knowledge).WithMany().HasForeignKey(fk => fk.KnowledgeId);
        }
    }
}
