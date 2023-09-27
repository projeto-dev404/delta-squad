using ProjetoDiscord.Context;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProjetoDiscord
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriado { get; set; }
        public DateTime DataAlterado { get; set; }

        public void CriarNovoUsuario(Usuario usuario)
        {
            try
            {
                using (var contexto = new UsuarioContext())
                {
                    if (usuario == null)
                        throw new Exception("Usuario novo invalido");

                    usuario.Nome.Trim();
                    usuario.Login.ToLower().Trim();
                    usuario.Senha.Trim();
                    usuario.Senha = new Criptografia().CriptografarSenha(usuario.Senha);
                    usuario.DataCriado = DateTime.Now;
                    usuario.DataAlterado = DateTime.Now;

                    if (contexto.Usuarios.FirstOrDefault(x => x.Login == usuario.Login) != null)
                        throw new Exception("Login ja cadastrado");

                    
                        

                    contexto.Usuarios.Add(usuario);
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public void AlterarUsuario(Usuario usuario)
        {
            try
            { 
                using(var contexto = new UsuarioContext())
                {
                    Usuario usuarioRecuperado = this.RecuperarUsuario(usuario.Login);
                    Usuario usuarioDadosAntigos = contexto.Usuarios.FirstOrDefault(x => x.Equals(usuarioRecuperado));
                    usuarioDadosAntigos = usuario;
                    contexto.SaveChanges();
                }
            }
            catch (Exception) 
            {
                throw;
            }
        }
        public void ExcluirUsuario(Usuario usuario)
        {
            try
            {
                using (var contexto = new UsuarioContext())
                {
                    Usuario usuarioRecuperado = this.RecuperarUsuario(usuario.Login);
                    contexto.Usuarios.Remove(usuarioRecuperado);
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void ExcluirUsuario(string login)
        {
            try
            {
                using (var contexto = new UsuarioContext())
                {
                    Usuario usuarioRecuperado = this.RecuperarUsuario(login);
                    var usuarioParaRemover =  contexto.Usuarios.FirstOrDefault(x => x.Id == usuarioRecuperado.Id);
                    contexto.Usuarios.Remove(usuarioParaRemover);
                    contexto.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Usuario RecuperarUsuario(string login)
        {
            using(var contexto = new UsuarioContext())
            {
                var usuarioRecuperado = contexto.Usuarios.FirstOrDefault(x => x.Login == login);
                if(usuarioRecuperado != null)
                    return usuarioRecuperado;
                else 
                    return null;
            }
        }
        public bool VerificarSenha(string login, string senha) 
        {
            Usuario usuario = this.RecuperarUsuario(login);
            return usuario.Senha == new Criptografia().CriptografarSenha(senha);
        }
    }
}
