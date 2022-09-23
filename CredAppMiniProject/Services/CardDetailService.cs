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
        Task<CardDetailModel> AddCardDetail(CardDetailModel CardDetail);
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

        public async Task<CardDetailModel> AddCardDetail(CardDetailModel CardDetail)
        {
            var addCardDetail = new CardDetail
            {
                CardDetailId = CardDetail.CardDetailId,
                CardOwnerName = CardDetail.CardOwnerName,
                CardNumber = CardDetail.CardNumber,
                cvv = CardDetail.cvv,
                ExpirationDate = CardDetail.ExpirationDate,
                UserId = CardDetail.UserId,
                Balance = CardDetail.Balance,
                Bank = CardDetail.Bank

            };

            var addCard = await _CardDetailsDal.AddCardDetail(addCardDetail);
            return new CardDetailModel
            {
                CardDetailId = addCard.CardDetailId,
                CardOwnerName = addCard.CardOwnerName,
                CardNumber = addCard.CardNumber,
                cvv = addCard.cvv,
                Balance = addCard.Balance,
                Bank = addCard.Bank,
                ExpirationDate = addCard.ExpirationDate,
            };
        }

        public CardDetailModel DeleteCardDetail(int id)
        {
            var deleteCard = _CardDetailsDal.DeleteCardDetail(id);
            return new CardDetailModel
            {
                CardDetailId = deleteCard.CardDetailId,
                CardOwnerName = deleteCard.CardOwnerName,
                CardNumber = deleteCard.CardNumber,
                cvv = deleteCard.cvv,
                Balance = deleteCard.Balance,
                Bank = deleteCard.Bank,
                ExpirationDate = deleteCard.ExpirationDate,
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
                        Balance = cardDetail.Balance,
                        Bank = cardDetail.Bank,
                        ExpirationDate = cardDetail.ExpirationDate,
                    }).ToList();
        }


        public CardDetailModel GetById(int id)
        {
            var getCardById = _CardDetailsDal.GetById(id);
            if (getCardById != null)
            {
                return new CardDetailModel
                {
                    CardDetailId = getCardById.CardDetailId,
                    CardOwnerName = getCardById.CardOwnerName,
                    CardNumber = getCardById.CardNumber,
                    cvv = getCardById.cvv,
                    Balance = getCardById.Balance,
                    Bank = getCardById.Bank,
                    ExpirationDate = getCardById.ExpirationDate,

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
               // CardDetailId = updateCardDetails.CardDetailId,
                CardOwnerName = updateCardDetails.CardOwnerName,
                // CardNumber = updateCardDetails.CardNumber,
                // cvv = updateCardDetails.cvv,
                Balance = updateCardDetails.Balance,
               // Bank = updateCardDetails.Bank,
               ExpirationDate = updateCardDetails.ExpirationDate

            };
            var updateData = _CardDetailsDal.UpdateCardDetail(obj, id);
            return new CardDetailModel
            {
                CardDetailId = updateData.CardDetailId,
                CardOwnerName = updateData.CardOwnerName,
                CardNumber = updateData.CardNumber,
                cvv = updateData.cvv,
                Balance = updateData.Balance,
                Bank = updateData.Bank,
                ExpirationDate = updateData.ExpirationDate,

            };
        }
    }
}
