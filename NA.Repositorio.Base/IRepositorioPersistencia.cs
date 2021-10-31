using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Repositorio.Base
{
    public interface IRepositorioPersistencia<T> where T : BaseEntity
    {
        void Agregar(T entidad);

        void Modificar(T entidad);

        void Eliminar(long id);

        void Guardar();
    }
}
