using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

namespace help.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(100)]
        public string Sobrenome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(32)]
        public string Senha { get; set; }
        public bool Status { get; set; }
        public DateTime DataDeCadastro { get; set; }
        public bool Admin { get; set; }


        public bool ehValido()
        {
            if (string.IsNullOrWhiteSpace(Nome) || string.IsNullOrWhiteSpace(Sobrenome) || string.IsNullOrWhiteSpace(Email) ||
                string.IsNullOrWhiteSpace(Senha) ||Nome.Any(x => char.IsDigit(x)) || 
                Sobrenome.Any(x => char.IsDigit(x)) || Senha.Length < 8)
            {
                return false;

            } else
            {
                return true;
            }
        }

        public void EnviarEmailDeConfirmacao()
        {
            string emailMd5 = this.GerarMD5(this.Email);
            var uri = "http://localhost:59510/Usuario/ativa?token=" + emailMd5;
            var link = "<a href='"+uri+"'>Clique aqui</a>";
            
            MailMessage mm = new MailMessage("amajacarezinho@gmail.com", this.Email);
            mm.Subject = "Confirmação de Email do App do Jacarezinho";
            mm.Body = "Clique no link para confirmar seu cadastro - " + link;
            mm.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("amajacarezinho@gmail.com", "ama25817087");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.Send(mm);

            //Você deve também permitir o acesso "menos seguro" ao seu Gmail, 
            //através da página Aplicativos menos seguros.
            // link https://www.google.com/settings/security/lesssecureapps
        }

        // Nosso método recebe como parâmetro o valor a ser criptografado e retorna o mesmo

        public string GerarMD5(string valor)

        {

            // Cria uma nova intância do objeto que implementa o algoritmo para

            // criptografia MD5

            MD5 md5Hasher = MD5.Create();



            // Criptografa o valor passado

            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(valor));



            // Cria um StringBuilder para passarmos os bytes gerados para ele

            StringBuilder strBuilder = new StringBuilder();



            // Converte cada byte em um valor hexadecimal e adiciona ao

            // string builder

            // and format each one as a hexadecimal string.

            for (int i = 0; i < valorCriptografado.Length; i++)

            {

                strBuilder.Append(valorCriptografado[i].ToString("x2"));

            }



            // retorna o valor criptografado como string

            return strBuilder.ToString();

        }

    }
}