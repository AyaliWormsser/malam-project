using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoursReport.Core.Entities
{
    public class WorkReport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumOfHours { get; set; }
    }
}
