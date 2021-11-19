using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServicoBanco.DomainService.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task AdicionarAsync(T entity);

        Task AtualizarAsync(T entity);

        Task DeletarAsync(T entity);

        Task<T> BuscarPrimeiroAsync(Expression<Func<T, bool>> predicate = null);

        Task<ICollection<T>> BuscarTodosAsync(Expression<Func<T, bool>> predicate = null);

        Task<dynamic> BuscarUltimoCodigoAsync(Expression<Func<T, dynamic>> predicate, Expression<Func<T, bool>> predicate2 = null);
    }
}
