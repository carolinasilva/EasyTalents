using EasyTalents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyTalents.Infra.Configurations
{
    public class CandidateConfiguration : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidate");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Email).IsRequired();
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Skype).IsRequired();
            builder.Property(p => p.Phone).IsRequired();
            builder.Property(p => p.Linkedin);
            builder.Property(p => p.City).IsRequired();
            builder.Property(p => p.State).IsRequired();
            builder.Property(p => p.Portfolio);
            builder.Property(p => p.SalaryRequirements).IsRequired();
            builder.Property(p => p.ExtraKnowledges);
            builder.Property(p => p.CrudUrl);
        }
    }
}
