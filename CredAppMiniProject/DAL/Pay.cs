using CredAppMiniProject.Data;
using CredAppMiniProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.DAL
{
    public interface IPay
    {
        IEnumerable<Pay>GetPay();
        Pay GetById(int Id);
        Task<Pay> AddPay(Pay payObj);
        // Pay UpdatePay(Pay updatePay, int id);
        //Entities.Pay DeletePay(int id);
       
    }
    public class PayDal : IPay
    {
        private readonly CredPayAppDbContext _context;

        public PayDal(CredPayAppDbContext context)
        {
            _context = context;
        }


        public async Task<Pay> AddPay(Pay payObj)
        {
            var data = await _context.Pay.AddAsync(payObj);
            _context.SaveChanges();
            return data.Entity;
        }

        //public Entities.Pay DeletePay(int id)
        //{
        //    var result = _context.Pay.Where(a => a.PayId == id).FirstOrDefault();
        //    if (result != null)
        //    {
        //        _context.Pay.Remove(result);
        //        _context.SaveChanges();
        //        return result;
        //    }
        //    return null;
        //}

        public IEnumerable<Pay> GetPay()
        {
            return _context.Pay.ToList();
        }

        public Pay GetById(int Id)
        {
            return _context.Pay.FirstOrDefault(i => i.PayId == Id);
        }

        //public Entities.Pay UpdatePay(Entities.Pay updatePay, int id)
        //{
        //    var update = _context.Pay.Where(i => i.PayId == id).ToList();
        //    foreach (var payData in update)
        //    {
        //        if (payData.PayId == id)
        //        {
        //            payData.CardDetail = updatePay.CardDetail;
        //            payData.AmountPaid = updatePay.AmountPaid;
        //            payData.MinDue = updatePay.MinDue;


        //            var updateddata = _context.Pay.Update(payData);
        //            _context.SaveChanges();
        //            return updateddata.Entity;
        //        }
        //    }
        //    return updatePay;
        //}
    }
}
