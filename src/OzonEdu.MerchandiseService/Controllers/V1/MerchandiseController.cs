using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Queries.MerchRequestAggregate;
using OzonEdu.MerchandiseService.Models;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers.V1
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchService;
        private readonly IMediator _mediator;

        public MerchandiseController(IMerchandiseService merchService, IMediator mediator)
        {
            _merchService = merchService;
            _mediator = mediator;
        }

        /// <summary>
        /// Информация о выданном мерче по сотруднику.
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<List<SkuPostViewModel>>> GetByEmployee(long id, CancellationToken token)
        {
            var query = new GetIssuedMerchByEmployeeQuery()
            {
                EmployeeId = id
            };

            var result = await _mediator.Send(query, token);

            return result.Select(x => new SkuPostViewModel
            {
                MerchItem = new MerchItemPostViewModel()
                {
                    ItemName = x.MerchPack.MerchPackName.Value,
                    ItemProperty = null
                }
            }).ToList();
        }

        /// <summary>
        /// Выдача мерча по запросу.
        /// </summary>
        [HttpPost("{id:long}")]
        public async Task<ActionResult> TakeMerch([FromBody] SkuPostViewModel postViewModel, [FromQuery] long id,
            CancellationToken token)
        {
            if (postViewModel.MerchItem == null)
            {
                return BadRequest("MerchItem is null");
            }

            var sku = new SkuSearchModel()
            {
                MerchItem = new MerchSearchItem()
                {
                    ItemName = postViewModel.MerchItem.ItemName,
                    ItemProperty = postViewModel.MerchItem.ItemProperty
                },
                SkuProperty = postViewModel.SkuProperty
            };

            var isMerchTaken = await _merchService.TakeMerch(sku, id, token);
            return isMerchTaken ? Ok(isMerchTaken) : NotFound();
        }
    }
}