using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace help.Models
{
    public class UsuarioViewModel
    {
        public string nome { get; set; }
        public string sobreNome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string repeteSenha { get; set; }
    }
}