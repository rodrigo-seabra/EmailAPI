using Microsoft.EntityFrameworkCore;

namespace EmailApi.models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
        public DbSet<DataContact>? DataContact { get; set; }
    }
}
