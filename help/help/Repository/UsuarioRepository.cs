using help.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace help.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private HelpDbContext _context;

        public UsuarioRepository(HelpDbContext helpDbContext)
        {
            _context = helpDbContext;
        }

        public void AtivarUsuario(string token)
        {
            Usuario user = new Usuario();
            //Usuario ativarEsseUser = _context.Usuarios.FirstOrDefault(u => user.GerarMD5(u.Email) == token);
            List<Usuario> listaDeUser = _context.Usuarios.ToList();
            foreach (var UserUnicoDalista in listaDeUser)
            {
                string emailCodificado = user.GerarMD5(UserUnicoDalista.Email);
                if (emailCodificado == token)
                {
                    UserUnicoDalista.Status = true;
                    _context.Entry(UserUnicoDalista).State = EntityState.Modified;
                    _context.SaveChanges();
                }
            }           
        }

        public Usuario BuscarPorEmail(Usuario user)
        {
            Usuario usuarioRetornado = _context.Usuarios.FirstOrDefault(u => u.Email == user.Email && u.Senha == user.Senha);
            return usuarioRetornado;
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
    }
}