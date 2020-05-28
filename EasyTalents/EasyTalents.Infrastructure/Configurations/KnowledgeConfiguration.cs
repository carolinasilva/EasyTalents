using EasyTalents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyTalents.Infra.Configurations
{
    public class KnowledgeConfiguration : IEntityTypeConfiguration<Knowledge>
    {
        public void Configure(EntityTypeBuilder<Knowledge> builder)
        {
            builder.ToTable("Knowledge");
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Description).IsRequired();

            builder.HasData(
                new { Id = 1, Description = "Ionic" },
                new { Id = 2, Description = "ReactJS" },
                new { Id = 3, Description = "React Native" },
                new { Id = 4, Description = "Android" },
                new { Id = 5, Description = "Flutter" },
                new { Id = 6, Description = "SWIFT" },
                new { Id = 7, Description = "IOS" },
                new { Id = 8, Description = "HTML" },
                new { Id = 9, Description = "CSS" },
                new { Id = 10, Description = "Bootstrap" },
                new { Id = 11, Description = "Jquery" },
                new { Id = 12, Description = "AngularJs 1.*" },
                new { Id = 13, Description = "Angular" },
                new { Id = 14, Description = "Java" },
                new { Id = 15, Description = "Python" },
                new { Id = 16, Description = "Flask" },
                new { Id = 17, Description = "Asp.Net MVC" },
                new { Id = 18, Description = "Asp.Net WebForm" },
                new { Id = 19, Description = "C" },
                new { Id = 20, Description = "C#" },
                new { Id = 21, Description = "NodeJS" },
                new { Id = 22, Description = "Express - NodeJs" },
                new { Id = 23, Description = "Cake" },
                new { Id = 24, Description = "Django" },
                new { Id = 25, Description = "Majento" },
                new { Id = 26, Description = "PHP" },
                new { Id = 27, Description = "Vue" },
                new { Id = 28, Description = "Wordpress" },
                new { Id = 29, Description = "Phyton" },
                new { Id = 30, Description = "Ruby" },
                new { Id = 31, Description = "My SQL Server" },
                new { Id = 32, Description = "My SQL" },
                new { Id = 33, Description = "Salesforce" },
                new { Id = 34, Description = "Photoshop" },
                new { Id = 35, Description = "Illustrator" },
                new { Id = 36, Description = "SEO" },
                new { Id = 37, Description = "Laravel" }
            );
        }
    }
}
