using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Raccord.Domain.Model.Users;
using Raccord.API.ViewModels.Charts;
using Raccord.Core.Enums;

namespace Raccord.API.Controllers
{
    public class ChartsController : AbstractApiAuthController
    {
        public ChartsController(
            UserManager<ApplicationUser> userManager
            ): base(userManager)
        {
        }

        // GET: api/charts/1/project
        [HttpGet("{id}/project")]
        public IEnumerable<ChartInfoViewModel> GetForProject(long id)
        {
            var vms = new List<ChartInfoViewModel>
            {
                new ChartInfoViewModel
                {
                    Title = "Pagelength by day",
                    ChartType = ChartType.Column,
                    DataType = ChartDataType.Pagelength,
                    BaseData = new List<object>{"SD 1", "SD2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"},
                    SeriesData = new List<ChartSeriesDataViewModel>
                    {
                        new ChartSeriesDataViewModel{ Name = "Pagelength", Data = new List<object>{23, 69, 22, 48, 10, 76, 64, 65, 50, 49, null, null, null, null, null}}
                    }
                },
                new ChartInfoViewModel
                {
                    Title = "Burndown by pagelength",
                    ChartType = ChartType.Area,
                    DataType = ChartDataType.Pagelength,
                    BaseData = new List<object>{"SD 1", "SD2", "SD 3", "SD 4", "SD 5", "SD 6", "SD 6", "SD 8", "SD 9", "SD 10", "SD 11", "SD 12", "SD 13", "SD 14", "SD 15"},
                    SeriesData = new List<ChartSeriesDataViewModel>
                    {
                        new ChartSeriesDataViewModel{ Name = "Burndown", Data = new List<object>{174, 169, 152, 148, 100, 89, 72, 65, 51, 49, null, null, null, null, null}}
                    }
                },
                new ChartInfoViewModel
                {
                    Title = "Completed by pagelength",
                    ChartType = ChartType.Pie,
                    DataType = ChartDataType.Pagelength,
                    BaseData = new List<object>{"Not Scheduled", "Scheduled but not shot", "Shot"},
                    SeriesData = new List<ChartSeriesDataViewModel>
                    {
                        new ChartSeriesDataViewModel{ Name = "", Data = new List<object>{32, 21, 45}}
                    }
                }
            };

            return vms;
        }
    }
}
