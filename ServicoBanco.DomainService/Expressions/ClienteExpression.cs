using ServicoBanco.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ServicoBanco.DomainService.Expressions
{
    public static class ClienteExpression
    {
        public static Expression<Func<ClienteEntity, bool>> BuscarPorCodigoCliente(decimal codigoCliente)
        {
            return x => x.CodigoCliente == codigoCliente;
        }

        public static Expression<Func<ClienteEntity, dynamic>> BuscarPorUltimoCodigoCliente()
        {
            return x => x.CodigoCliente;
        }

        public static Expression<Func<ClienteEntity, bool>> BuscarPorCpf(decimal cpf)
        {
            return x => x.Cpf == cpf;
        }

        public static Expression<Func<ClienteEntity, bool>> BuscarPorCnpj(decimal cnpj)
        {
            return x => x.Cnpj == cnpj;
        }

        public static Expression<Func<ClienteEntity, bool>> BuscarPorAtivo()
        {
            return x => x.Usuario == 1 && x.Inativo == 0;
        }

        public static Expression<Func<ClienteEntity, bool>> BuscarPorRamal(decimal ramal)
        {
            return x => x.Ramal == ramal;
        }

        public static Expression<Func<ClienteEntity, bool>> BuscarPorNome(string nome)
        {
            return x => x.Nome.Contains(nome);
        }
    }
}
