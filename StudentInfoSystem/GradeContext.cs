using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    class GradeContext : System.Data.Entity.DbContext
    {
        public DbSet<Grade> grades { get; set; }

        public GradeContext() : base(Properties.Settings.Default.DbConnect)
        {
            
        }

    }
}
