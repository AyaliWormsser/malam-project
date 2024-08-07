using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoursReport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace HoursReport.Data
{
    public class DataContext:DbContext
    {
        public DbSet<WorkReport> WorkReports_ { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db");
        }

    }
}
