using HRProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRProject.DataAccessLayer.EntityFrameWork
{
    public class HRProjectContext : DbContext
    {
        public DbSet<HRDepartments> HRDepartments { get; set; }
        public DbSet<HRPositions> HRPositions { get; set; }
        public DbSet<HRProfessions> HRProfessions { get; set; }
        public DbSet<HRUsers> HRUsers { get; set; }
        public DbSet<HRUsersDetails> HRUsersDetails { get; set; }
        public DbSet<Members> Members { get; set; }

        public HRProjectContext()
        {
            Database.SetInitializer(new HRDB_Initializer());
        }
    }
}
