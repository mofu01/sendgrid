using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.Models.Statistics
{
    public class Metric
    {
        public int Blocks { get; set; }
        public int BounceDrops { get; set; }
        public int Bounces { get; set; }
        public int Clicks { get; set; }
        public int Deferred { get; set; }
        public int Delivered { get; set; }
        public int InvalidEmails { get; set; }
        public int Opens { get; set; }
        public int Processed { get; set; }
        public int Requests { get; set; }
        public int SpamReportDrops { get; set; }
        public int SpamReports { get; set; }
        public int UniqueClicks { get; set; }
        public int UniqueOpens { get; set; }
        public int UnsubscribeDrops { get; set; }
        public int Unsubscribes { get; set; }
    }
}
