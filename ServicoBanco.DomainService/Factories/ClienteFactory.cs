using ServicoBanco.Domain.Commands;
using ServicoBanco.Domain.Entities;
using ServicoBanco.DomainService.Patterns;

namespace ServicoBanco.DomainService.Factories
{
    public class ClienteFactory : IGenericFactory<ClienteEntity, ClienteCommand>
    {
        public ClienteEntity Entidade { get; set; }

        public ClienteFactory()
        {
            Entidade = new ClienteEntity();
        }

        public ClienteEntity Adicionar(ClienteCommand command)
        {
            Entidade.CodigoCliente = command.CodigoCliente;

            Entidade.CriarPessoa(command.Nome, command.Observacao, command.Atividade, command.CodigoCriacao, command.DataCriacao,
                command.Filial, command.SapClienteNcNds, command.SapClienteNrp, command.SapFornecedorNds);

            Entidade.CriarContabancaria(command.Banco, command.Agencia, command.Conta, command.DigitoAgencia, command.DigitoConta, command.OpVar);

            if (command.TipoPessoa == "F") CriarPessoaFisica(command);

            if (command.TipoPessoa == "J") CriarPessoaJuridica(command);

            if (command.Advogado) CriarAdvogado(command);

            if (command.Autor != 0) CriarAutor();

            if (command.Captador) CriarCaptador();

            if (command.Cartorio != 0) CriarCartorio();

            if (command.Cliente) CriarCliente(command);

            if (command.Cobrador) CriarCobrador(command);

            if (command.Contato != 0) CriarContato();

            if (command.Devedor) CriarDevedor(command);

            if (command.Fiador != 0) CriarFiador();

            if (command.Fornecedor) CriarFornecedor();

            if (command.Localizador != 0) CriarLocalizador();

            if (command.Oficial != 0) CriarOficial();

            if (command.Reu != 0) CriarReu();

            if (command.Segurado != 0) CriarSegurado();

            if (command.Usuario != 0) CriarUsuario(command);

            return Entidade;
        }

        public ClienteEntity Atualizar(ClienteCommand command)
        {
            Entidade.CodigoCliente = command.CodigoCliente;

            Entidade.Editar(command.CodigoAlteracao, command.DataAlteracao);

            Entidade.CriarPessoa(command.Nome, command.Observacao, command.Atividade, command.CodigoCriacao, command.DataCriacao,
                command.Filial, command.SapClienteNcNds, command.SapClienteNrp, command.SapFornecedorNds);

            Entidade.CriarContabancaria(command.Banco, command.Agencia, command.Conta, command.DigitoAgencia, command.DigitoConta, command.OpVar);

            if (command.TipoPessoa == "F") CriarPessoaFisica(command);

            if (command.TipoPessoa == "J") CriarPessoaJuridica(command);

            if (command.Advogado) CriarAdvogado(command);

            if (command.Autor != 0) CriarAutor();

            if (command.Captador) CriarCaptador();

            if (command.Cartorio != 0) CriarCartorio();

            if (command.Cliente) CriarCliente(command);

            if (command.Cobrador) CriarCobrador(command);

            if (command.Contato != 0) CriarContato();

            if (command.Devedor) CriarDevedor(command);

            if (command.Fiador != 0) CriarFiador();

            if (command.Fornecedor) CriarFornecedor();

            if (command.Localizador != 0) CriarLocalizador();

            if (command.Oficial != 0) CriarOficial();

            if (command.Reu != 0) CriarReu();

            if (command.Segurado != 0) CriarSegurado();

            if (command.Usuario != 0) CriarUsuario(command);

            return Entidade;
        }

        public ClienteEntity AtualizarRh(ClienteCommand command)
        {
            Entidade.CodigoCliente = command.CodigoCliente;

            Entidade.AtualizarRh(command.Inativo, command.Setor, command.Horario, command.Admissao, command.Rescisao, command.Admissao2, 
                command.Rescisao2, command.ArquivoMorto, command.Cargo, command.Empresa, command.ValidaHorario);

            Entidade.Editar(command.CodigoAlteracao, command.DataAlteracao);

            Entidade.CriarPessoa(command.Nome, command.Observacao, command.Atividade, command.CodigoCriacao, command.DataCriacao,
                command.Filial, command.SapClienteNcNds, command.SapClienteNrp, command.SapFornecedorNds);

            Entidade.CriarContabancaria(command.Banco, command.Agencia, command.Conta, command.DigitoAgencia, command.DigitoConta, command.OpVar);

            if (command.TipoPessoa == "F") CriarPessoaFisica(command);

            if (command.TipoPessoa == "J") CriarPessoaJuridica(command);

            if (command.Advogado) CriarAdvogado(command);

            if (command.Autor != 0) CriarAutor();

            if (command.Captador) CriarCaptador();

            if (command.Cartorio != 0) CriarCartorio();

            if (command.Cliente) CriarCliente(command);

            if (command.Cobrador) CriarCobrador(command);

            if (command.Contato != 0) CriarContato();

            if (command.Devedor) CriarDevedor(command);

            if (command.Fiador != 0) CriarFiador();

            if (command.Fornecedor) CriarFornecedor();

            if (command.Localizador != 0) CriarLocalizador();

            if (command.Oficial != 0) CriarOficial();

            if (command.Reu != 0) CriarReu();

            if (command.Segurado != 0) CriarSegurado();

            if (command.Usuario != 0) CriarUsuario(command);

            return Entidade;
        }

        public ClienteEntity Deletar(ClienteCommand command)
        {
            Entidade.CodigoCliente = command.CodigoCliente;

            Entidade.Deletar();

            return Entidade;
        }

        private void CriarPessoaFisica(ClienteCommand command)
        {
            Entidade.CriarPessoaFisica(command.Cpf, command.Rg, command.Nascimento);
        }

        private void CriarPessoaJuridica(ClienteCommand command)
        {
            Entidade.CriarPessoaJuridica(command.Cnpj, command.InscricaoEstadual, command.InscricaoMunicipal);
        }

        private void CriarAdvogado(ClienteCommand command)
        {
            Entidade.CriarAdvogado(command.TipoAdvogado, command.Oab);
        }

        private void CriarAutor()
        {
            Entidade.CriarAutor();
        }

        private void CriarCaptador()
        {
            Entidade.CriarCaptador();
        }

        private void CriarCartorio()
        {
            Entidade.CriarCartorio();
        }

        private void CriarCliente(ClienteCommand command)
        {
            Entidade.CriarCliente(command.GrupoCliente);
        }

        private void CriarCobrador(ClienteCommand command)
        {
            Entidade.CriarCobrador(command.CarteiraFoco, command.UtilizaSoftPhone, command.CarteiraWo, command.TipoCentral, command.DiscagemManual,
                command.CentralAlternativa, command.MetaDiscador);
        }

        private void CriarContato()
        {
            Entidade.CriarContato();
        }

        private void CriarDevedor(ClienteCommand command)
        {
            Entidade.CriarDevedor(command.Filiais, command.Amigavel, command.Juridico, command.PosJuridico, command.Receptivo);
        }

        private void CriarFiador()
        {
            Entidade.CriarFiador();
        }

        private void CriarFornecedor()
        {
            Entidade.CriarFornecedor();
        }

        private void CriarLocalizador()
        {
            Entidade.CriarLocalizador();
        }

        private void CriarOficial()
        {
            Entidade.CriarOficial();
        }

        private void CriarReu()
        {
            Entidade.CriarReu();
        }

        private void CriarSegurado()
        {
            Entidade.CriarSegurado();
        }

        private void CriarUsuario(ClienteCommand command)
        {
            Entidade.CriarUsuario(command.Login, command.GrupoSeguranca, command.GrupoCobranca, command.Ramal, command.Email, command.Pis,
                command.Senha, command.EmailFuncional, command.TipoUsuario, command.SegurancaGrupoCobranca);
        }
    }
}
