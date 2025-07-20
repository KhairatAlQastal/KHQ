using KHQ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public interface ISubProductSrv
    {
        Task<IEnumerable<SubProductVM>> GetAllAsync();
        Task<SubProductVM?> GetByIdAsync(Guid id);
        Task<int> AddAsync(SubProductVM entity);
        Task<int> UpdateAsync(SubProductVM entity);
        Task<int> DeleteAsync(Guid id);
    }
}
