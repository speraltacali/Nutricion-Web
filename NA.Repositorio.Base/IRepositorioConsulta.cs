using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NA.Repositorio.Base
{
    public interface IRepositorioConsulta<T> where T : BaseEntity
    {
        T ObtenerPorId(long id);

        T ObtenerPorId(long id , params Expression<Func<T , object>> [] incluirPropiedad);

        T ObtenerPorId(long id , string Propiedad);

        //**********************************************************//

        IEnumerable<T> ObtenerTodo();

        IEnumerable<T> ObtenerTodo(params Expression<Func<T,object>>[] incluirPropiedad);

        IEnumerable<T> ObtenerTodo(string Propiedad);

        //**********************************************************//

        IEnumerable<T> ObtenerPorFiltro(Expression<Func<T,bool>> predicado);

        IEnumerable<T> ObtenerPorFiltro(Expression<Func<T,bool>> predicado ,
            params Expression<Func<T,object>>[] incluirPropiedad);

        IEnumerable<T> ObtenerPorFiltro(Expression<Func<T,bool>> predicado , string Propiedad);

        //**********************************************************//
    }
}
