using KHQ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public interface IH_AboutUsService
    {
        Task<IEnumerable<H_AboutUsVM>> GetAllAsync();
        Task<H_AboutUsVM?> GetByIdAsync(Guid id);
        Task<int> AddAsync(H_AboutUsVM entity);
        Task<int> UpdateAsync(H_AboutUsVM entity);
        Task<int> DeleteAsync(Guid id);
    }
}
