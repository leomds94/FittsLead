using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ClickedPoint
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Time { get; set; }

        public List<Point> Trajectory { get; set; }
    }

    public class ClipRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class FittsObject
    {
        public ClipRectangle ClipRectangle { get; set; }

        public List<ClickedPoint> ClickedPoints { get; set; }
    }
}
