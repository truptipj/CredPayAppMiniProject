using CredAppMiniProject.Data;
using CredAppMiniProject.Entities;
using CredAppMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.DAL
{
    public interface IPaymentDetail
    {
        IEnumerable<PaymentDetailsModelInfo> GetPaymentDetails();
        PaymentDetail GetById(int id);
        Task<PaymentDetail> AddPaymentDetail(PaymentDetail PaymentDetailObj);
        PaymentDetail DeletePaymentDetail(int id);
    }
    public class PaymentDetailDal : IPaymentDetail
    {
        private readonly CredPayAppDbContext _context;

        public PaymentDetailDal(CredPayAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaymentDetail> AddPaymentDetail(PaymentDetail PaymentDetailObj)
        {
            var data = await _context.PaymentDetails.AddAsync(PaymentDetailObj);
            _context.SaveChanges();
            return data.Entity;
        }
        
       

        public PaymentDetail DeletePaymentDetail(int id)
        {
            var result = _context.PaymentDetails.Where(a => a.PaymentDetailId == id).FirstOrDefault();
            if (result != null)
            {
                _context.PaymentDetails.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }

    
        public PaymentDetail GetById(int id)
        {
            return _context.PaymentDetails.FirstOrDefault(i => i.PaymentDetailId == id);
        }

        public IEnumerable<PaymentDetailsModelInfo> GetPaymentDetails()
        {

           

            //return _context.PaymentDetails.ToList();
            var data = _context.PaymentDetails.Select(pd => new PaymentDetailsModelInfo
            {
                UserId = pd.UserId,
                AmountPaid = pd.Pay.AmountPaid,
                CardNumber = pd.CardDetail.CardNumber,
                Balance = pd.CardDetail.Balance,
                Bank = pd.CardDetail.Bank,
                ProductName = pd.Pay.ProductName,
                Category = pd.Pay.Category,
                Price = pd.Pay.Price,
                Status = pd.Status

            }).ToList();



            return data;

        }
    }
}
