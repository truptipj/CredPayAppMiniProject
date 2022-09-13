using CredAppMiniProject.Models;
using CredAppMiniProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardDetailsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICardDetailService _cardDetailService;
        public CardDetailsController(UserManager<ApplicationUser> userManager, ICardDetailService cardDetailService)
        {
            _userManager = userManager;
            _cardDetailService = cardDetailService;

        }



     

        [HttpGet]
        public async Task<IActionResult>GetAllCardDetails()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            string userid = user.Id;
            return Ok(_cardDetailService.GetAllCardDetails(userid));
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_cardDetailService.GetById(id));
        }
        //doubt
        [HttpPost]
        public async Task<IActionResult>AddCardDetails(CardDetailModel cardDetailObj)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            cardDetailObj.UserId = user.Id;
            return Ok(_cardDetailService.AddCardDetails(cardDetailObj));
        }

        //doubt
        [HttpPut]
        public IActionResult UpdateCardDetails(CardDetailModel updateCardDetails, int id)
        {
            return Ok(_cardDetailService.UpdateCardDetails(updateCardDetails, id));
        }

        [HttpDelete]
        public IActionResult DeleteCardDetails(int id)
        {
            return Ok(_cardDetailService.DeleteCardDetails(id));
        }

    }
}