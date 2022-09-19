using CredAppMiniProject.Data;
using CredAppMiniProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.DAL
{
    public interface ICardDetail
    {

        IEnumerable<CardDetail> GetAllCardDetails(string userid);
        CardDetail GetById(int id);
        Task<CardDetail> AddCardDetail(CardDetail cardDetailsObj);
        CardDetail UpdateCardDetail(CardDetail updateCardDetails, int id);
        CardDetail DeleteCardDetail(int id);
    }
    public class CardDetailsDal : ICardDetail
    {
        private readonly CredPayAppDbContext _context;

        public CardDetailsDal(CredPayAppDbContext context)
        {
            _context = context;
        }

        public async Task<CardDetail> AddCardDetail(CardDetail cardDetailsObj)
        {
            var data = await  _context.AddAsync(cardDetailsObj);
             _context.SaveChangesAsync();
            return data.Entity;
        }

        public CardDetail DeleteCardDetail(int id)
        {
            var result = _context.CardDetails.Where(a => a.CardDetailId == id).FirstOrDefault();
            if (result != null)
            {
                _context.CardDetails.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

        public IEnumerable<CardDetail> GetAllCardDetails(string userid)
        {
            return _context.CardDetails.Where(x => x.UserId == userid).ToList();
        }

        public CardDetail GetById(int id)
        {
            return _context.CardDetails.FirstOrDefault(i => i.CardDetailId == id);
        }


        public CardDetail UpdateCardDetail(CardDetail updateCardDetails, int id)
        {
            var update = _context.CardDetails.Where(i => i.CardDetailId == id).ToList();
            foreach (var CardDetailsData in update)
            {
                if (CardDetailsData.CardDetailId == id)
                    CardDetailsData.CardOwnerName = updateCardDetails.CardOwnerName;
                //CardDetailsData.CardNumber = updateCardDetails.CardNumber;
                CardDetailsData.ExpirationDate = updateCardDetails.ExpirationDate;
               // CardDetailsData.cvv = updateCardDetails.cvv;
                CardDetailsData.Balance = updateCardDetails.Balance;
               // CardDetailsData.Bank = updateCardDetails.Bank;


                var updateddata = _context.CardDetails.Update(CardDetailsData);
                _context.SaveChanges();
                return updateddata.Entity;

            }
            return updateCardDetails;
        }

    }
}
