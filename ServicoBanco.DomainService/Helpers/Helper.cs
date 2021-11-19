using System;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace ServicoBanco.DomainService.Helpers
{
    public static class Helper
    {
        public static bool ValidarCpf(string cpf)
        {
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf += digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito += resto.ToString();
			return cpf.EndsWith(digito);
		}   

		public static bool ValidarCnpj(string cnpj)
        {
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj += digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito += resto.ToString();
			return cnpj.EndsWith(digito);
		}

		public static bool ValidarPis(string pis)
        {
			int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			if (pis.Trim().Length != 11)
				return false;
			pis = pis.Trim();
			pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(pis[i].ToString()) * multiplicador[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			return pis.EndsWith(resto.ToString());
		}

		public static bool ValidarEmail(string email)
		{
            try
            {
				return new MailAddress(email).Address == email;
			}
            catch
            {
                return false;
            }
		}

		public static string EncriptarSenha(string senha)
        {
			var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(senha));

			var sb = new StringBuilder(hash.Length * 2);

			foreach (byte b in hash)
			{
				sb.Append(b.ToString("X2").ToLower());
			}

			var senhaSha = sb.ToString();

			var senhaContrario = "";
			var i = senhaSha.Length;

			while (i >= 1)
			{
				senhaContrario += senhaSha.Substring(i - 1, 1);
				i -= 1;
			}

			var senhaEncriptada = "";
			var control = 0;
			i = 0;

			while (i < senhaContrario.Length)
			{
				var c = Encoding.ASCII.GetBytes(senhaContrario.Substring(i, 1))[0];
				char digitoSenha;
				if (control == 1)
				{
					var soma = Convert.ToByte(5);
					var ResultadoSoma = Convert.ToByte(c + soma);
					digitoSenha = Convert.ToChar(ResultadoSoma);

					control = 0;
				}
				else
				{
					var soma = Convert.ToByte(5);
					var ResultadoSoma = Convert.ToByte(c - soma);
					digitoSenha = Convert.ToChar(ResultadoSoma);

					control = 1;
				}

				senhaEncriptada += digitoSenha.ToString();
				i++;
			}

			return senhaEncriptada;
		}

		public static string Desincriptar()
		{
			return "Desincriptar";
		}

		public static string RemoverCaracteresEspeciais()
		{
			return "RemoverCaracteresEspeciais";
		}

		public static string RemoverAcentos()
		{
			return "RemoverAcentos";
		}

		public static void FazerRequisicaoExterna()
        {
			WebClient webClient = new WebClient();
			webClient.DownloadStringTaskAsync("a");
			string conteudo = webClient.DownloadString("url");
			string conteudo2 = webClient.DownloadString("url");
		}

		public static string SegredinhoApi()
        {
			// utilizar essas chaves caso um dia precise trocar
			// ou gerar um Guid

			//var cha1 = "a97ebeab78cda128ff2644b1005017f66b1f241086c4bf100864906531ab31e6";

			//var cha2 = "36dc1274936200059202d8d9428ef4d4a6f7612fd392e13efde15749dad3cbde";

			//var cha3 = "e8a2f3adc63c5a9d323f34cd141896429e1fd201dc030c652aa59e04d03b56d7";

			return "0a8668c28dda4e1684c6374ed3f307b9";
		}

		public static void EnviarEmail(string conteudo, string assunto = "", string anexo = null, string tipoEmail = "")
        {
			//private SmtpClient ParametrosEmail()
			//{
			//	SmtpClient client = new SmtpClient();
			//	client.Port = 587;
			//	client.Host = "smtplw.com.br";
			//	client.Timeout = 0;
			//	//client.EnableSsl = true;
			//	client.Credentials = new System.Net.NetworkCredential("alisonnicolait", "Aenvio12");

			//	return client;
			//}


			//try
			//{
			//	SmtpClient smtpClient = ParametrosEmail();
			//	MailMessage email = new MailMessage();
			//	email.From = new MailAddress("no-reply@schulze.com.br");

			//	email.To.Add("importacao.bradesco@schulze.com.br");
			//	email.CC.Add("importacao@schulze.com.br");
			//	//conteudo
			//	email.Subject = assunto;
			//	email.Body = conteudo;
			//	if (anexo != null && anexo.Length != 0)
			//	{
			//		email.Attachments.Add(new Attachment(anexo));
			//	}

			//	smtpClient.Send(email);
			//	smtpClient.Dispose();

			//	return true;
			//}
			//catch (SmtpException ex)
			//{
			//	return false;
			//}
		}
    }
}
