
using System.Data.Entity;

namespace ProjectDelta.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext() : base("Conn")
        {
            Database.SetInitializer<UsuarioContext>(null);
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
