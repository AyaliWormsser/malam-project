using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoursReport.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace HoursReport.Core.Services
{
    public interface IWorkReportService
    {

        public DbSet<WorkReport> GetAll();
        public WorkReport GetById(int id);
        public void Add(WorkReport workReport);
        public void Update(int id, WorkReport workReport);
        public void Remove(int id);

    }
}
