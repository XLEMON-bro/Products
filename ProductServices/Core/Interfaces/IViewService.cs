using DB.Models;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Interfaces
{
    public interface IViewService
    {
        public Task<bool> AddViewAsync(ViewModel view);

        public Task<bool> DeleteViewAsync(string id);

        public Task<ViewModel> GetViewByIdAsync(string id);

        public bool UpdateView(ViewModel view);

        public Task<IEnumerable<ViewModel>> GetAllViewsAsync();

        public Task<bool> AddViewsAsync(IEnumerable<ViewModel> views);
    }
}
