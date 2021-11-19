namespace ServicoBanco.DomainService.Patterns
{
    public interface IGenericFactory<TEntity, TCommand> where TEntity : class where TCommand : class
    {
        TEntity Entidade { get; set; }
        TEntity Adicionar(TCommand command);
        TEntity Atualizar(TCommand command);
        TEntity Deletar(TCommand command);
    }
}
