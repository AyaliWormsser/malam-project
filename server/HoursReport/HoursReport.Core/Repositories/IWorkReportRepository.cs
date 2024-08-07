using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoursReport.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace HoursReport.Core.Repositories
{
    public interface IWorkReportRepository
    {
        public DbSet<WorkReport> GetList();
        public WorkReport GetById(int id);
        public void Add(WorkReport workReport);
        public void Update(int id, WorkReport workReport);
        public void Remove(int id);
    }
}
