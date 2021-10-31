using Microsoft.EntityFrameworkCore;
using NA.Dominio.Base.BaseDto;
using NA.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NA.Context;
using EntityState = System.Data.Entity.EntityState;


namespace NA.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : BaseEntity
    {

        protected ModelContext Context;

        public Repositorio()
            : this(new ModelContext())
        {

        }

        public Repositorio(ModelContext context)
        {
            Context = context;
        }

        public void Agregar(T entidad)
        {
            Context.Set<T>().Add(entidad);
        }

        public void Eliminar(long id)
        {
            var entidad = ObtenerPorId(id);
            Context.Set<T>().Remove(entidad);
        }

        public void Guardar()
        {
            Context.SaveChanges();
        }

        public void Modificar(T entidad)
        {
            Context.Set<T>().Attach(entidad);
            Context.Entry(entidad).State = EntityState.Modified;
        }

        //**********************************************************//

        public IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicado)
        {
            return Context.Set<T>().AsNoTracking().Where(predicado).ToList();
        }

        public IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] incluirPropiedad)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = incluirPropiedad.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<T> ObtenerPorFiltro(Expression<Func<T, bool>> predicado, string Propiedad)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = Propiedad.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        //**********************************************************//

        public T ObtenerPorId(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public T ObtenerPorId(long id, params Expression<Func<T, object>>[] incluirPropiedad)
        {
            IQueryable<T> query = Context.Set<T>();

            query = incluirPropiedad.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == id);
        }

        public T ObtenerPorId(long id, string Propiedad)
        {
            IQueryable<T> query = Context.Set<T>();

            query = Propiedad.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == id);
        }

        //**********************************************************//

        public IEnumerable<T> ObtenerTodo()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> ObtenerTodo(params Expression<Func<T, object>>[] incluirPropiedad)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = incluirPropiedad.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<T> ObtenerTodo(string Propiedad)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = Propiedad.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }
    }
}
