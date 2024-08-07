using HoursReport.Core.Entities;
using HoursReport.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HoursReport.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkReportController : ControllerBase
    {
        private readonly IWorkReportService _workReportService;

        public WorkReportController(IWorkReportService workReportService)
        {
            _workReportService = workReportService;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<WorkReport> Get()
        {
            return _workReportService.GetAll().ToList();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public WorkReport Get(int id)
        {
            return _workReportService.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] WorkReport workReport)
        {
            _workReportService.Add(workReport);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] WorkReport workReport)
        {
            _workReportService.Update(id, workReport);
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _workReportService.Remove(id);
        }

    }
}
