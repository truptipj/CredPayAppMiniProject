using CredAppMiniProject.Data;
using CredAppMiniProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CredAppMiniProject.DAL
{
    public interface IPay
    {
        IEnumerable<Pay> GetPay();
        Pay GetById(int Id);
        Task<Pay> AddPay(Pay payObj);

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

        public IEnumerable<Pay> GetPay()
        {
            return _context.Pay.ToList();
        }

        public Pay GetById(int Id)
        {
            return _context.Pay.FirstOrDefault(i => i.PayId == Id);
        }
    }
}
