using NA.Dominio.Base.BaseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Repositorio.Base
{
    public interface IRepositorio<T> : IRepositorioConsulta<T> , IRepositorioPersistencia<T> where T : BaseEntity
    {
    }
}
