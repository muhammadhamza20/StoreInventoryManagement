namespace Store.Inventory.Core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("ProductCounts")]
    public async Task<IActionResult> GetProductCountsByStatuses()
    {
        var response = await _productService.GetProductCountsByStatuses();
        return Ok(response);
    }

    [HttpPut("ChangeStatus/{id:int}")]
    public async Task<IActionResult> ChangeProductStatus(int id, [FromBody] ChangeStatusDTO request)
    {
        if (!ModelState.IsValid)
            return BadRequest("One or more required parameters not passed.");

        var response = await _productService.UpdateStatus(id, request.Status);
        return Ok(response);
    }

    [HttpGet("SellProduct/{id:int}")]
    public async Task<IActionResult> SellProduct(int id)
    {
        var apiResponse = new ApiSuccessResponseDTO();
        var response = await _productService.MarkProductAsSold(id);
        if (response)
        {
            apiResponse.Response = "Sold!";
            return Ok(apiResponse);
        }
        else
        {
            apiResponse.Response = "Couldn't Sell it!";
            return BadRequest(apiResponse);
        }
    }
}
