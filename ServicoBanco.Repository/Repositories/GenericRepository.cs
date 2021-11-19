using Microsoft.EntityFrameworkCore;
using ServicoBanco.DomainService.IRepositories;
using ServicoBanco.Repository.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        //Criar metodo para alterar String de conexão
        // ver para futurament eimplementar paginação


        // Se os erros do repositorio estiverem estourando certinho la no middlware 
        // pode apagar as linhas comentadas dos blocos try catch

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AdicionarAsync(T entity)
        {
            //try
            //{
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    if (ex.InnerException.ToString().Contains("Violation of PRIMARY KEY"))
            //    {
            //        throw new Exception("Chave primaria esta repetida");
            //    }
            //    if (ex.InnerException.ToString().Contains("Arithmetic overflow error converting numeric to data type numeric."))
            //    {
            //        throw new Exception("Um ou mais campos podem estar recebendo um valor maior que o limite (erro para campos numericos)");
            //    }
            //    if (ex.InnerException.ToString().Contains("String or binary data would be truncated."))
            //    {
            //        throw new Exception("Um ou mais campos podem estar recebendo um valor maior que o limite (erro para campos string)");
            //    }

            //    throw new Exception("Erro: " + ex.Message + " --- Mensagem para o programador: " + ex.InnerException + " - Banco de Dados.");
            //}
        }

        public async Task AtualizarAsync(T entity)
        {
            //try
            //{
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    if (ex.InnerException.ToString().Contains("Violation of PRIMARY KEY"))
            //    {
            //        throw new Exception("Chave primaria esta repetida");
            //    }
            //    if (ex.InnerException.ToString().Contains("Arithmetic overflow error converting numeric to data type numeric."))
            //    {
            //        throw new Exception("Um ou mais campos podem estar recebendo um valor maior que o limite (erro para campos numericos)");
            //    }
            //    if (ex.InnerException.ToString().Contains("String or binary data would be truncated."))
            //    {
            //        throw new Exception("Um ou mais campos podem estar recebendo um valor maior que o limite (erro para campos string)");
            //    }

            //    throw new Exception("Erro: " + ex.Message + " --- Mensagem para o programador: " + ex.InnerException + " - Banco de Dados.");
            //}
        }

        public async Task DeletarAsync(T entity)
        {
            //try
            //{
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Erro: " + ex.Message + " --- Mensagem para o programador: " + ex.InnerException + " - Banco de Dados.");
            //}
        }

        public async Task<T> BuscarPrimeiroAsync(Expression<Func<T, bool>> predicate = null)
        {
            //try
            //{
                return await _dbSet.FirstOrDefaultAsync(predicate);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Erro: " + ex.Message + " --- Mensagem para o programador: " + ex.InnerException + " - Banco de Dados.");
            //}
        }

        public async Task<ICollection<T>> BuscarTodosAsync(Expression<Func<T, bool>> predicate = null)
        {
            //try
            //{
                if (predicate != null)
                {
                    return await _dbSet.Where(predicate).ToListAsync();
                }

                return await _dbSet.ToListAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Erro: " + ex.Message + " --- Mensagem para o programador: " + ex.InnerException + " - Banco de Dados.");
            //}
        }

        /// <summary>
        /// Primeiro parametro é uma referencia de qual calpo buscar o max. Segundo parametro serve como filtro de procura
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="predicateFilter"></param>
        /// <returns></returns>
        public async Task<dynamic> BuscarUltimoCodigoAsync(Expression<Func<T, dynamic>> predicate, Expression<Func<T, bool>> predicateFilter = null)
        {
            //try
            //{
                if (predicateFilter != null)
                {
                    IQueryable<T> todosT = _dbSet.Where(predicateFilter);
                    dynamic maximoT = todosT.MaxAsync(predicate);
                    dynamic resultado = maximoT.Result;

                    if (resultado == null)
                    {
                        return 0;
                    }
                    else
                    {
                        return resultado;
                    }
                }
                else
                {
                    return await _dbSet.MaxAsync(predicate);
                }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Erro: " + ex.Message + " --- Mensagem para o programador: " + ex.InnerException + " - Banco de Dados.");
            //}
        }
    }
}
