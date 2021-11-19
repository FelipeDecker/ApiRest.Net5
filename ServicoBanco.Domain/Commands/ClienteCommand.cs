using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ServicoBanco.Domain.Commands
{
    public class ClienteCommand : CommandBase
    {
        public decimal CodigoCliente { get; set; }
        public string TipoPessoa { get; set; }
        public bool Advogado { get; set; }
        public bool Captador { get; set; }
        public bool Cobrador { get; set; }
        public bool Cliente { get; set; }
        public bool Fornecedor { get; set; }
        public bool Devedor { get; set; }
        public string Nome { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Rg { get; set; }
        public string Login { get; set; }
        public string TipoAdvogado { get; set; }
        public string Observacao { get; set; }
        public decimal GrupoSeguranca { get; set; }
        public decimal Atividade { get; set; }
        public decimal Contato { get; set; } 
        public decimal Oficial { get; set; } 
        public decimal Segurado { get; set; } 
        public decimal GrupoCliente { get; set; }
        public decimal Autor { get; set; } 
        public decimal Reu { get; set; }
        public string CodigoAlteracao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string CodigoCriacao { get; set; } 
        public DateTime DataCriacao { get; set; }
        public decimal Filial { get; set; }
        public decimal Inativo { get; set; } 
        public int Localizador { get; set; } 
        public int Usuario { get; set; } 
        public decimal Filiais { get; set; }
        public DateTime Nascimento { get; set; }
        public int Setor { get; set; }
        public decimal Amigavel { get; set; } 
        public decimal Juridico { get; set; }
        public decimal Horario { get; set; }
        public DateTime Admissao { get; set; }
        public DateTime Rescisao { get; set; }
        public decimal Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public int Cartorio { get; set; }
        public DateTime Admissao2 { get; set; }
        public DateTime Rescisao2 { get; set; }
        public decimal GrupoCobranca { get; set; }
        public string DigitoConta { get; set; }
        public decimal Cpf { get; set; }
        public decimal Cnpj { get; set; }
        public string ArquivoMorto { get; set; }
        public decimal Cargo { get; set; }
        public decimal Ramal { get; set; }
        public decimal Empresa { get; set; }
        public string Email { get; set; }
        public decimal ValidaHorario { get; set; } 
        public decimal PosJuridico { get; set; } 
        public string Oab { get; set; }
        public decimal CarteiraFoco { get; set; }
        public string DigitoAgencia { get; set; }
        public string OpVar { get; set; }
        public decimal Pis { get; set; }
        public decimal UtilizaSoftPhone { get; set; }
        public decimal CarteiraWo { get; set; }
        public string Senha { get; set; }
        public decimal TipoCentral { get; set; }
        public decimal DiscagemManual { get; set; }
        public decimal CentralAlternativa { get; set; } 
        public decimal Receptivo { get; set; } 
        public decimal MetaDiscador { get; set; }
        public string SapClienteNcNds { get; set; }
        public string SapClienteNrp { get; set; }
        public string SapFornecedorNds { get; set; }
        public int EmailFuncional { get; set; }
        public int TipoUsuario { get; set; }
        public decimal Fiador { get; set; }
        public decimal SegurancaGrupoCobranca { get; set; }

        public override void TratarValoresRecebidos()
        {
            Type t = GetType();
            PropertyInfo[] props = t.GetProperties();

            foreach (var prop in props)
            {
                if (prop.PropertyType == typeof(DateTime))
                {
                    if (Convert.ToDateTime(prop.GetValue(this)) == new DateTime(0001, 01, 01))
                    {
                        prop.SetValue(this, new DateTime(1900, 01, 01));
                    }
                }

                if (prop.PropertyType == typeof(string))
                {
                    if (prop.Name == "TipoPessoa")
                    {
                        prop.SetValue(this, Convert.ToString(prop.GetValue(this))?.ToUpper());
                    }
                    if (prop.Name == "TipoAdvogado")
                    {
                        prop.SetValue(this, prop.GetValue(this) == default ? "" : prop.GetValue(this).ToString().ToUpper());
                    }
                    if (Convert.ToString(prop.GetValue(this)) == default)
                    {
                        prop.SetValue(this, "");
                    }
                }

                if (prop.PropertyType == typeof(decimal))
                {
                    if (prop.Name == "Segurado" ||
                        prop.Name == "Autor" ||
                        prop.Name == "Inativo" ||
                        prop.Name == "Amigavel" ||
                        prop.Name == "Juridico" ||
                        prop.Name == "Horario" ||
                        prop.Name == "ValidaHorario" ||
                        prop.Name == "PosJuridico" ||
                        prop.Name == "CarteiraFoco" ||
                        prop.Name == "UtilizaSoftPhone" ||
                        prop.Name == "CarteiraWo" ||
                        prop.Name == "DiscagemManual" ||
                        prop.Name == "CentralAlternativa" ||
                        prop.Name == "Receptivo" ||
                        prop.Name == "MetaDiscador" ||
                        prop.Name == "Fiador"
                        )
                    {
                        prop.SetValue(this, Convert.ToDecimal(Convert.ToInt32(prop.GetValue(this)) == 0 ? 0 : 1));
                    }
                }

                if (prop.PropertyType == typeof(int))
                {
                    if (prop.Name == "Usuario")
                    {
                        prop.SetValue(this, Convert.ToInt32(prop.GetValue(this)) == 0 ? 0 : 1);
                    }
                }
            }
        }
    }
}
