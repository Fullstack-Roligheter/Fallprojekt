using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.DTOs;
using System.Collections.Generic;
using Castle.Core.Internal;
using Service.Interfaces;

namespace Fallprojekt.Controllers
{
    [Route("api/debug")]
    [ApiController]
    public class DebugController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        private readonly IDebitService _debitService;
        public DebugController(ICategoryService categoryService, IUserService userService, IDebitService debitService)
        {
            _categoryService = categoryService;
            _userService = userService;
            _debitService = debitService;
        }

        [HttpGet("GetAllUsers")]
        public List<UserDTO> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }


        [HttpGet("GetAllDebits")]
        public List<DebitDTO> GetAllDebits()
        {
            return _debitService.GetAllDebits();
        }


        [HttpGet("GetDebitListForUser")]
        public List<DebitDTO> GetExpensesListForUser(UserIdDTO input)
        {
            return _debitService.GetDebitListForUser(input);
        }


        [HttpGet("ListAllCategories")]
        public IActionResult ListAllCategories()
        {
            try
            {
                var result = _categoryService.ListAllCategories();
                if (result.IsNullOrEmpty())
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
    }
}