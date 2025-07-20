using KHQ.Domain.Entities;
using KHQ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public interface ICategorySrv
    {
        Task<IEnumerable<CategoryVM>> GetAllAsync();
        Task<CategoryVM?> GetByIdAsync(Guid id);
        Task<int> AddAsync(CategoryVM entity);
        Task<int> UpdateAsync(CategoryVM entity);
        Task<int> DeleteAsync(Guid id);
    }
}
