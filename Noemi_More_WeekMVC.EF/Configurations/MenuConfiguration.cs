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
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> modelBuilder)
        {
            modelBuilder.ToTable("Menu"); 
            modelBuilder.HasKey(m => m.IdMenu); 
            modelBuilder.Property(m => m.Nome).IsRequired();
            

            //Relazione Corso 1 -> Studenti n (uno a molti)
            modelBuilder.HasMany(m => m.Piatti).WithOne(p => p.Menu).HasForeignKey(p => p.IdMenu);
        }
    }
}
