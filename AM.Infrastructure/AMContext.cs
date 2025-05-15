using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
   public class AMContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Analyse> Analyses { get; set; }
        public DbSet<Bilan> Bilans { get; set; }
        public DbSet<Infirmier> Infirmiers { get; set; }

       public DbSet<Laboratoire> laboratoires { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                         Initial Catalog=LaboGachitaZied;
                                         Integrated Security=true;
                                         MultipleActiveResultSets=true");

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laboratoire>()
            .Property(l => l.Localisation)
            .HasColumnName("AdresseLabo")
            .HasMaxLength(50);
          

            modelBuilder.Entity<Bilan>()
           .HasKey(b => new { b.CodeInfirmier, b.CodePatient, b.DatePrelevement });




            base.OnModelCreating(modelBuilder);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

            configurationBuilder.Properties<DateTime>().HaveColumnType("DateTime");
            base.ConfigureConventions(configurationBuilder);

        }



    }
}
