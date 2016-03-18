using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Models.Statistics
{
    public class BasicStatistic
    {
        public Metric Metric { get; set; }
        public string Name { get; set; }
        public BasicStatisticTypes Type { get; set; }
    }
}
