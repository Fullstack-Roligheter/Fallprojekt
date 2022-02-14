using Microsoft.AspNetCore.Mvc;
using Service;

namespace Fallprojekt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet("category")]
        public IActionResult ListAllCategories()
        {
            try
            {
                return Ok(CategoryService.Instance.ListAllCategory());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
