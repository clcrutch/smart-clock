using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartClock.Models;

namespace SmartClock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public InfoModel Get()
        {
            var fileVersionInfo = FileVersionInfo.GetVersionInfo(typeof(Startup).Assembly.Location);

            return new InfoModel
            {
                Version = fileVersionInfo.FileVersion,
            };
        }
    }
}