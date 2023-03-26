using AutoMapper;
using DB.Interfaces;
using DB.Models;
using ProductServices.Core.Interfaces;
using ProductServices.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProductServices.Helpers;

namespace ProductServices.Core.Services
{
    public class ViewService : IViewService
    {
        IViewRepository<View> _viewRepository;
        IMapper _mapper;
        public ViewService(IViewRepository<View> viewRepository, IMapper mapper)
        {
            _viewRepository = viewRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddViewAsync(ViewModel viewModel)
        {
            var view = _mapper.Map<View>(viewModel);

            var guid = GuidHelper.GenerateGuid();

            while (await GetViewByIdAsync(guid) != null)
            {
                guid = GuidHelper.GenerateGuid();
            }

            view.Id = guid;

            return await _viewRepository.AddAsync(view);
        }

        public async Task<bool> AddViewsAsync(IEnumerable<ViewModel> viewsModel)
        {
            var viewList = _mapper.Map<List<View>>(viewsModel);

            var guid = GuidHelper.GenerateGuid();

            foreach (var view in viewList)
            {
                while (await GetViewByIdAsync(guid) != null)
                {
                    guid = GuidHelper.GenerateGuid();
                }

                view.Id = guid;
            }

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

            if (view == null)
                return null;

            return _mapper.Map<ViewModel>(view);
        }

        public async Task<bool> UpdateView(ViewModel viewModel, string id)
        {
            var view = await _viewRepository.GetByIdAsync(id);

            if (view == null)
            {
                return false;
            }

            view.ProductId = viewModel.ProductId;
            view.TodayViews = viewModel.TodayViews;
            view.TotalViews = viewModel.TotalViews;

            return await _viewRepository.Update(view);
        }

        public async Task<ViewModel> GetViewByProductId(string productId)
        {
            var view = await _viewRepository.GetViewByProductId(productId);

            if(view == null)
            {
                return null;
            }

            return _mapper.Map<ViewModel>(view);
        }
    }
}
