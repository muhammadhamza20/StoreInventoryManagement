global using Inventory.Store.Services.Interfaces;
global using Microsoft.AspNetCore.Mvc;
global using Store.Inventory.Domain.DTO;

namespace Store.Inventory.Core.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAllCategories()
    {
        var response = await _categoryService.GetAllCategories();
        return Ok(response);
    }

    [HttpPost()]
    public async Task<IActionResult> AddCategory(AddCategoryDTO request)
    {
        if (!ModelState.IsValid)
            return BadRequest("One or more required parameters not passed.");

        var ApiResponse = new ApiSuccessResponseDTO();
        var response = await _categoryService.AddCategory(request);
        ApiResponse.Response = response;
        if (response.ToLower().Equals("success"))
            return Ok(ApiResponse);
        else
            return BadRequest(ApiResponse);

    }
}
