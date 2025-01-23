using Microsoft.AspNetCore.Mvc;
using shop.data.DomainServices;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOrderJoinController(IProductOrderJoinDomainService productOrderJoinDomainService) : ControllerBase
    {

        [HttpGet("ProductAmount")]
        public async Task<ActionResult<int>> GetAmountOfProduct(Guid productId, Guid orderId)
        {
            return Ok(await productOrderJoinDomainService.GetAmountForProductInOrder(productId, orderId));
        }

    }
}
