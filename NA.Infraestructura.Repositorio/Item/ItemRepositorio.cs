using NA.Dominio.Entidades.Entidades;
using NA.Dominio.Repositorio.Item;
using NA.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA.Infraestructura.Repositorio.Item
{
    public class ItemRepositorio : Repositorio<NA.Dominio.Entidades.Entidades.Item> , IItemRepositorio
    {
    }
}
