using CredAppMiniProject.DAL;
using CredAppMiniProject.Entities;
using CredAppMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Services
{
    public interface ICardDetailService
    {
        IEnumerable<CardDetailModel> GetAllCardDetails(string userid);
        CardDetailModel GetById(int id);
        Task<CardDetailModel> AddCardDetails(CardDetailModel CardDetailsObj);
        CardDetailModel UpdateCardDetails(CardDetailModel updateCardDetails, int id);
        CardDetailModel DeleteCardDetails(int id);

        //Task<CardDetailModel> GetByUser(string useruserid); //added
        //object CardDetails(string userid);
    }
    public class CardDetailService : ICardDetailService
    {
        private readonly CardDetailsDal _CardDetailsDal;

        public CardDetailService(CardDetailsDal cardDetailsDal)
        {
            _CardDetailsDal = cardDetailsDal;
        }

        public async Task<CardDetailModel> AddCardDetails(CardDetailModel CardDetailsObj)
        {
            var obj = new CardDetail
            {
                CardDetailId = CardDetailsObj.CardDetailId,
                CardOwnerName = CardDetailsObj.CardOwnerName,
                CardNumber = CardDetailsObj.CardNumber,
                cvv = CardDetailsObj.cvv,
                ExpirationDate = CardDetailsObj.ExpirationDate,
                UserId=CardDetailsObj.UserId,
                Balace= CardDetailsObj.Balace,
                Bank = CardDetailsObj.Bank

            };

            var result = await _CardDetailsDal.AddCardDetails(obj);
            return new CardDetailModel
            {
                CardDetailId = CardDetailsObj.CardDetailId,
                CardOwnerName = CardDetailsObj.CardOwnerName,
                CardNumber = CardDetailsObj.CardNumber,
                cvv = CardDetailsObj.cvv,
                Balace = CardDetailsObj.Balace,
                Bank = CardDetailsObj.Bank
            };
        }

        public CardDetailModel DeleteCardDetails(int id)
        {
            var deletedata = _CardDetailsDal.DeleteCardDetails(id);
            return new CardDetailModel
            {
                CardDetailId = deletedata.CardDetailId,
                CardOwnerName = deletedata.CardOwnerName,
                CardNumber = deletedata.CardNumber,
                cvv = deletedata.cvv,
                Balace = deletedata.Balace,
                Bank = deletedata.Bank
            };
        }

        public IEnumerable<CardDetailModel> GetAllCardDetails(string userid)
        {
            var CardDetail = _CardDetailsDal.GetAllCardDetails(userid);
            return (from cardDetail in CardDetail
                    select new CardDetailModel
                    {
                        CardDetailId = cardDetail.CardDetailId,
                        CardOwnerName = cardDetail.CardOwnerName,
                        CardNumber = cardDetail.CardNumber,
                        cvv = cardDetail.cvv,
                        Balace = cardDetail.Balace,
                        Bank = cardDetail.Bank
                    }).ToList();
        }
      

        public CardDetailModel GetById(int id)
        {
            var obj = _CardDetailsDal.GetById(id);
            if (obj != null)
            {
                return new CardDetailModel
                {
                    CardDetailId = obj.CardDetailId,
                    CardOwnerName = obj.CardOwnerName,
                    CardNumber = obj.CardNumber,
                    cvv = obj.cvv,
                    Balace = obj.Balace,
                    Bank = obj.Bank


                };
            }
            else
            {
                return null;
            }
        }

        public CardDetailModel UpdateCardDetails(CardDetailModel updateCardDetails, int id)
        {
            var obj = new Entities.CardDetail
            {
                CardDetailId = updateCardDetails.CardDetailId,
                CardOwnerName = updateCardDetails.CardOwnerName,
                CardNumber = updateCardDetails.CardNumber,
                cvv = updateCardDetails.cvv,
                Balace = updateCardDetails.Balace,
                Bank = updateCardDetails.Bank,

            };
            var updateData = _CardDetailsDal.UpdateCardDetails(obj, id);
            return new CardDetailModel
            {
                CardDetailId = updateData.CardDetailId,
                CardOwnerName = updateData.CardOwnerName,
                CardNumber = updateData.CardNumber,
                cvv = updateData.cvv,
                Balace = updateData.Balace,
                Bank = updateData.Bank

            };
        }

        //object ICardDetailService.CardDetails(string userid)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
