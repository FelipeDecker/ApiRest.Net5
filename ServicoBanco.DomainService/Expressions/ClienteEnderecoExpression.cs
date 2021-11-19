using ServicoBanco.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ServicoBanco.DomainService.Expressions
{
    public static class ClienteEnderecoExpression
    {
        public static Expression<Func<ClienteEnderecoEntity, bool>> BuscarPorCodigoCliente(decimal codigoCliente)
        {
            return x => x.CodigoCliente == codigoCliente;
        }

        public static Expression<Func<ClienteEnderecoEntity, dynamic>> BuscarPorCodigoEndereco()
        {
            return x => x.CodigoEndereco;
        }

        public static Expression<Func<ClienteEnderecoEntity, bool>> BuscarPorEndereco(decimal codigoCliente, decimal codigoEndereco)
        {
            return x => x.CodigoCliente == codigoCliente &&
                x.CodigoEndereco == codigoEndereco;
        }
    }
}
