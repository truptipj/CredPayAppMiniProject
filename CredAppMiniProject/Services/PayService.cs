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
        IEnumerable<PayModel> GetPay(string UserId);
        PayModel GetById(int Id);
        Task<PayModel> AddPay(PayModel pay);
        PayModel UpdatePay(PayModel updatePay, int id);

    }
    public class PayService : IPayService
    {
        private readonly IPay _PayDal;
        public PayService(IPay payDal)
        {
            _PayDal = payDal;
        }

        public async Task<PayModel> AddPay(PayModel pay)
        {
            var addPay = new Pay
            {


                ProductName = pay.ProductName,
                AmountPaid = pay.AmountPaid,
                MinDue = pay.MinDue,
                Category = pay.Category,
                Price = pay.Price,
                CardDetailId = pay.CardDetailId,
                UserId = pay.UserId,
                Status = pay.Status,
                //CreatedDateTime = pay.CreatedDateTime,
                //ModifiedDateTime = pay.ModifiedDateTime;


        };

            var result = await _PayDal.AddPay(addPay);
            return new PayModel
            {
                ProductName = result.ProductName,
                AmountPaid = result.AmountPaid,
                MinDue = result.MinDue,
                Category = result.Category,
                CardDetailId = result.CardDetailId,
                Price = result.Price,
                UserId = result.UserId,
                Status = pay.Status,


            };

        }

        public IEnumerable<PayModel> GetPay(string userId)
        {
            var paydata = _PayDal.GetPay(userId);
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
                        UserId = payment.UserId,
                        Status = payment.Status,


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
                    UserId = paydata.UserId,
                    Status = paydata.Status,


                };
            }
            else
            {
                return null;
            }
        }

        public PayModel UpdatePay(PayModel updatePay, int id)
        {
            var obj = new Pay
            {
               UserId = updatePay.UserId,
                PayId = updatePay.PayId,
                AmountPaid = updatePay.AmountPaid,
                MinDue = updatePay.MinDue,
                ProductName = updatePay.ProductName,
                Category = updatePay.Category,
                CardDetailId = updatePay.CardDetailId,
                Price = updatePay.Price,
                Status = updatePay.Status,





            };
            var updateData = _PayDal.UpdatePay(obj, id);
            return new PayModel
            {
                PayId = updateData.PayId,
                AmountPaid = updateData.AmountPaid,
                MinDue = updateData.MinDue,
                ProductName = updateData.ProductName,
                Category = updateData.Category,
                CardDetailId = updateData.CardDetailId,
                Price = updateData.Price,
                Status = updateData.Status,
                UserId = updatePay.UserId,

            };
        }
    }
}
