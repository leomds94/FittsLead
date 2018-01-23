using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FittsLead.Models;
using FittsLead.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FittsLead.Controllers
{
    public class HomeController : Controller
    {
        private readonly FittsDbContext _fittsDbContext;
        public List<SpeedTarget> Speed { get; set; }

        public HomeController(FittsDbContext fittsDbContext)
        {
            _fittsDbContext = fittsDbContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var fittsContext = _fittsDbContext.FittsUsers
                .Include(m => m.FittsObjects);
            var fittsList = await fittsContext.ToListAsync();
            if (id.HasValue)
            {
                var TargetQuery = await _fittsDbContext.FittsUsers
                                            .Include(f => f.FittsObjects)
                                            .ThenInclude(r => r.ClipRectangle)
                                            .Include(f => f.FittsObjects)
                                            .ThenInclude(s => s.ClickedPoint)
                                            .ThenInclude(p => p.Trajectory)
                                            .FirstOrDefaultAsync(q => q.UserId == id);
                var TargetList = TargetQuery.FittsObjects.ToArray();

                Speed = new List<SpeedTarget>();

                for (int l = 1; l < TargetList.Count<FittsObject>(); l++)
                {
                    List<int> xPoints = new List<int>();
                    List<int> yPoints = new List<int>();
                    List<double> speedPoints = new List<double>();
                    List<double> distFromTargets = new List<double>();
                    List<double> distDisplacement = new List<double>();

                    ClickedPoint clickedPoint = TargetList[l].ClickedPoint;

                    clickedPoint.Trajectory = clickedPoint.Trajectory.OrderBy(s => s.Time).ToList();
                    double vel;
                    double dist;
                    double distdisplace;

                    int xo = clickedPoint.Trajectory[0].X;
                    int yo = clickedPoint.Trajectory[0].Y;
                    int xi = clickedPoint.Trajectory[clickedPoint.Trajectory.Count - 1].X;
                    int yi = clickedPoint.Trajectory[clickedPoint.Trajectory.Count - 1].Y;

                    int x = xo;
                    int y = yo;

                    

                    for (int i = 1; i < clickedPoint.Trajectory.Count; i++)
                    {
                        xPoints.Add(clickedPoint.Trajectory[i].X);
                        yPoints.Add(clickedPoint.Trajectory[i].Y);

                        int xlast = x;
                        int ylast = y;
                        x = clickedPoint.Trajectory[i].X;
                        y = clickedPoint.Trajectory[i].Y;

                        vel = Math.Sqrt(
                            Math.Pow(x - xlast, 2) + Math.Pow(y - ylast, 2)) 
                            / (clickedPoint.Trajectory[i].Time - clickedPoint.Trajectory[i - 1].Time);

                        speedPoints.Add(vel);

                        dist = Math.Sqrt(Math.Pow(xi - x, 2) + Math.Pow(yi - y, 2));

                        distFromTargets.Add(dist);

                        distdisplace = Math.Abs((yi - yo) * x - (xi - xo) * y + (xi * yo) - (yi * xo)) / Math.Sqrt(Math.Pow(yi - yo, 2) + Math.Pow(xi - xo, 2));

                        distDisplacement.Add(distdisplace);
                    }

                    Speed.Add(new SpeedTarget
                    {
                        SpeedPoints = speedPoints,
                        DistFromTarget = distFromTargets,
                        DistFromCenter = Math.Sqrt(
                            Math.Pow((clickedPoint.X - TargetList[l].ClipRectangle.X + (TargetList[l].ClipRectangle.Width / 2)), 2) +
                            Math.Pow((clickedPoint.Y - TargetList[l].ClipRectangle.Y + (TargetList[l].ClipRectangle.Height / 2)), 2)),
                        DistDisplacement = distDisplacement,
                        xPoints = xPoints,
                        yPoints = yPoints,

                    });
                }
                return View(new MainViewModel() { FittsUsers = fittsList, SpeedTargets = Speed });
            }
            else
            {
                return View(new MainViewModel() { FittsUsers = fittsList });
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Json("");
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
