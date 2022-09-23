using CredAppMiniProject.Data;
using CredAppMiniProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.DAL
{
    public interface IPay
    {
        IEnumerable<Pay> GetPay(string userid);
        Pay GetById(int Id);
        Task<Pay> AddPay(Pay pay);
        Pay UpdatePay(Pay updatePay, int id);


    }
    public class PayDal : IPay
    {
        private readonly CredPayAppDbContext _context;

        public PayDal(CredPayAppDbContext context)
        {
            _context = context;
        }


        public async Task<Pay> AddPay(Pay pay)
        {
            var data = await _context.Pay.AddAsync(pay);
            _context.SaveChanges();
            return data.Entity;
            //var transaction = from f in _context.CardDetails
            //                  join s in _context.Pay

            //                 on new { f1 = f.CardNumber, f2 = f.Bank }
            //                 equals new { f1 = s.Category, f2 = s.ProductName }
            //                  select new
            //                  {
            //                      UserId = f.UserId,
            //                      AmountPaid = s.AmountPaid,
            //                      CardNumber = f.CardNumber,
            //                      Bank = f.Bank,
            //                      Balance = f.Balance,
            //                      cvv = f.cvv,
            //                      ExpirationDate = f.ExpirationDate,
            //                      CardDetailId = f.CardDetailId,
            //                      ProductName = s.ProductName,
            //                      CardOwnerName = f.ExpirationDate,
            //                      Category = s.Category,
            //                      MinDue = s.MinDue,
            //                      Price = s.Price,
            //                      Status = s.Status
            //                  };
            //return transaction;
        }

        public IEnumerable<Pay> GetPay(string userid)
        {
            return _context.Pay.Where(x => x.UserId == userid).ToList();
        }

        public Pay GetById(int Id)
        {
            return _context.Pay.FirstOrDefault(i => i.PayId == Id);
        }
        public Pay UpdatePay(Pay updatePay, int id)
        {
            var update = _context.Pay.Where(a => a.PayId == id).ToList();
            foreach (var data in update)
            {
                if (data.PayId == id)
                {
                
                    data.AmountPaid = updatePay.AmountPaid;
                    data.MinDue = updatePay.MinDue;
                    data.ProductName = updatePay.ProductName;
                    data.Category = updatePay.Category;
                    data.CardDetailId = updatePay.CardDetailId;
                    data.Price = updatePay.Price;
                    data.UserId = updatePay.UserId;
                    data.Status = updatePay.Status;



                    var updatedData = _context.Pay.Update(data);
                    _context.SaveChanges();
                    return updatedData.Entity;
                }
            }
            return updatePay;

            //var transaction = from f in _context.CardDetails
            //                  join s in _context.Pay

            //                 on new { f1 = f.CardNumber, f2 = f.Bank }
            //                 equals new { f1 = s.Category, f2 = s.ProductName }
            //                  select new 
            //                  {
            //                      UserId = f.UserId,
            //                      AmountPaid = s.AmountPaid,
            //                      CardNumber = f.CardNumber,
            //                      Bank = f.Bank,
            //                      Balance = f.Balance,
            //                      cvv = f.cvv,
            //                      ExpirationDate = f.ExpirationDate,
            //                      CardDetailId = f.CardDetailId,
            //                      ProductName = s.ProductName,
            //                      CardOwnerName = f.ExpirationDate,
            //                      Category = s.Category,
            //                      MinDue = s.MinDue,
            //                      Price = s.Price,
            //                      Status = s.Status
            //                  };
            //_context.SaveChanges();
            //return transaction;

            // var update = _context.Pay.Where(a => a.PayId == id).ToList();


        }
    }
}
