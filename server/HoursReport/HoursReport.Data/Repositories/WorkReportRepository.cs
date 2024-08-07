using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoursReport.Core.Entities;
using HoursReport.Core.Repositories;
using Microsoft.EntityFrameworkCore;
namespace HoursReport.Data.Repositories
{
    public class WorkReportRepository: IWorkReportRepository
    {
        private readonly DataContext _context;

        public WorkReportRepository(DataContext context)
        {
            _context = context;
        }
        public DbSet<WorkReport> GetList()
        {
            return _context.WorkReports_;
        }

        public WorkReport GetById(int id)
        {
            return _context.WorkReports_.FirstOrDefault(t => t.Id == id);
        }

        public void Add(WorkReport workReport)
        {
            _context.WorkReports_.Add(workReport);
            _context.SaveChanges();
        }

        public void Update(int id, WorkReport workReport)
        {
            var existTask = GetById(id);
            workReport.Id = id;
            _context.Entry(existTask).CurrentValues.SetValues(workReport);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
           WorkReport temp = _context.WorkReports_.Find(id);
            if (temp == null)
                return;
            _context.WorkReports_.Remove(temp);
            _context.SaveChanges();
        }
    }
}
