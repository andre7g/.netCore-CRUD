using Microsoft.EntityFrameworkCore;
namespace api_empresa.Models{
    class Connection : DbContext {
        public Connection (DbContextOptions<Connection> options) : base(options){}
        public DbSet<Clientes> Clientes {set;get;}
        public DbSet<Empleados> Empleados {set;get;}
        public DbSet<Departamentos> Departamentos {set;get;}
        public DbSet<Estados> Estados {set;get;}
        public DbSet<Puestos> Puestos {set;get;}
        
    }
    class Conectar{
        private const string DefaultConnection = "server=localhost; port=3306; database=db_empresa; user=umgDE; password=system; Persist Security Info=False; Connect Timeout=300";
        public static Connection Create(){
            var conn = new DbContextOptionsBuilder<Connection>();
            conn.UseMySQL(DefaultConnection);
            var cn = new Connection(conn.Options);
            return cn;
        }
    }
}