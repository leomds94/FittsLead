using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class ClickedPoint
    {
        [Key]
        public int ClickedPointId { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public string Time { get; set; }

        public int FittsObjectId { get; set; }

        public FittsObject FittsObject { get; set; }
        public List<Point> Trajectory { get; set; }
    }
}
