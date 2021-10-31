using NA.Dominio.Entidades.Entidades;
using NA.Dominio.Repositorio.ItemDetalle;
using NA.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Infraestructura.Repositorio.ItemDetalle
{
    public class ItemDetalleRepositorio : Repositorio<NA.Dominio.Entidades.Entidades.ItemDetalle> , IItemDetalleRepositorio
    {
    }
}
