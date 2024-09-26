using Entidades;

namespace Repositorio
{
    public interface IGrabarClientes
    {
        Task<bool> InsertClientes(TABLE_CLIENTES_TURNOS ClientesTurnos);
        Task<bool> GrabarCita(TABLE_ASESOR_HORARIO Models_Clientes_Citasx);
        Task DeleteReserva(string? strcodigoreserva);
        Task ActualizacionAtencionCliente(string? strcodigoreserva, string? estado, string? mensaje);
    }
}
