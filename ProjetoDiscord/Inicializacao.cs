using ProjetoDiscord.Context;
using System.Data.Entity;

namespace ProjetoDiscord
{
    public class Inicializacao
    {
        public Inicializacao()
        {
            this.CriarContexto<UsuarioContext>();
        }
        private void CriarContexto<TContext>() where TContext : DbContext, new()
        {
            using (var context = new TContext())
            {
                context.Database.CreateIfNotExists();
            }
        }
    }
}
