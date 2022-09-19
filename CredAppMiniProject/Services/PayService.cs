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


                ProductName = payObj.ProductName,
                AmountPaid = payObj.AmountPaid,
                MinDue = payObj.MinDue,
                Category = payObj.Category,
                Price = payObj.Price,
                CardDetailId = payObj.CardDetailId


            };

            var result = await _PayDal.AddPay(obj);
            return new PayModel
            {
                ProductName = result.ProductName,
                AmountPaid = result.AmountPaid,
                MinDue = result.MinDue,
                Category = result.Category,
                CardDetailId = result.CardDetailId,
                Price = payObj.Price,

            };

        }

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
                        CardDetailId = payment.CardDetailId,
                        Price = payment.Price,
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
                    CardDetailId = paydata.CardDetailId,
                    Price = paydata.Price,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
