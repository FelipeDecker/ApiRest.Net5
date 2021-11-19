using ServicoBanco.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace ServicoBanco.DomainService.Expressions
{
    public static class LicencaExpression
    {
        public static Expression<Func<LicencaEntity, bool>> BuscarPorLicenca(Guid token)
        {
            return x => x.Id == token;
        }
    }
}
