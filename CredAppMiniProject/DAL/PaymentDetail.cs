using CredAppMiniProject.Data;
using CredAppMiniProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.DAL
{
    public interface IPaymentDetail
    {
        IEnumerable<PaymentDetail> GetPaymentDetails();
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

        public IEnumerable<PaymentDetail> GetPaymentDetails()
        {
           return _context.PaymentDetails.ToList();
        }
    }
}
