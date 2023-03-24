using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductServices.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/view")]
    [ApiController]
    public class ViewController : ControllerBase
    {
        private readonly ILogger<ViewController> _logger;
        private readonly IViewService _viewService;

        public ViewController(ILogger<ViewController> logger, IViewService viewService)
        {
            _logger = logger;
            _viewService = viewService;
        }
    }
}
