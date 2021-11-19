using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServicoBanco.Domain.Entities;
using System;

namespace ServicoBanco.Repository.EntityConfigs
{
    public class ClienteConfig : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.CodigoCliente);

            builder.Property(x => x.CodigoCliente).HasColumnName("cd_cliente");
            builder.Property(x => x.TipoPessoa).HasColumnName("tp_pessoa");
            builder.Property(x => x.Advogado).HasColumnName("fl_advogado");
            builder.Property(x => x.Captador).HasColumnName("fl_captador");
            builder.Property(x => x.Cobrador).HasColumnName("fl_cobrador");
            builder.Property(x => x.Cliente).HasColumnName("fl_cliente");
            builder.Property(x => x.Fornecedor).HasColumnName("fl_fornecedor");
            builder.Property(x => x.Devedor).HasColumnName("fl_devedor");
            builder.Property(x => x.Nome).HasColumnName("no_cliente");
            builder.Property(x => x.InscricaoEstadual).HasColumnName("nr_ie");
            builder.Property(x => x.InscricaoMunicipal).HasColumnName("nr_im");
            builder.Property(x => x.Rg).HasColumnName("nr_ci");
            builder.Property(x => x.Login).HasColumnName("cd_usuario");
            builder.Property(x => x.TipoAdvogado).HasColumnName("tp_advogado");
            builder.Property(x => x.Observacao).HasColumnName("de_observacao");
            builder.Property(x => x.GrupoSeguranca).HasColumnName("cd_grupo");
            builder.Property(x => x.Atividade).HasColumnName("cd_atividade");
            builder.Property(x => x.Contato).HasColumnName("fl_contato");
            builder.Property(x => x.Oficial).HasColumnName("fl_oficiais");
            builder.Property(x => x.Segurado).HasColumnName("fl_segurados");
            builder.Property(x => x.GrupoCliente).HasColumnName("cd_grupo_cliente");
            builder.Property(x => x.Autor).HasColumnName("fl_autor");
            builder.Property(x => x.Reu).HasColumnName("fl_reu");
            builder.Property(x => x.CodigoAlteracao).HasColumnName("cd_alteracao");
            builder.Property(x => x.DataAlteracao).HasColumnName("dt_alteracao");
            builder.Property(x => x.CodigoCriacao).HasColumnName("cd_criacao");
            builder.Property(x => x.DataCriacao).HasColumnName("dt_criacao");
            builder.Property(x => x.Filial).HasColumnName("cd_filial_cliente");
            builder.Property(x => x.Inativo).HasColumnName("fl_inativo");
            builder.Property(x => x.Localizador).HasColumnName("fl_localizador");
            builder.Property(x => x.Usuario).HasColumnName("fl_usuario");
            builder.Property(x => x.Filiais).HasColumnName("cd_filialss");
            builder.Property(x => x.Nascimento).HasColumnName("dt_nascimento");
            builder.Property(x => x.Setor).HasColumnName("cd_setor");
            builder.Property(x => x.Amigavel).HasColumnName("fl_amigavel");
            builder.Property(x => x.Juridico).HasColumnName("fl_juridico");
            builder.Property(x => x.Horario).HasColumnName("cd_horario");
            builder.Property(x => x.Admissao).HasColumnName("dt_admissao");
            builder.Property(x => x.Rescisao).HasColumnName("dt_rescisao");
            builder.Property(x => x.Banco).HasColumnName("cd_banco");
            builder.Property(x => x.Agencia).HasColumnName("nr_agencia");
            builder.Property(x => x.Conta).HasColumnName("nr_conta");
            builder.Property(x => x.Cartorio).HasColumnName("fl_cartorio");
            builder.Property(x => x.Admissao2).HasColumnName("dt_admissao2");
            builder.Property(x => x.Rescisao2).HasColumnName("dt_rescisao2");
            builder.Property(x => x.GrupoCobranca).HasColumnName("cd_grupo_cobranca");
            builder.Property(x => x.DigitoConta).HasColumnName("cd_dv");
            builder.Property(x => x.Cpf).HasColumnName("nr_cpf");
            builder.Property(x => x.Cnpj).HasColumnName("nr_cgc");
            builder.Property(x => x.ArquivoMorto).HasColumnName("de_morto");
            builder.Property(x => x.Cargo).HasColumnName("cd_cargo");
            builder.Property(x => x.Ramal).HasColumnName("nr_ramal_cob");
            builder.Property(x => x.Empresa).HasColumnName("cd_empresa");
            builder.Property(x => x.Email).HasColumnName("de_mail");
            builder.Property(x => x.ValidaHorario).HasColumnName("fl_valida_horario");
            builder.Property(x => x.PosJuridico).HasColumnName("fl_pos_juridico");
            builder.Property(x => x.Oab).HasColumnName("nr_inscricao_oab");
            builder.Property(x => x.CarteiraFoco).HasColumnName("fl_foco");
            builder.Property(x => x.DigitoAgencia).HasColumnName("cd_dv_agencia");
            builder.Property(x => x.OpVar).HasColumnName("cd_op_var");
            builder.Property(x => x.Pis).HasColumnName("nr_pis");
            builder.Property(x => x.UtilizaSoftPhone).HasColumnName("fl_discador");
            builder.Property(x => x.CarteiraWo).HasColumnName("fl_wo");
            builder.Property(x => x.Senha).HasColumnName("id_password");
            builder.Property(x => x.TipoCentral).HasColumnName("fl_tipo_central");
            builder.Property(x => x.DiscagemManual).HasColumnName("fl_manual");
            builder.Property(x => x.CentralAlternativa).HasColumnName("fl_alternativa");
            builder.Property(x => x.Receptivo).HasColumnName("fl_receptivo");
            builder.Property(x => x.MetaDiscador).HasColumnName("fl_meta_discador");
            builder.Property(x => x.SapClienteNcNds).HasColumnName("cd_cliente_sap_nc");
            builder.Property(x => x.SapClienteNrp).HasColumnName("cd_cliente_sap_nrp");
            builder.Property(x => x.SapFornecedorNds).HasColumnName("cd_cliente_sap");
            builder.Property(x => x.EmailFuncional).HasColumnName("cd_contato_se");
            builder.Property(x => x.TipoUsuario).HasColumnName("fl_tipo_usuario");
            builder.Property(x => x.Fiador).HasColumnName("fl_fiador");
            builder.Property(x => x.SegurancaGrupoCobranca).HasColumnName("cd_seg_grupo_cobranca");
        }
    }
}
