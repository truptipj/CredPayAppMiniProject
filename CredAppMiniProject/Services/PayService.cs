using CredAppMiniProject.DAL;
using CredAppMiniProject.Entities;
using CredAppMiniProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.Services
{
    public interface IPayService
    {
        IEnumerable<PayModel> GetPay();
        PayModel GetById(int Id);
        Task<PayModel> AddPay(PayModel payObj);
        //PayModel UpdatePay(PayModel updatePay, int id);
        //PayModel DeletePay(int id);

    }
    public class PayService : IPayService
    {
        private readonly IPay _PayDal;
        public PayService(IPay payDal)
        {
            _PayDal = payDal;
        }

        public async Task<PayModel> AddPay(PayModel payObj)
        {
            var obj = new Pay
            {
                //foreignkey
                //CardDetail = payObj.CardDetail,
                ProductName = payObj.ProductName,
                AmountPaid = payObj.AmountPaid,
                MinDue = payObj.MinDue,
                Category = payObj.Category,
                CardType = payObj.CardType,
                CardDetailId = payObj.CardDetailId


            };

            var result = await _PayDal.AddPay(obj);
            return new PayModel
            {
                ProductName = result.ProductName,
                AmountPaid = result.AmountPaid,
                MinDue = result.MinDue,
                Category = result.Category,
                CardType = result.CardType,
                CardDetailId = result.CardDetailId

            };

        }

        //public PayModel DeletePay(int id)
        //{
        //    var deleteData = _PayDal.DeletePay(id);
        //    return new PayModel
        //    {
        //        PayId = deleteData.PayId,
        //        AmountPaid = deleteData.AmountPaid,
        //        MinDue = deleteData.MinDue,
        //    };
        //}

        public IEnumerable<PayModel> GetPay()
        {
            var paydata = _PayDal.GetPay();
            return (from payment in paydata
                    select new PayModel
                    {
                        PayId = payment.PayId,
                        AmountPaid = payment.AmountPaid,
                        MinDue = payment.MinDue,
                        ProductName = payment.ProductName,
                        Category = payment.Category,
                        CardType = payment.CardType,
                        CardDetailId = payment.CardDetailId
                    }).ToList();
        }

        public PayModel GetById(int id)
        {
            var paydata = _PayDal.GetById(id);
            if (paydata != null)
            {
                return new PayModel
                {
                    PayId = paydata.PayId,
                    AmountPaid = paydata.AmountPaid,
                    MinDue = paydata.MinDue,
                    ProductName = paydata.ProductName,
                    Category = paydata.Category,
                    CardType = paydata.CardType,
                    CardDetailId = paydata.CardDetailId
                };
            }
            else
            {
                return null;
            }
        }


        //public PayModel UpdatePay(PayModel updatePay, int id)
        //{
        //    var obj = new Pay
        //    {
        //        PayId = updatePay.PayId,
        //        AmountPaid = updatePay.AmountPaid,
        //        MinDue = updatePay.MinDue,

        //    };
        //    var updatedata = _PayDal.(obj, id);
        //    return new PayModel
        //    {
        //        PayId = updatedata.PayId,
        //        AmountPaid = updatedata.AmountPaid,
        //        MinDue = updatedata.MinDue,
        //    };

        // }
    }
}
