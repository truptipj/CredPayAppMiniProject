using CredAppMiniProject.Models;
using CredAppMiniProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CredAppMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayService _PayService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PayController(UserManager<ApplicationUser> userManager, IPayService PayService)
        {
            _PayService = PayService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetPay()
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                string userid = user.Id;
                return Ok(_PayService.GetPay(userid));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Custom Error Text " + ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_PayService.GetById(Id));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Custom Error Text " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPay(PayModel Pay)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                Pay.UserId = user.Id;
                return Ok(_PayService.AddPay(Pay));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Custom Error Text " + ex.Message);
            }
        }
        [HttpPut]
        public IActionResult UpdatePay(PayModel updatePay, int id)
        {
            try
            {

                return Ok(_PayService.UpdatePay(updatePay, id));
            }
            catch (Exception ex)
            {
                return BadRequest( ex.Message);
            }
        }
    }
}

