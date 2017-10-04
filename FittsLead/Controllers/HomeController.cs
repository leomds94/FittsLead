using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FittsLead.Models;

namespace FittsLead.Controllers
{
    public class SpeedTarget
    {
        public List<int> SpeedPoints { get; set; }
        public List<int> Time { get; set; }
    }

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("FittsData")]
        public IActionResult FittsData([FromBody]List<FittsObject> TargetList)
        {
            Startup.speed = new List<SpeedTarget>();

            foreach(FittsObject p in TargetList)
            {
                List<int> speedPoints = new List<int>();
                ClickedPoint clickedPoint = p.ClickedPoints[0];
                for(int i = 1; i < clickedPoint.Trajectory.Count; i++)
                {
                    speedPoints.Add((int)Math.Sqrt(
                        (clickedPoint.Trajectory[i].X - clickedPoint.Trajectory[i-1].X) * (clickedPoint.Trajectory[i].X - clickedPoint.Trajectory[i - 1].X) +
                        (clickedPoint.Trajectory[i].Y - clickedPoint.Trajectory[i - 1].Y) * (clickedPoint.Trajectory[i].Y - clickedPoint.Trajectory[i - 1].Y)));
                }
                Startup.speed.Add(new SpeedTarget
                {
                    SpeedPoints = speedPoints,
                    Time = new List<int>(Enumerable.Range(1, 1000))
            });
            }
            return Json(Startup.speed);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Json(Startup.speed);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
