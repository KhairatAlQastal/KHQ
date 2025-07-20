using KHQ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public interface IBrandSrv
    {
        Task<IEnumerable<BrandsVM>> GetAllAsync();
        Task<BrandsVM?> GetByIdAsync(Guid id);
        Task<int> AddAsync(BrandsVM entity);
        Task<int> UpdateAsync(BrandsVM entity);
        Task<int> DeleteAsync(Guid id);
    }
}
