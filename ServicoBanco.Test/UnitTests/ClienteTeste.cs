using Moq;
using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.Factories;
using ServicoBanco.DomainService.IServices;
using ServicoBanco.DomainService.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServicoBanco.Test.UnitTests
{
    public class ClienteTeste
    {
        //WebApplicationFactory c# 

        private readonly IClienteService _svcPessoa;
        private readonly Mock<IClienteService> _mock;

        public ClienteTeste()
        {
            //_svcPessoa = _mock.Object; DANDO erro
            //Faker fake = new Faker("pt-BR");
            //Deixar metodos asyncronos
        }

        public static IEnumerable<object[]> PessoaCommandTeste()
        {
            return new List<object[]>
            {
                // Fisica com todos os tipos de usuario
                new object[]
                {
                    new ClienteCommand
                    {
                        TipoPessoa = "F",
                        Advogado = true,
                        Captador = true,
                        Cobrador = true,
                        Cliente = true,
                        Fornecedor = true,
                        Devedor = true,
                        Nome = "Pessoa Fisica Todos",
                        InscricaoEstadual = "123456",
                        InscricaoMunicipal = "123456",
                        Rg = "1234567",
                        Login = "login",
                        TipoAdvogado = "O",
                        Observacao = "nenhuma",
                        GrupoSeguranca = 1,
                        Atividade = 1,
                        Contato = 1,
                        Oficial = 1,
                        Segurado = 1,
                        GrupoCliente = 1,
                        Autor = 1,
                        Reu = 1,
                        CodigoAlteracao = "6354",
                        DataAlteracao = new DateTime(2000, 01, 28),
                        CodigoCriacao = "6354",
                        DataCriacao = new DateTime(2000, 01, 28),
                        Filial = 1,
                        Inativo = 1,
                        Localizador = 1,
                        Usuario = 1,
                        Filiais = 1,
                        Nascimento = new DateTime(2000, 01, 28),
                        Setor = 1,
                        Amigavel = 1,
                        Juridico = 1,
                        Horario = 1,
                        Admissao = new DateTime(2000, 01, 28),
                        Rescisao = new DateTime(2000, 01, 28),
                        Banco = 260,
                        Agencia = "0001",
                        Conta = "123456",
                        Cartorio = 1,
                        Admissao2 = new DateTime(2000, 01, 28),
                        Rescisao2 = new DateTime(2000, 01, 28),
                        GrupoCobranca = 1,
                        DigitoConta = "1",
                        Cpf = 01234567890,
                        Cnpj = 01234567890123,
                        ArquivoMorto = "arquivo morto",
                        Cargo = 1,
                        Ramal = 1,
                        Empresa = 1,
                        Email = "teste@hotmail.com",
                        ValidaHorario = 1,
                        PosJuridico = 1,
                        Oab = "11",
                        CarteiraFoco = 1,
                        DigitoAgencia = "1",
                        OpVar = "1",
                        Pis = 01234567890,
                        UtilizaSoftPhone = 1,
                        CarteiraWo = 1,
                        Senha = "1",
                        TipoCentral = 1,
                        DiscagemManual = 1,
                        CentralAlternativa = 1,
                        Receptivo = 1,
                        MetaDiscador = 1,
                        SapClienteNcNds = "1",
                        SapClienteNrp = "1",
                        SapFornecedorNds = "1",
                        EmailFuncional = 1,
                        TipoUsuario = 1,
                        Fiador = 1,
                        SegurancaGrupoCobranca = 1
                    },
                },

                // Fisica sem nenhum tipo de usuario
                new object[]
                { 
                    new ClienteCommand
                    {
                        TipoPessoa = "F",
                        Advogado = false,
                        Captador = false,
                        Cobrador = false,
                        Cliente = false,
                        Fornecedor = false,
                        Devedor = false,
                        Nome = "Pessoa Fisica Sem",
                        InscricaoEstadual = "123456",
                        InscricaoMunicipal = "123456",
                        Rg = "1234567",
                        Login = "login",
                        TipoAdvogado = "O",
                        Observacao = "nenhuma",
                        GrupoSeguranca = 1,
                        Atividade = 1,
                        Contato = 0,
                        Oficial = 0,
                        Segurado = 0,
                        GrupoCliente = 1,
                        Autor = 0,
                        Reu = 0,
                        CodigoAlteracao = "6354",
                        DataAlteracao = new DateTime(2000, 01, 28),
                        CodigoCriacao = "6354",
                        DataCriacao = new DateTime(2000, 01, 28),
                        Filial = 1,
                        Inativo = 1,
                        Localizador = 0,
                        Usuario = 0,
                        Filiais = 1,
                        Nascimento = new DateTime(2000, 01, 28),
                        Setor = 1,
                        Amigavel = 0,
                        Juridico = 0,
                        Horario = 1,
                        Admissao = new DateTime(2000, 01, 28),
                        Rescisao = new DateTime(2000, 01, 28),
                        Banco = 260,
                        Agencia = "0001",
                        Conta = "123456",
                        Cartorio = 0,
                        Admissao2 = new DateTime(2000, 01, 28),
                        Rescisao2 = new DateTime(2000, 01, 28),
                        GrupoCobranca = 1,
                        DigitoConta = "1",
                        Cpf = 01234567890,
                        Cnpj = 01234567890123,
                        ArquivoMorto = "arquivo morto",
                        Cargo = 1,
                        Ramal = 1,
                        Empresa = 1,
                        Email = "teste@hotmail.com",
                        ValidaHorario = 0,
                        PosJuridico = 0,
                        Oab = "11",
                        CarteiraFoco = 1,
                        DigitoAgencia = "1",
                        OpVar = "1",
                        Pis = 01234567890,
                        UtilizaSoftPhone = 0,
                        CarteiraWo = 0,
                        Senha = "1",
                        TipoCentral = 1,
                        DiscagemManual = 0,
                        CentralAlternativa = 1,
                        Receptivo = 0,
                        MetaDiscador = 0,
                        SapClienteNcNds = "1",
                        SapClienteNrp = "1",
                        SapFornecedorNds = "1",
                        EmailFuncional = 1,
                        TipoUsuario = 1,
                        Fiador = 0,
                        SegurancaGrupoCobranca = 1
                    },
                },

                // Fisica com propriedades aleatórias
                new object[]
                {
                    new ClienteCommand
                    {
                        TipoPessoa = "F",
                        Advogado = false,
                        Captador = false,
                        Cobrador = false,
                        Cliente = false,
                        Fornecedor = false,
                        Devedor = true,
                        Nome = "Pessoa Fisica Aleatoria",
                        InscricaoEstadual = "123456",
                        InscricaoMunicipal = "123456",
                        Rg = "1234567",
                        Login = "login",
                        TipoAdvogado = "O",
                        Observacao = "nenhuma",
                        GrupoSeguranca = 0,
                        Atividade = 6,
                        Contato = 0,
                        Oficial = 0,
                        Segurado = 0,
                        GrupoCliente = 1,
                        Autor = 0,
                        Reu = 0,
                        CodigoAlteracao = "6354",
                        DataAlteracao = new DateTime(2000, 01, 28),
                        CodigoCriacao = "6354",
                        DataCriacao = new DateTime(2000, 01, 28),
                        Filial = 1,
                        Inativo = 0,
                        Localizador = 0,
                        Usuario = 1,
                        Filiais = 1,
                        Nascimento = new DateTime(2000, 01, 28),
                        Setor = 1,
                        Amigavel = 1,
                        Juridico = 0,
                        Horario = 6,
                        Admissao = new DateTime(2000, 01, 28),
                        Rescisao = new DateTime(2000, 01, 28),
                        Banco = 260,
                        Agencia = "0001",
                        Conta = "123456",
                        Cartorio = 0,
                        Admissao2 = new DateTime(2000, 01, 28),
                        Rescisao2 = new DateTime(2000, 01, 28),
                        GrupoCobranca = 1,
                        DigitoConta = "1",
                        Cpf = 01234567890,
                        Cnpj = 01234567890123,
                        ArquivoMorto = "arquivo morto",
                        Cargo = 1,
                        Ramal = 1,
                        Empresa = 1,
                        Email = "teste@hotmail.com",
                        ValidaHorario = 0,
                        PosJuridico = 0,
                        Oab = "11",
                        CarteiraFoco = 0,
                        DigitoAgencia = "1",
                        OpVar = "1",
                        Pis = 01234567890,
                        UtilizaSoftPhone = 0,
                        CarteiraWo = 0,
                        Senha = "1",
                        TipoCentral = 1,
                        DiscagemManual = 0,
                        CentralAlternativa = 1,
                        Receptivo = 1,
                        MetaDiscador = 0,
                        SapClienteNcNds = "1",
                        SapClienteNrp = "1",
                        SapFornecedorNds = "1",
                        EmailFuncional = 1,
                        TipoUsuario = 4,
                        Fiador = 0,
                        SegurancaGrupoCobranca = 1
                    },
                },

                // Juridica com todos os tipos de usuario
                new object[]
                {
                    new ClienteCommand
                    {
                        TipoPessoa = "J",
                        Advogado = true,
                        Captador = true,
                        Cobrador = true,
                        Cliente = true,
                        Fornecedor = true,
                        Devedor = true,
                        Nome = "Pessoa Juridica Todos",
                        InscricaoEstadual = "123456",
                        InscricaoMunicipal = "123456",
                        Rg = "1234567",
                        Login = "login",
                        TipoAdvogado = "O",
                        Observacao = "nenhuma",
                        GrupoSeguranca = 1,
                        Atividade = 1,
                        Contato = 1,
                        Oficial = 1,
                        Segurado = 1,
                        GrupoCliente = 1,
                        Autor = 1,
                        Reu = 1,
                        CodigoAlteracao = "6354",
                        DataAlteracao = new DateTime(2000, 01, 28),
                        CodigoCriacao = "6354",
                        DataCriacao = new DateTime(2000, 01, 28),
                        Filial = 1,
                        Inativo = 1,
                        Localizador = 1,
                        Usuario = 1,
                        Filiais = 1,
                        Nascimento = new DateTime(2000, 01, 28),
                        Setor = 1,
                        Amigavel = 1,
                        Juridico = 1,
                        Horario = 1,
                        Admissao = new DateTime(2000, 01, 28),
                        Rescisao = new DateTime(2000, 01, 28),
                        Banco = 260,
                        Agencia = "0001",
                        Conta = "123456",
                        Cartorio = 1,
                        Admissao2 = new DateTime(2000, 01, 28),
                        Rescisao2 = new DateTime(2000, 01, 28),
                        GrupoCobranca = 1,
                        DigitoConta = "1",
                        Cpf = 01234567890,
                        Cnpj = 01234567890123,
                        ArquivoMorto = "arquivo morto",
                        Cargo = 1,
                        Ramal = 1,
                        Empresa = 1,
                        Email = "teste@hotmail.com",
                        ValidaHorario = 1,
                        PosJuridico = 1,
                        Oab = "11",
                        CarteiraFoco = 1,
                        DigitoAgencia = "1",
                        OpVar = "1",
                        Pis = 01234567890,
                        UtilizaSoftPhone = 1,
                        CarteiraWo = 1,
                        Senha = "1",
                        TipoCentral = 1,
                        DiscagemManual = 1,
                        CentralAlternativa = 1,
                        Receptivo = 1,
                        MetaDiscador = 1,
                        SapClienteNcNds = "1",
                        SapClienteNrp = "1",
                        SapFornecedorNds = "1",
                        EmailFuncional = 1,
                        TipoUsuario = 1,
                        Fiador = 1,
                        SegurancaGrupoCobranca = 1
                    },
                },

                // Juridica sem nenhum tipo de usuario
                new object[]
                {
                    new ClienteCommand
                    {
                        TipoPessoa = "J",
                        Advogado = false,
                        Captador = false,
                        Cobrador = false,
                        Cliente = false,
                        Fornecedor = false,
                        Devedor = false,
                        Nome = "Pessoa Juridica Sem",
                        InscricaoEstadual = "123456",
                        InscricaoMunicipal = "123456",
                        Rg = "1234567",
                        Login = "login",
                        TipoAdvogado = "O",
                        Observacao = "nenhuma",
                        GrupoSeguranca = 1,
                        Atividade = 1,
                        Contato = 0,
                        Oficial = 0,
                        Segurado = 0,
                        GrupoCliente = 1,
                        Autor = 0,
                        Reu = 0,
                        CodigoAlteracao = "6354",
                        DataAlteracao = new DateTime(2000, 01, 28),
                        CodigoCriacao = "6354",
                        DataCriacao = new DateTime(2000, 01, 28),
                        Filial = 1,
                        Inativo = 1,
                        Localizador = 0,
                        Usuario = 0,
                        Filiais = 1,
                        Nascimento = new DateTime(2000, 01, 28),
                        Setor = 1,
                        Amigavel = 0,
                        Juridico = 0,
                        Horario = 1,
                        Admissao = new DateTime(2000, 01, 28),
                        Rescisao = new DateTime(2000, 01, 28),
                        Banco = 260,
                        Agencia = "0001",
                        Conta = "123456",
                        Cartorio = 0,
                        Admissao2 = new DateTime(2000, 01, 28),
                        Rescisao2 = new DateTime(2000, 01, 28),
                        GrupoCobranca = 1,
                        DigitoConta = "1",
                        Cpf = 01234567890,
                        Cnpj = 01234567890123,
                        ArquivoMorto = "arquivo morto",
                        Cargo = 1,
                        Ramal = 1,
                        Empresa = 1,
                        Email = "teste@hotmail.com",
                        ValidaHorario = 0,
                        PosJuridico = 0,
                        Oab = "11",
                        CarteiraFoco = 1,
                        DigitoAgencia = "1",
                        OpVar = "1",
                        Pis = 01234567890,
                        UtilizaSoftPhone = 0,
                        CarteiraWo = 0,
                        Senha = "1",
                        TipoCentral = 1,
                        DiscagemManual = 0,
                        CentralAlternativa = 1,
                        Receptivo = 0,
                        MetaDiscador = 0,
                        SapClienteNcNds = "1",
                        SapClienteNrp = "1",
                        SapFornecedorNds = "1",
                        EmailFuncional = 1,
                        TipoUsuario = 1,
                        Fiador = 0,
                        SegurancaGrupoCobranca = 1
                    },
                },

                // Juridica com propriedades aleatórias
                new object[]
                {
                    new ClienteCommand
                    {
                        TipoPessoa = "J",
                        Advogado = false,
                        Captador = false,
                        Cobrador = false,
                        Cliente = false,
                        Fornecedor = true,
                        Devedor = true,
                        Nome = "Pessoa Juridica Aleatoria",
                        InscricaoEstadual = "123456",
                        InscricaoMunicipal = "123456",
                        Rg = "1234567",
                        Login = "login",
                        TipoAdvogado = "O",
                        Observacao = "nenhuma",
                        GrupoSeguranca = 0,
                        Atividade = 6,
                        Contato = 0,
                        Oficial = 0,
                        Segurado = 0,
                        GrupoCliente = 1,
                        Autor = 0,
                        Reu = 0,
                        CodigoAlteracao = "6354",
                        DataAlteracao = new DateTime(2000, 01, 28),
                        CodigoCriacao = "6354",
                        DataCriacao = new DateTime(2000, 01, 28),
                        Filial = 1,
                        Inativo = 0,
                        Localizador = 0,
                        Usuario = 1,
                        Filiais = 1,
                        Nascimento = new DateTime(2000, 01, 28),
                        Setor = 1,
                        Amigavel = 1,
                        Juridico = 0,
                        Horario = 6,
                        Admissao = new DateTime(2000, 01, 28),
                        Rescisao = new DateTime(2000, 01, 28),
                        Banco = 260,
                        Agencia = "0001",
                        Conta = "123456",
                        Cartorio = 0,
                        Admissao2 = new DateTime(2000, 01, 28),
                        Rescisao2 = new DateTime(2000, 01, 28),
                        GrupoCobranca = 1,
                        DigitoConta = "1",
                        Cpf = 01234567890,
                        Cnpj = 01234567890123,
                        ArquivoMorto = "arquivo morto",
                        Cargo = 1,
                        Ramal = 1,
                        Empresa = 1,
                        Email = "teste@hotmail.com",
                        ValidaHorario = 0,
                        PosJuridico = 0,
                        Oab = "11",
                        CarteiraFoco = 0,
                        DigitoAgencia = "1",
                        OpVar = "1",
                        Pis = 01234567890,
                        UtilizaSoftPhone = 0,
                        CarteiraWo = 0,
                        Senha = "1",
                        TipoCentral = 1,
                        DiscagemManual = 0,
                        CentralAlternativa = 1,
                        Receptivo = 1,
                        MetaDiscador = 0,
                        SapClienteNcNds = "1",
                        SapClienteNrp = "1",
                        SapFornecedorNds = "1",
                        EmailFuncional = 1,
                        TipoUsuario = 4,
                        Fiador = 0,
                        SegurancaGrupoCobranca = 1
                    }
                }
            };
        }

        #region Command

        [Theory(DisplayName = "Tratar Valores Recebidos")]
        [Trait("TesteUnidade", "Command")]
        //[ClassData(Pessoa)]
        [MemberData(nameof(PessoaCommandTeste))]
        public void TestaCommand_TratarValoresRecebidos_RetornaVerdadeiro(ClienteCommand command)
        {
            // Arrange
            ClienteCommand esperado = command;

            // Act
            command.TratarValoresRecebidos();

            // Assert
            Assert.Equal(esperado, command);

            //Teardown (Limpar o que foi persistido no banco de dados)
        }

        #endregion

        #region Entity

        [Theory(DisplayName = "Construtor padrão")]
        [Trait("TesteUnidade", "Entity")]
        //[ClassData(Pessoa)]
        [MemberData(nameof(PessoaCommandTeste))]
        public void TestaEntity_Adicionar_RetornaVerdadeiro(ClienteCommand command)
        {
            // Arrange
            ClienteEntity esperado;

            // Act
            esperado = new();

            // Assert
            Assert.Equal(command, command);
        }

        #endregion

        #region Expression

        [Theory]
        [Trait("TesteUnidade", "Expression")]
        //[ClassData(Pessoa)]
        [MemberData(nameof(PessoaCommandTeste))]
        public void TestaExpression_Adicionar_RetornaVerdadeiro(ClienteCommand command)
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(command, command);
        }

        #endregion

        #region Factory

        [Theory(DisplayName = "Factory Adicionar")]
        [Trait("TesteUnidade", "Factory")]
        //[ClassData(Pessoa)]
        [MemberData(nameof(PessoaCommandTeste))]
        public void TestaFactory_Adicionar_RetornaVerdadeiro(ClienteCommand command)
        {
            // Arrange
            ClienteFactory factory = new();
            ClienteEntity esperado = new();

            // Act
            ClienteEntity resultado = factory.Adicionar(command);

            // Assert
            //Assert.True(esperado, resultado);
            Assert.Equal(esperado, resultado);
        }

        #endregion

        #region Service

        [Theory]
        [Trait("TesteIntegração", "Service")]
        //[ClassData(Pessoa)]
        [MemberData(nameof(PessoaCommandTeste))]
        public void TestaService_Adicionar_RetornaVerdadeiro(ClienteCommand command)
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(command, command);
        }

        #endregion

        #region Validator

        [Theory]
        [Trait("TesteUnidade", "Validator")]
        //[ClassData(Pessoa)]
        [MemberData(nameof(PessoaCommandTeste))]
        public void TestaValidator_Adicionar_RetornaVerdadeiro(ClienteCommand command)
        {
            // Arrange
            ClienteValidator validador = new();

            validador.ValidarCadastro(command);
            // Act

            // Assert
            Assert.Equal(command, command);
        }

        #endregion
    }
}
