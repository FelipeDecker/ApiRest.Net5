using ServicoBanco.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ServicoBanco.DomainService.Expressions
{
    public static class TelefoneClienteExpression
    {
        public static Expression<Func<TelefoneClienteEntity, bool>> BuscarPorCodigoCliente(decimal codigoCliente)
        {
            return x => x.CodigoCliente == codigoCliente;
        }

        public static Expression<Func<TelefoneClienteEntity, dynamic>> BuscarPorCodigoTelefone()
        {
            return x => x.CodigoContato;
        }

        public static Expression<Func<TelefoneClienteEntity, bool>> BuscarPorCodigoTelefone(decimal codigoCliente, decimal codigoContato)
        {
            return x => x.CodigoCliente == codigoCliente &&
                        x.CodigoContato == codigoContato;
        }

        public static Expression<Func<TelefoneClienteEntity, bool>> BuscarPorTelefone(decimal codigoCliente, decimal telefone)
        {
            return x => x.CodigoCliente == codigoCliente &&
                        x.Telefone == telefone;
        }

        public static Expression<Func<TelefoneClienteEntity, bool>> BuscarPorAtivo(decimal codigoCliente, bool ativo)
        {
            if (ativo)
            {
                return x => x.CodigoCliente == codigoCliente && x.Inativo == 1;
            } 
            else
            {
                return x => x.CodigoCliente == codigoCliente && x.Inativo == 0;
            }
        }

        public static Expression<Func<TelefoneClienteEntity, bool>> BuscarPorTipo(decimal codigoCliente, decimal tipo)
        {
            return x => x.CodigoCliente == codigoCliente && x.Tipo == tipo;
        }

        public static Expression<Func<TelefoneClienteEntity, bool>> BuscarPorEmail(decimal codigoCliente, string email)
        {
            return x => x.CodigoCliente == codigoCliente && x.Email.Contains(email);
        }
    }
}
