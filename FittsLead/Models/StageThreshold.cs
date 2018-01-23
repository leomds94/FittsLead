using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class StageThreshold
    {
        [Key]
        public int StageThresholdId { get; set; }
        public int Value { get; set; }

        public int UserId { get; set; }
        public FittsUser FittsUser { get; set; }
    }
}
