using CredAppMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Services
{
    public interface IPaymentDetailService
    {
        IEnumerable<PaymentDetailModel> GetPaymentDetails();
        PaymentDetailModel GetById(int Id);
        Task<PaymentDetailModel> AddPaymentDetail(PaymentDetailModel PaymentDetailObj);
        // PaymentDetailModel updatePaymentDetail(PaymentDetailModel updatePaymentDetail, int Id);
        PaymentDetailModel DeletePaymentDetail(int Id);
    }
    public class PaymentDetailService : IPaymentDetailService
    {
        public Task<PaymentDetailModel> AddPaymentDetail(PaymentDetailModel PaymentDetailObj)
        {
            throw new NotImplementedException();
        }

        public PaymentDetailModel DeletePaymentDetail(int Id)
        {
            throw new NotImplementedException();
        }

        public PaymentDetailModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentDetailModel> GetPaymentDetails()
        {
            throw new NotImplementedException();
        }
    }
}
