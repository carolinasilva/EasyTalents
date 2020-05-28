using EasyTalents.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace EasyTalents.Infra.Data
{
    public class EasyTalentsContext : DbContext
    {
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Knowledge> Knowledge { get; set; }
        public DbSet<WorkingTime> WorkingTime { get; set; }
        public DbSet<BestTime> BestTime { get; set; }

        public EasyTalentsContext(DbContextOptions<EasyTalentsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                  .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                  .Where(type => type.GetInterfaces().Any(i => i.IsGenericType
                                  && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
