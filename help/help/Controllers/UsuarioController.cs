using help.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mail;
using System.Web.Mvc;

namespace help.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: Usuario
        [HttpGet]
        public ActionResult Index()
        {
            var usuarioLogado = HttpContext.Session["user"];
            if (usuarioLogado == null)
            {
                return Redirect("/Usuario/Login");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(UsuarioViewModel userViewModel)
        {
            Usuario user = new Usuario()
            {
                Nome = userViewModel.nome,
                Sobrenome = userViewModel.sobreNome,
                Email = userViewModel.email,
                Senha = userViewModel.senha,
                Status = false,
                DataDeCadastro = DateTime.Now,
                Admin = false
                
            };

            Usuario VerificarSeUsuarioExiste = _usuarioRepository.BuscarPorEmail(user);

            if (VerificarSeUsuarioExiste == null)
            {
                if (user.Senha == userViewModel.repeteSenha)
                {
                    if (user.ehValido())
                    {
                         _usuarioRepository.Cadastrar(user);
                        user.EnviarEmailDeConfirmacao();
                    }
                }

            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Ativa(string token)
        {
            _usuarioRepository.AtivarUsuario(token);
            //agora eu preciso pegar essa token e comparar com todos os email do banco mas antes de 
            //cada comparação com o email, preciso encripitografar todos emails em cada comparação

            return View("index");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string senha)
        {
            var user = new Usuario() { Email = email, Senha = senha };
            user = _usuarioRepository.BuscarPorEmail(user);

            if (user == null)
            {
                return View("Index");
            }

            if (user.Email != email || user.Senha != senha)
            {
                return View("Index");
            }

            else
            {
                if (user.Admin == true)
                {
                    Session.Add("admin", user);
                    return Redirect("/Admin/Index");
                }
                else
                {
                    Session.Add("user", user);
                    return Redirect("/Usuario/Index");
                }
            }
        }

        [HttpPost]
        public ActionResult Deslogar()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
}