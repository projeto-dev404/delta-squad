using ProjetoDiscord.Context;
using System;
using System.Windows.Forms;

namespace ProjetoDiscord
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Inicializacao ini = new Inicializacao();

            Usuario usuario = new Usuario();
            usuario.Nome = "Teste";
            usuario.Login = "teste";
            usuario.Senha = "123456";

            var user = new Usuario();
            user.ExcluirUsuario("a");
            var v = user.VerificarSenha(usuario.Login, usuario.Senha);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
