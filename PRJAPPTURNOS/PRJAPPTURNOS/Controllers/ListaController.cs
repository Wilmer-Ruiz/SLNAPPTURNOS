using Microsoft.AspNetCore.Mvc;
using Entidades;
using Repositorio;

namespace PRJAPPTURNOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaController : Controller
    {
        private readonly IListasRepositorio _IListasRepositorio;
        public ListaController(IListasRepositorio ListasRepositorio)
        {
            _IListasRepositorio = ListasRepositorio;
        }

        [HttpGet("GetAllTipoPersona")]
        public async Task<IEnumerable<TipoPersona>> GetAllTipoPersona()
        {
            return await _IListasRepositorio.GetAllTipoPersona();
        }

        [HttpGet("GetAllTipoDocumento")]
        public async Task<IEnumerable<TipoDocumento>> GetAllTipoDocumento()
        {
            return await _IListasRepositorio.GetAllTipoDocumento();
        }

        [HttpGet("GetAllLugarAtencion")]
        public async Task<IEnumerable<LugarAtencion>> GetAllLugarAtencion()
        {
            return await _IListasRepositorio.GetAllLugarAtencion();
        }

        [HttpGet("GetAllLAsesorLugar/{strcodigolugar}")]
        public async Task<IEnumerable<TABLE_ASESOR>> GetAllLAsesorLugar(string strcodigolugar)
        {
            return await _IListasRepositorio.GetAllLAsesorLugar(strcodigolugar);
        }


        [HttpGet("GetAllLOCUPACION")]
        public async Task<IEnumerable<OCUPACION>> GetAllLOCUPACION([FromQuery(Name = "CodigoAsesor")] string strcodigoasesor, [FromQuery(Name = "FechaSolicitud")] string strfechareserva)
        {
            return await _IListasRepositorio.GetAllLOCUPACION(new PARAMETROS() { strcodigoasesor = strcodigoasesor, strfechareserva = strfechareserva });
        }

        [HttpGet("GetAllConsultaHorariosReservados")]
        public async Task<IEnumerable<CANCELACIONES>> GetAllConsultaHorariosReservados([FromQuery(Name = "CodigoAsesor")] string strcodigoasesor, [FromQuery(Name = "FechaSolicitud")] string strfechareserva, [FromQuery(Name = "Email")] string stremail)
        {
            return await _IListasRepositorio.GetAllConsultaHorariosReservados(new PARAMETROS() { strcodigoasesor = strcodigoasesor, strfechareserva = strfechareserva, stremail = stremail });
        }

        [HttpGet("GetAllConsultaServicioCliente")]
        public async Task<IEnumerable<CANCELACIONES>> GetAllConsultaServicioCliente()
        {
            return await _IListasRepositorio.GetAllConsultaServicioCliente();
        }

        [HttpGet("GetUser")]
        public async Task<IEnumerable<ValidacionCliente>> GetUser([FromQuery(Name = "CodigoAsesor")] string strcodigoasesor, [FromQuery(Name = "Email")] string stremail)
        {
            return await _IListasRepositorio.GetUser(new PARAMETROS() { strcodigoasesor = strcodigoasesor, stremail = stremail });
        }

    }
}
