using Microsoft.AspNetCore.Mvc;
using shop.data.DomainServices;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProductSupplierJoinController(IProductProductSupplierJoinDomainService productProductSupplierJoinDomainService) : ControllerBase
    {

        [HttpGet("MomentCreated")]
        public async Task<ActionResult<DateTime>> GetMomentCreated(Guid productId, Guid productSupplierId)
        {
            return Ok(await productProductSupplierJoinDomainService.GetMomentJoinCreated(productId, productSupplierId));
        }

    }
}
