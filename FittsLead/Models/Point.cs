using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class Point
    {
        [Key]
        public int PointId { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Time { get; set; }

        public int ClickedPointId { get; set; }
        public ClickedPoint ClickedPoint { get; set; }
    }
}
