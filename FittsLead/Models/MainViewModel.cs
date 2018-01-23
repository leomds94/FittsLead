using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class MainViewModel
    {
        public IEnumerable<SpeedTarget> SpeedTargets { get; set; }
        public IEnumerable<FittsUser> FittsUsers { get; set; }
    }
}
