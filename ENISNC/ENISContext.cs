using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENISNC.Models;
using static System.Collections.Specialized.BitVector32;

namespace ENISNC
{
    public class ENISContext : DbContext
    {

        public DbSet<User> users { get; set; }
        //public DbSet<> section { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.UseSqlServer(@"Server=LAPTOP-NGVDTDME\SQLEXPRESS;Database=ENISF;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        //public DbSet<Section> section { get; set; }

        public DbSet<ENISNC.Models.DemandePFE> DemandePFE { get; set; }
        //public DbSet<Section> section { get; set; }

        public DbSet<ENISNC.Models.Departement> Departement { get; set; }
        //public DbSet<Section> section { get; set; }

        public DbSet<ENISNC.Models.Paper> Paper { get; set; }
        //public DbSet<Section> section { get; set; }

        public DbSet<ENISNC.Models.Section> Section { get; set; }
    }
}


