using CredAppMiniProject.Models;
using CredAppMiniProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return Ok(_PayService.GetPay());
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_PayService.GetById(Id));
        }

        [HttpPost]
        public IActionResult AddPay(PayModel PayObj)
        {
            return Ok(_PayService.AddPay(PayObj));
        }

        //[HttpPut]
        //public IActionResult UpdatePay(PayModel updatePay, int Id)
        //{
        //    return Ok(_PayService.UpdatePay(updatePay, Id));
        //}

        //[HttpDelete]
        //public IActionResult DeletePay(int Id)
        //{
        //    return Ok(_PayService.DeletePay(Id));
     }
 }

