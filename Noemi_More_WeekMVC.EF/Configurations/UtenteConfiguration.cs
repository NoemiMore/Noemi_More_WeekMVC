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
    class UtenteConfiguration : IEntityTypeConfiguration<Utente>
    {
        public void Configure(EntityTypeBuilder<Utente> modelBuilder)
        {
            modelBuilder.ToTable("Utente");
            modelBuilder.HasKey(u => u.IdUtente);
            modelBuilder.Property(u => u.Email).IsRequired();
            modelBuilder.Property(s => s.Password).IsRequired();
            modelBuilder.Property(u => u.Ruolo).IsRequired();
        }
    }
}
