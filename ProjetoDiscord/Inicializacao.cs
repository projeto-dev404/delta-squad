using ProjectDelta.Context;
using System.Data.Entity;

namespace ProjectDelta
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
