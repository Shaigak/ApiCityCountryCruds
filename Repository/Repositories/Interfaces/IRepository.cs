using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T>where T : BaseEntity
    {
        //Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int? id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task Delete(T entity);

        Task SoftDeleteAsync(int? id);

        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> expression=null);
    }
}
