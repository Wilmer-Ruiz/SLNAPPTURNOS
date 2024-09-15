using Entidades;

namespace Repositorio
{
    public interface IListasRepositorio
    {
        Task<IEnumerable<TipoPersona>> GetAllTipoPersona();
        Task<IEnumerable<TipoDocumento>> GetAllTipoDocumento();
        Task<IEnumerable<LugarAtencion>> GetAllLugarAtencion();
        Task<IEnumerable<TABLE_ASESOR>> GetAllLAsesorLugar(string? strcodigolugar);
        Task<IEnumerable<OCUPACION>> GetAllLOCUPACION(PARAMETROS objparametros);
        Task<IEnumerable<CANCELACIONES>> GetAllConsultaHorariosReservados(PARAMETROS objparametros);
        Task<IEnumerable<CANCELACIONES>> GetAllConsultaServicioCliente();

        Task<IEnumerable<ValidacionCliente>> GetUser(PARAMETROS objparametros);
    }
}
