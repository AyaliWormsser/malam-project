using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HoursReport.Core.Repositories;
using HoursReport.Core;
using HoursReport.Core.Entities;
using Microsoft.EntityFrameworkCore;
using HoursReport.Core.Services;
namespace HoursReport.Service
{
    public class WorkReportService: IWorkReportService
    {

        private readonly IWorkReportRepository _workReportRepository;

        public WorkReportService(IWorkReportRepository workReportRepository)
        {
            _workReportRepository = workReportRepository;
        }
        public DbSet<WorkReport> GetAll()
        {
            return _workReportRepository.GetList();
        }

        public WorkReport GetById(int id)
        {
            return _workReportRepository.GetById(id);
        }

        public void Add(WorkReport workReport)
        {

            _workReportRepository.Add(workReport);
        }

        public void Update(int id, WorkReport workReport)
        {
            _workReportRepository.Update(id, workReport);
        }


        public void Remove(int id)
        {
            _workReportRepository.Remove(id);
        }


    }
}
