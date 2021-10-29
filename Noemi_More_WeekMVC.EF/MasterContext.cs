using Microsoft.EntityFrameworkCore;
using Noemi_More_WeekMVC.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noemi_More_WeekMVC.EF
{
    public class MasterContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Piatto> Piatti { get; set; }
        public DbSet<Utente> Utenti { get; set; }




        public MasterContext()
        {

        }

        public MasterContext(DbContextOptions<MasterContext> options) : base(options) { }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Ristorante; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Menu>(new MenuConfiguration());
            modelBuilder.ApplyConfiguration<Piatto>(new PiattoConfiguration());
           
            modelBuilder.ApplyConfiguration<Utente>(new UtenteConfiguration());
        }
    }


}

