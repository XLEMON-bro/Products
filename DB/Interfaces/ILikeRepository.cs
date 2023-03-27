using DB.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DB.Interfaces
{
    public interface ILikeRepository<T> : IRepository<T> where T : Like
    {
        Task<Like> GetLikeByProductId(string productId);
    }
}
