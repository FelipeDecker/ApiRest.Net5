using System;

namespace ServicoBanco.Domain.Entities
{
    public class ClienteEntity
    {
        public decimal? CodigoCliente { get; set; }
        public string TipoPessoa { get; set; }
        public bool? Advogado { get; set; }
        public bool? Captador { get; set; } 
        public bool? Cobrador { get; set; } 
        public bool? Cliente { get; set; }
        public bool? Fornecedor { get; set; } 
        public bool? Devedor { get; set; }
        public string Nome { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Rg { get; set; }
        public string Login { get; set; }
        public string TipoAdvogado { get; set; }
        public string Observacao { get; set; }
        public decimal? GrupoSeguranca { get; set; }
        public decimal? Atividade { get; set; }
        public decimal? Contato { get; set; }
        public decimal? Oficial { get; set; } 
        public decimal? Segurado { get; set; } 
        public decimal? GrupoCliente { get; set; }  
        public decimal? Autor { get; set; } 
        public decimal? Reu { get; set; }
        public string CodigoAlteracao { get; set; } 
        public DateTime? DataAlteracao { get; set; }
        public string CodigoCriacao { get; set; } 
        public DateTime? DataCriacao { get; set; }
        public decimal? Filial { get; set; } 
        public decimal? Inativo { get; set; } 
        public int? Localizador { get; set; } 
        public int? Usuario { get; set; } 
        public decimal? Filiais { get; set; } 
        public DateTime? Nascimento { get; set; }
        public int? Setor { get; set; }
        public decimal? Amigavel { get; set; }
        public decimal? Juridico { get; set; } 
        public decimal? Horario { get; set; } 
        public DateTime? Admissao { get; set; }
        public DateTime? Rescisao { get; set; }
        public decimal? Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public int? Cartorio { get; set; } 
        public DateTime? Admissao2 { get; set; }
        public DateTime? Rescisao2 { get; set; }
        public decimal? GrupoCobranca { get; set; }
        public string DigitoConta { get; set; }
        public decimal? Cpf { get; set; }
        public decimal? Cnpj { get; set; } 
        public string ArquivoMorto { get; set; }
        public decimal? Cargo { get; set; } 
        public decimal? Ramal { get; set; }
        public decimal? Empresa { get; set; } 
        public string Email { get; set; }
        public decimal? ValidaHorario { get; set; } 
        public decimal? PosJuridico { get; set; } 
        public string Oab { get; set; }
        public decimal? CarteiraFoco { get; set; }
        public string DigitoAgencia { get; set; }
        public string OpVar { get; set; }
        public decimal? Pis { get; set; }
        public decimal? UtilizaSoftPhone { get; set; }
        public decimal? CarteiraWo { get; set; } 
        public string Senha { get; set; }
        public decimal? TipoCentral { get; set; }
        public decimal? DiscagemManual { get; set; }
        public decimal? CentralAlternativa { get; set; }
        public decimal? Receptivo { get; set; } 
        public decimal? MetaDiscador { get; set; } 
        public string SapClienteNcNds { get; set; }
        public string SapClienteNrp { get; set; }
        public string SapFornecedorNds { get; set; }
        public int? EmailFuncional { get; set; }
        public int? TipoUsuario { get; set; }
        public decimal? Fiador { get; set; }
        public decimal? SegurancaGrupoCobranca { get; set; }

        public ClienteEntity()
        {
            CodigoCliente = 0;
            TipoPessoa = "";
            Advogado = false;
            Captador = false;
            Cobrador = false;
            Cliente = false;
            Fornecedor = false;
            Devedor = false;
            Nome = "";
            InscricaoEstadual = "";
            InscricaoMunicipal = "";
            Rg = "";
            Login = "";
            TipoAdvogado = "";
            Observacao = "";
            GrupoSeguranca = 0;
            Atividade = 0;
            Contato = 0;
            Oficial = 0;
            Segurado = 0;
            GrupoCliente = 0;
            Autor = 0;
            Reu = 0;
            CodigoAlteracao = "";
            DataAlteracao = new DateTime(1900, 01, 01);
            CodigoCriacao = "";
            DataCriacao = new DateTime(1900, 01, 01);
            Filial = 0;
            Inativo = 0;
            Localizador = 0;
            Usuario = 0;
            Filiais = 0;
            Nascimento = new DateTime(1900, 01, 01);
            Setor = 0;
            Amigavel = 0;
            Juridico = 0;
            Horario = 0;
            Admissao = new DateTime(1900, 01, 01);
            Rescisao = new DateTime(1900, 01, 01);
            Banco = 0;
            Agencia = "";
            Conta = "";
            Cartorio = 0;
            Admissao2 = new DateTime(1900, 01, 01);
            Rescisao2 = new DateTime(1900, 01, 01);
            GrupoCobranca = 0;
            DigitoConta = "";
            Cpf = 0;
            Cnpj = 0;
            ArquivoMorto = "";
            Cargo = 0;
            Ramal = 0;
            Empresa = 0;
            Email = "";
            ValidaHorario = 0;
            PosJuridico = 0;
            Oab = "";
            CarteiraFoco = 0;
            DigitoAgencia = "";
            OpVar = "";
            Pis = 0;
            UtilizaSoftPhone = 0;
            CarteiraWo = 0;
            Senha = "";
            TipoCentral = 0;
            DiscagemManual = 0;
            CentralAlternativa = 0;
            Receptivo = 0;
            MetaDiscador = 0;
            SapClienteNcNds = "";
            SapClienteNrp = "";
            SapFornecedorNds = "";
            EmailFuncional = 0;
            TipoUsuario = 0;
            Fiador = 0;
            SegurancaGrupoCobranca = 0;
        }

        public void CriarPessoa(string nome, string observacao, decimal? atividade, string codigoCriacao, DateTime? dataCriacao, 
            decimal? filial, string sapClienteNcNds, string sapClienteNrp, string sapFornecedorNds)
        {
            Nome = nome;
            Observacao = observacao;
            Atividade = atividade;
            CodigoCriacao = codigoCriacao;
            DataCriacao = dataCriacao;
            Filial = filial;
            SapClienteNcNds = sapClienteNcNds;
            SapClienteNrp = sapClienteNrp;
            SapFornecedorNds = sapFornecedorNds;
        }

        public void CriarPessoaFisica(decimal? cpf, string rg, DateTime? nascimento)
        {
            TipoPessoa = "F";
            Cpf = cpf;
            Rg = rg;
            Nascimento = nascimento;
            //Remove propriedades da pessoa juridica
            Cnpj = 0;
            InscricaoEstadual = "";
            InscricaoMunicipal = "";
        }

        public void CriarPessoaJuridica(decimal? cnpj, string inscricaoEstadual, string inscricaoMunicipal)
        {
            TipoPessoa = "J";
            Cnpj = cnpj;
            InscricaoEstadual = inscricaoEstadual;
            InscricaoMunicipal = inscricaoMunicipal;
            //Remove propriedades de pessoa fisica
            Cpf = 0;
            Rg = "";
            Nascimento = new DateTime(1900, 01, 01);
        }

        public void CriarAdvogado(string tipoAdvogado, string oab)
        {
            Advogado = true;
            TipoAdvogado = tipoAdvogado;
            Oab = oab;
        }

        public void CriarAutor()
        {
            Autor = 1;
        }

        public void CriarCaptador()
        {
            Captador = true;
        }

        public void CriarCartorio()
        {
            Cartorio = 1;
        }

        public void CriarCliente(decimal? grupoCliente)
        {
            Cliente = true;
            GrupoCliente = grupoCliente;
        }

        public void CriarCobrador(decimal? carteiraFoco, decimal? utilizaSoftPhone, decimal? carteiraWo, decimal? tipoCentral, 
            decimal? discagemManual, decimal? centralAlternativa, decimal? metaDiscador)
        {
            Cobrador = true;
            CarteiraFoco = carteiraFoco;
            UtilizaSoftPhone = utilizaSoftPhone;
            CarteiraWo = carteiraWo;
            TipoCentral = tipoCentral;
            DiscagemManual = discagemManual;
            CentralAlternativa = centralAlternativa;
            MetaDiscador = metaDiscador;
        }

        public void CriarContato()
        {
            Contato = 1;
        }

        public void CriarDevedor(decimal? filiais, decimal? amigavel, decimal? juridico, decimal? posJuridico, decimal? receptivo)
        {
            Devedor = true;
            Filiais = filiais;
            Amigavel = amigavel;
            Juridico = juridico;
            PosJuridico = posJuridico;
            Receptivo = receptivo;
        }

        public void CriarFiador()
        {
            Fiador = 1;
        }

        public void CriarFornecedor()
        {
            Fornecedor = true;
        }

        public void CriarLocalizador()
        {
            Localizador = 1;
        }

        public void CriarOficial()
        {
            Oficial = 1;
        }

        public void CriarReu()
        {
            Reu = 1;
        }

        public void CriarSegurado()
        {
            Segurado = 1;
        }

        public void CriarUsuario(string login, decimal? grupoSeguranca, decimal? grupoCobranca, decimal? ramal, string email,
            decimal? pis, string senha, int? emailFuncional, int? tipoUsuario, decimal? segurancaGrupoCobranca)
        {
            Usuario = 1;
            Login = login;
            GrupoSeguranca = grupoSeguranca;
            GrupoCobranca = grupoCobranca;
            Ramal = ramal;
            Email = email;
            Pis = pis;
            Senha = senha;
            EmailFuncional = emailFuncional;
            TipoUsuario = tipoUsuario;
            SegurancaGrupoCobranca = segurancaGrupoCobranca;
        }

        public void CriarContabancaria(decimal? banco, string agencia, string conta,
            string digitoAgencia, string digitoConta, string opVar)
        {
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
            DigitoAgencia = digitoAgencia;
            DigitoConta = digitoConta;
            OpVar = opVar;
        }

        public void AtualizarRh(decimal? inativo, int? setor, decimal? horario, DateTime? admissao, DateTime? rescisao,
            DateTime? admissao2, DateTime? rescisao2, string arquivoMorto, decimal? cargo, decimal? empresa, decimal? validaHorario)
        {
            Inativo = inativo;
            Setor = setor;
            Horario = horario;
            Admissao = admissao;
            Rescisao = rescisao;
            Admissao2 = admissao2;
            Rescisao2 = rescisao2;
            ArquivoMorto = arquivoMorto;
            Cargo = cargo;
            Empresa = empresa;
            ValidaHorario = validaHorario;
        }

        public void Editar(string codigoAlteracao, DateTime? dataAlteracao)
        {
            CodigoAlteracao = codigoAlteracao;
            DataAlteracao = dataAlteracao;
        }

        public void Deletar()
        {
            Inativo = 1;
        }
    }
}
