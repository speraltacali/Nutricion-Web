using NA.Repositorio;
using NA.Dominio.Entidades.Entidades;
using NA.Dominio.Repositorio.Paciente;

namespace NA.Infraestructura.Repositorio.Paciente
{
    public class PacienteRepositorio : Repositorio<Dominio.Entidades.Entidades.Paciente> , IPacienteRepositorio
    {
    }
}
