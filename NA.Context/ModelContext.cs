using System.Data.Entity.ModelConfiguration.Conventions;
using NA.Aplicacion.Conexion;
using NA.Dominio.Entidades.Entidades;

namespace NA.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Core.Common.CommandTrees;
    using System.Linq;
    using static NA.Aplicacion.Conexion.CadenaConexion;

    public class ModelContext : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'ModelContext' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'NA.Context.ModelContext' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'ModelContext'  en el archivo de configuración de la aplicación.
        public ModelContext()
            : base(ObtenerConexionWin)
        {
            Configuration.LazyLoadingEnabled = false;

            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ////**************************************************************//

            //modelBuilder.Entity<Enfermedad>()
            //    .HasRequired(x => x.Paciente).WithOptional(e => e.Enfermedad);

            //modelBuilder.Entity<Ejercicio>()
            //    .HasRequired(x => x.Paciente).WithOptional(e => e.Ejercicio);

            //modelBuilder.Entity<Alimento>()
            //    .HasRequired(x => x.Paciente).WithOptional(e => e.Alimento);


            modelBuilder.Entity<InformeAntropometrico>()
                .HasRequired<Paciente>(x => x.Paciente)
                .WithMany(y => y.InformeAntropometricos)
                .HasForeignKey(x => x.PacienteId);

            ////**************************************************************//

            //modelBuilder.Entity<Circunferencia>()
            //    .HasRequired(x => x.IAntropometrico).WithOptional(e => e.Circunferencia);

            //modelBuilder.Entity<ContexturaCorporal>()
            //    .HasRequired(x => x.IAntropometrico).WithOptional(e => e.Contextura);

            //modelBuilder.Entity<Dieta>()
            //    .HasRequired(x => x.IAntropometrico).WithOptional(e => e.Dieta);

            ////**************************************************************//


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Paciente> Paciente { get; set; }

        public DbSet<Circunferencia> Circunferencia { get; set; }

        public DbSet<ContexturaCorporal> ContexturaCorporal { get; set; }

        public DbSet<Dieta> Dieta { get; set; }

        public DbSet<Documento> Documento { get; set; }

        public DbSet<InformeAntropometrico> InformeAntropometrico { get; set; }

        public DbSet<Item> Item { get; set; }

        public DbSet<ItemDetalle> ItemDetalle { get; set; }


        public DbSet<Plan> Plan { get; set; }

        public DbSet<Nivel> Nivel { get; set; }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}