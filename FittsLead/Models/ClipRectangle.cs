using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class ClipRectangle
    {
        [Key]
        public int ClipRectangleId { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int FittsObjectId { get; set; }

        public FittsObject FittsObject { get; set; }
    }
}
