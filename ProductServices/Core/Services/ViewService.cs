using AutoMapper;
using DB.Interfaces;
using DB.Models;
using ProductServices.Core.Interfaces;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductServices.Core.Services
{
    public class ViewService : IViewService
    {
        IRepository<View> _viewRepository;
        IMapper _mapper;
        public ViewService(IRepository<View> viewRepository, IMapper mapper)
        {
            _viewRepository = viewRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddViewAsync(ViewModel viewModel)
        {
            var view = _mapper.Map<View>(viewModel);

            return await _viewRepository.AddAsync(view);
        }

        public async Task<bool> AddViewsAsync(IEnumerable<ViewModel> viewsModel)
        {
            var viewList = _mapper.Map<List<View>>(viewsModel);

            return await _viewRepository.AddRangeAsync(viewList);
        }

        public async Task<bool> DeleteViewAsync(string id)
        {
            return await _viewRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ViewModel>> GetAllViewsAsync()
        {
            var views = await _viewRepository.GetAllAsync();

            return _mapper.Map<List<ViewModel>>(views);
        }

        public async Task<ViewModel> GetViewByIdAsync(string id)
        {
            var view = await _viewRepository.GetByIdAsync(id);

            return _mapper.Map<ViewModel>(view);
        }

        public bool UpdateView(ViewModel viewModel)
        {
            var view = _mapper.Map<View>(viewModel);

            return _viewRepository.Update(view);
        }
    }
}
