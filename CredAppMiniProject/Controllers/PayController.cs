using CredAppMiniProject.Models;
using CredAppMiniProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CredAppMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayService _PayService;
        public PayController(IPayService PayService)
        {
            _PayService = PayService;
        }

        [HttpGet]
        public IActionResult GetPay()
        {
            try
            {
                return Ok(_PayService.GetPay());
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
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

                return StatusCode(400, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPay(PayModel PayObj)
        {
            try
            {
                return Ok(_PayService.AddPay(PayObj));
            }
            catch (Exception ex)
            {

                return StatusCode(400, ex.Message);
            }
        }
    }
}

