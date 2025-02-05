using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.data.DomainServices;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ICartDomainService CartService, ICartCheckoutService CartCheckoutService) : ControllerBase
    {

        [HttpPut("addproduct")]
        public async Task<ActionResult<bool>> AddCartProductToCart([FromBody] AddProductToCartRequestDto AddProductRequestDto)
        {
            return Ok(await CartService.AddCartProductToCartAsync(AddProductRequestDto.CartId, AddProductRequestDto.ProductId, AddProductRequestDto.Quantity));
        }

        [HttpPut("checkout/{CartId}")]
        public async Task<ActionResult<Guid>> OrderCartOfCustomer(Guid CartId)
        {
            return await CartCheckoutService.CheckoutCartAsync(CartId);
        }

    }
}
