using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class BilanConfiguration : IEntityTypeConfiguration<Bilan>
    {
        public void Configure(EntityTypeBuilder<Bilan> builder)
        {
            // Définir la clé primaire composée
            builder.HasKey(b => new { b.CodeInfirmier, b.CodePatient, b.DatePrelevement });

            // Configurer la relation avec Infirmier
            builder.HasOne(b => b.Infirmier)
                .WithMany(i => i.Bilans)
                .HasForeignKey(b => b.CodeInfirmier)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurer la relation avec Patient
            builder.HasOne(b => b.Patient)
                .WithMany(p => p.Bilans)
                .HasForeignKey(b => b.CodePatient)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
