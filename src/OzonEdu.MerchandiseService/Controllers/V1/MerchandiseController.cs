using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
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

        public MerchandiseController(IMerchandiseService merchService)
        {
            _merchService = merchService;
        }

        /// <summary>
        /// Информация о выданном мерче по сотруднику.
        /// </summary>
        [HttpGet("{id:long}")]
        public async Task<ActionResult> GetByEmployee(long id, CancellationToken token)
        {
            var skuList = await _merchService.GetByEmployee(id, token);
            return Ok(skuList);
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