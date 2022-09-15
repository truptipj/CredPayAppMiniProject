using CredAppMiniProject.Models;
using CredAppMiniProject.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPaymentDetailService _paymentDetailService;
        public PaymentDetailController(UserManager<ApplicationUser> userManager, IPaymentDetailService paymentDetailService)
        {
            _userManager = userManager;
            _paymentDetailService = paymentDetailService;

        }
        [HttpGet]
        public IActionResult GetPaymentDetails()
        {
            try
            {
                return Ok(_paymentDetailService.GetPaymentDetails());

            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_paymentDetailService.GetById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPaymentDetail(PaymentDetailModel paymentDetailObj)
        {
            try
            {
                return Ok(_paymentDetailService.AddPaymentDetail(paymentDetailObj));
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }


        [HttpDelete]
        public IActionResult DeletePaymentDetail(int id)
        {
            try
            {
                return Ok(_paymentDetailService.DeletePaymentDetail(id));
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }
    }
}
