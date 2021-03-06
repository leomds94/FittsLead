﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FittsLead.Models
{
    public class FittsObject
    {
        [Key]
        public int FittsObjectId { get; set; }

        public int UserId { get; set; }
        public FittsUser FittsUser { get; set; }

        public ClipRectangle ClipRectangle { get; set; }
        public ClickedPoint ClickedPoint { get; set; }
    }
}
