using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductServices.Core.Interfaces;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Controllers
{
    [Route("api/views")]
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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ViewModel>> GetViewById(string id)
        {
            var view = await _viewService.GetViewByIdAsync(id);

            if (view == null)
                return NotFound($"There is no View with ID: {id}");

            return Ok(view);
        }

        [HttpGet]
        [Route("product/{id}")]
        public async Task<ActionResult<ViewModel>> GetViewByProductId(string id)
        {
            var view = await _viewService.GetViewByProductId(id);

            if (view == null)
                return NotFound($"There is no View with ProductID: {id}");

            return Ok(view);
        }

        [HttpPost]
        public async Task<ActionResult> AddView(ViewModel viewModel)
        {
            var added = await _viewService.AddViewAsync(viewModel);

            if (added) 
            {
                return Ok(); 
            }
            return BadRequest("Unable to add View");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteViewById(string id)
        {
            var deleted = await _viewService.DeleteViewAsync(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound($"There is no View with ID: {id}");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateView(string id, ViewModel viewModel)
        {
            if(id != viewModel.Id)
            {
                return BadRequest("Id for Update dissmatch with viewId");
            }

            var updated = await _viewService.UpdateView(viewModel, id);

            if (updated)
            {
                return Ok();
            }

            return BadRequest($"Unable to update view with Id: {id}");
        }
    }
}
