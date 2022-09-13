using CredAppMiniProject.Data;
using CredAppMiniProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.DAL
{
    public interface PaymentDetail
    {
        IEnumerable<Entities.PaymentDetail> GetPaymentDetails();
        Entities.PaymentDetail GetById(int Id);
        Task<Entities.PaymentDetail> AddPaymentDetail(Entities.PaymentDetail PaymentDetailObj);
        // PaymentDetails updatePaymentDetail(PaymentDetails updatePaymentDetail, int Id);
        Entities.PaymentDetail DeletePaymentDetail(int Id);
    }
    public class PaymentDetailDal : PaymentDetail
    {
        private readonly CredPayAppDbContext _context;

        public PaymentDetailDal(CredPayAppDbContext context)
        {
            _context = context;
        }

        public async Task<Entities.PaymentDetail> AddPaymentDetail(Entities.PaymentDetail PaymentDetailObj)
        {
            var data = await _context.PaymentDetails.AddAsync(PaymentDetailObj);
            _context.SaveChanges();
            return data.Entity;
        }
        public Entities.PaymentDetail DeletePaymentDetail(int Id)
        {
            var result = _context.PaymentDetails.Where(a => a.PaymentDetailId == Id).FirstOrDefault();
            if (result != null)
            {
                _context.PaymentDetails.Remove(result);
                _context.SaveChanges();
                return result;
            }
            return null;
        }
        public IEnumerable<Entities.PaymentDetail> GetPaymentDetails()
        {
            return _context.PaymentDetails.ToList();
        }

        public Entities.PaymentDetail GetById(int Id)
        {
            return _context.PaymentDetails.FirstOrDefault(i => i.PaymentDetailId == Id);
        }

        public Entities.PaymentDetail UpdatePaymentDetail(Entities.PaymentDetail updatePaymentDetail, int Id)
        {
            var update = _context.PaymentDetails.Where(i => i.PaymentDetailId == Id).ToList();
            foreach (var PaymentDetailData in update)
            {
                if (PaymentDetailData.PaymentDetailId == Id)

                    PaymentDetailData.CardNumber = updatePaymentDetail.CardNumber;
              

                var updateddata = _context.PaymentDetails.Update(PaymentDetailData);
                _context.SaveChanges();
                return updateddata.Entity;

            }
            return updatePaymentDetail;
        }
    }
}
