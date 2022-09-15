using CredAppMiniProject.DAL;
using CredAppMiniProject.Entities;
using CredAppMiniProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Services
{
    public interface ICardDetailService
    {
        IEnumerable<CardDetailModel> GetAllCardDetails(string userid);
        CardDetailModel GetById(int id);
        Task<CardDetailModel> AddCardDetail(CardDetailModel CardDetailsObj);
        CardDetailModel UpdateCardDetail(CardDetailModel updateCardDetails, int id);
        CardDetailModel DeleteCardDetail(int id);


    }
    public class CardDetailService : ICardDetailService
    {
        private readonly CardDetailsDal _CardDetailsDal;

        public CardDetailService(CardDetailsDal cardDetailsDal)
        {
            _CardDetailsDal = cardDetailsDal;
        }

        public async Task<CardDetailModel> AddCardDetail(CardDetailModel CardDetailsObj)
        {
            var obj = new CardDetail
            {
                CardDetailId = CardDetailsObj.CardDetailId,
                CardOwnerName = CardDetailsObj.CardOwnerName,
                CardNumber = CardDetailsObj.CardNumber,
                cvv = CardDetailsObj.cvv,
                ExpirationDate = CardDetailsObj.ExpirationDate,
                UserId = CardDetailsObj.UserId,
                Balace = CardDetailsObj.Balace,
                Bank = CardDetailsObj.Bank

            };

            var result = await _CardDetailsDal.AddCardDetail(obj);
            return new CardDetailModel
            {
                CardDetailId = result.CardDetailId,
                CardOwnerName = result.CardOwnerName,
                CardNumber = result.CardNumber,
                cvv = result.cvv,
                Balace = result.Balace,
                Bank = result.Bank
            };
        }

        public CardDetailModel DeleteCardDetail(int id)
        {
            var deletedata = _CardDetailsDal.DeleteCardDetail(id);
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

        public CardDetailModel UpdateCardDetail(CardDetailModel updateCardDetails, int id)
        {
            var obj = new CardDetail
            {
                CardDetailId = updateCardDetails.CardDetailId,
                CardOwnerName = updateCardDetails.CardOwnerName,
                CardNumber = updateCardDetails.CardNumber,
                cvv = updateCardDetails.cvv,
                Balace = updateCardDetails.Balace,
                Bank = updateCardDetails.Bank,

            };
            var updateData = _CardDetailsDal.UpdateCardDetail(obj, id);
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
    }
}
