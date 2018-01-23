using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class FittsUser
    {
        [Key]
        public int UserId { get; set; }

        public string Device { get; set; }
        public int StageCount { get; set; }

        public List<FittsObject> FittsObjects { get; set; }
        public List<StageThreshold> StageThreshold { get; set; }
    }
}
