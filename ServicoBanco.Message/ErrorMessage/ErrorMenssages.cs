using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Message.ErrorMessage
{
    public class ErrorMenssages
    {
        public string[] Message { get; set; }
        public bool TemMensagem { get; set; } = false;

        public void AdicionarMensagem(string msg)
        {
            Message.Append(msg);
            TemMensagem = true;
        }

        public List<string> LerMensagens()
        {
            return Message.ToList();
        }
    }
}
