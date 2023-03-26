using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface IViewRepository<T> : IRepository<T> where T : View
    {
        Task<View> GetViewByProductId(string productId);
    }
}
