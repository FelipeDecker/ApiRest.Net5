using AutoMapper;
using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using System.Collections.Generic;

namespace ServicoBanco.CrossCutting.Mappers
{
    public class ExemploMapperEspecifico
    {
        private static MapperConfiguration ConfiguracaoCommandParaEntity()
        {
            return new MapperConfiguration(x => x.CreateMap<ClienteCommand, ClienteEntity>()
                .AfterMap((src, dest) => dest.CodigoCliente = src.CodigoCliente)
                .AfterMap((src, dest) => dest.Cnpj = src.Cnpj)
            );
        }

        private static MapperConfiguration ConfiguracaoEntityParaCommand()
        {
            return new MapperConfiguration(x => x.CreateMap<ClienteCommand, ClienteEntity>()
                .AfterMap((src, dest) => dest.CodigoCliente = src.CodigoCliente)
            );
        }

        public static ClienteEntity CommandParaEntity(ClienteCommand command)
        {
            return ConfiguracaoCommandParaEntity().CreateMapper().Map<ClienteCommand, ClienteEntity>(command);
        }

        public static ClienteCommand EntityParaCommand(ClienteEntity entity)
        {
            return ConfiguracaoEntityParaCommand().CreateMapper().Map<ClienteEntity, ClienteCommand>(entity);
        }

        public static List<ClienteEntity> ListaCommandParaEntity(List<ClienteCommand> command)
        {
            return ConfiguracaoCommandParaEntity().CreateMapper().Map< List<ClienteCommand>, List<ClienteEntity>>(command);
        }

        public static List<ClienteCommand> ListaEntityParaCommand(List<ClienteEntity> command)
        {
            return ConfiguracaoEntityParaCommand().CreateMapper().Map<List<ClienteEntity>, List<ClienteCommand>>(command);
        }
    }
}
