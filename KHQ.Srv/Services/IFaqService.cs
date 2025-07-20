using KHQ.Domain.Entities;
using KHQ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public interface IFaqService
    {
        Task<IEnumerable<FaqVM>> GetAllAsync();
        Task<FaqVM?> GetByIdAsync(Guid id);
        Task<int> AddAsync(FaqVM entity);
        Task<int> UpdateAsync(FaqVM entity);
        Task<int> DeleteAsync(Guid id);
    }

}
