using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class SpeedTarget
    {
        public List<double> SpeedPoints { get; set; }
        public List<double> DistFromTarget { get; set; }
        public List<double> DistDisplacement { get; set; }
        public List<int> xPoints { get; set; }
        public List<int> yPoints { get; set; }
        public double DistFromCenter { get; set; }
    }
}
