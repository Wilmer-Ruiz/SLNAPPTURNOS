using Entidades;

namespace PRJAPPTURNOS.Services
{
    public interface IgrabarClienteServicio
    {
        Task InsertClientes(TABLE_CLIENTES_TURNOS ClientesTurnos);
        Task GrabarCita(TABLE_ASESOR_HORARIO Models_Clientes_Citasx);
        Task DeleteReserva(PARAMETROS objparametros);
        Task ActualizacionAtencionCliente(PARAMETROS objparametros);

    }
}
