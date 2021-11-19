using AutoMapper;

namespace ServicoBanco.CrossCutting.Mappers
{
    public class GenericMapper<TModel, TCommand> where TModel : class where TCommand : class
    {
        private static MapperConfiguration Configurar()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TModel, TCommand>();
                cfg.CreateMap<TCommand, TModel>();
            });
        }

        public static TModel ComandoParaClasse(TCommand command)
        {
            return Configurar().CreateMapper().Map<TCommand, TModel>(command);
        }

        public static TCommand ClasseParaComando(TModel model)
        {
            return Configurar().CreateMapper().Map<TModel, TCommand>(model);
        }
    }
}
