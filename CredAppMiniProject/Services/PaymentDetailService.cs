using CredAppMiniProject.DAL;
using CredAppMiniProject.Entities;
using CredAppMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Services
{
    public interface IPaymentDetailService
    {
        IEnumerable<PaymentDetailsModelInfo> GetPaymentDetails();
        PaymentDetailModel GetById(int id);
        Task<PaymentDetailModel> AddPaymentDetail(PaymentDetailModel PaymentDetailObj);
        PaymentDetailModel DeletePaymentDetail(int id);
    }
    public class PaymentDetailService : IPaymentDetailService
    {
        private readonly PaymentDetailDal _paymentDetailDal;

        public PaymentDetailService(PaymentDetailDal paymentDetailDal)
        {
            _paymentDetailDal = paymentDetailDal;
        }
        public async Task<PaymentDetailModel> AddPaymentDetail(PaymentDetailModel PaymentDetailObj)
        {

            var obj = new PaymentDetail
            {
                Date = PaymentDetailObj.Date,
                CardDetailId = PaymentDetailObj.CardDetailId,
                PayId = PaymentDetailObj.PayId,
                UserId = PaymentDetailObj.UserId,
                Status = PaymentDetailObj.Status


            };

            var result = await _paymentDetailDal.AddPaymentDetail(obj);
            return new PaymentDetailModel
            {
                Date = result.Date,
                CardDetailId = result.CardDetailId,
                PayId = result.PayId,
                UserId = PaymentDetailObj.UserId,
                Status = PaymentDetailObj.Status
            };
        }

        public PaymentDetailModel DeletePaymentDetail(int id)
        {
            var deletedata = _paymentDetailDal.DeletePaymentDetail(id);
            return new PaymentDetailModel
            {
                Date = deletedata.Date,
                CardDetailId = deletedata.CardDetailId,
                PayId = deletedata.PayId,
                UserId = deletedata.UserId,
                Status = deletedata.Status
            };
        }

        public PaymentDetailModel GetById(int id)
        {
            var paymentdata = _paymentDetailDal.GetById(id);
            if (paymentdata != null)
            {
                return new PaymentDetailModel
                {
                    Date = paymentdata.Date,
                    CardDetailId = paymentdata.CardDetailId,
                    PayId = paymentdata.PayId,
                    UserId = paymentdata.UserId,
                    Status = paymentdata.Status
                };
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<PaymentDetailsModelInfo> GetPaymentDetails()
        {
            var PaymentDetail = _paymentDetailDal.GetPaymentDetails();
            return PaymentDetail;
        }
    }
}
