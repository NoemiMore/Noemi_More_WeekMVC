using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noemi_More_WeekMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.EF.Configurations
{
    internal class PiattoConfiguration : IEntityTypeConfiguration<Piatto>
    {
        public void Configure(EntityTypeBuilder<Piatto> modelBuilder)
        {
            modelBuilder.ToTable("Piatto");
            modelBuilder.HasKey(p => p.IdPiatto);
            modelBuilder.Property(p => p.Nome).IsRequired();
            modelBuilder.Property(p => p.Descrizione).IsRequired();
            modelBuilder.Property(p => p.Tipologia).IsRequired();
            modelBuilder.Property(p => p.Prezzo).IsRequired();

            
            modelBuilder.HasOne(p => p.Menu).WithMany(m => m.Piatti).HasForeignKey(m => m.IdMenu);
        }
    }
}
