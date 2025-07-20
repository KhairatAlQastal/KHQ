using KHQ.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHQ.Srv.Services
{
    public interface ISliderSrv
    {
        Task<IEnumerable<SliderVM>> GetAllAsync();
        Task<SliderVM?> GetByIdAsync(Guid id);
        Task<int> AddAsync(SliderVM entity);
        Task<int> UpdateAsync(SliderVM entity);
        Task<int> DeleteAsync(Guid id);
    }
}
