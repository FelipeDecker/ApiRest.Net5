using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoBanco.Domain.Commands
{
    public class LoginCommand : CommandBase
    {
        public decimal Login { get; set; }
        public string Senha { get; set; }
    }
}
