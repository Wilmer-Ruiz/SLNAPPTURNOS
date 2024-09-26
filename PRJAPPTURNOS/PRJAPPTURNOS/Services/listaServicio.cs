using Entidades;
using System.Net.Http.Json;

namespace PRJAPPTURNOS.Services
{
    public class listaServicio : IlistaServicio
    {
        private readonly HttpClient _httpClient;
        public listaServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TipoDocumento>> GetAllTipoDocumento()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TipoDocumento>>($"api/Lista/GetAllTipoDocumento");

        }

        public async Task<IEnumerable<TipoPersona>> GetAllTipoPersona()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TipoPersona>>($"api/Lista/GetAllTipoPersona");
        }

        public async Task<IEnumerable<LugarAtencion>> GetAllLugarAtencion()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<LugarAtencion>>($"api/Lista/GetAllLugarAtencion");
        }

        public async Task<IEnumerable<TABLE_ASESOR>> GetAllLAsesorLugar(string? strcodigolugar)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TABLE_ASESOR>>($"api/Lista/GetAllLAsesorLugar/{strcodigolugar}");
        }

        public async Task<IEnumerable<OCUPACION>> GetAllLOCUPACION(PARAMETROS objparametros)
        {
            try
            {
                var urlParams = new Dictionary<string, string>{
             { "CodigoAsesor", objparametros.strcodigoasesor },
             { "FechaSolicitud", objparametros.strfechareserva }
         };
                var encodedParams = new FormUrlEncodedContent(urlParams);
                var paramText = await encodedParams.ReadAsStringAsync();

                return await _httpClient.GetFromJsonAsync<IEnumerable<OCUPACION>>($"api/Lista/GetAllLOCUPACION?{paramText}");
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async Task<IEnumerable<CANCELACIONES>> GetAllConsultaHorariosReservados(PARAMETROS objparametros)
        {
            try
            {
                var urlParams = new Dictionary<string, string>{
             { "CodigoAsesor", objparametros.strcodigoasesor },
             { "FechaSolicitud", objparametros.strfechareserva },
             { "Email", objparametros.stremail }
         };
                var encodedParams = new FormUrlEncodedContent(urlParams);
                var paramText = await encodedParams.ReadAsStringAsync();

                return await _httpClient.GetFromJsonAsync<IEnumerable<CANCELACIONES>>($"api/Lista/GetAllConsultaHorariosReservados?{paramText}");
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async Task<IEnumerable<CANCELACIONES>> GetAllConsultaServicioCliente()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<IEnumerable<CANCELACIONES>>($"api/Lista/GetAllConsultaServicioCliente");
            }
            catch (Exception e)
            {

                throw e;
            }

        }


        public async Task<IEnumerable<ValidacionCliente>> GetUser(PARAMETROS objparametros)
        {
            try
            {
                var urlParams = new Dictionary<string, string>{
             { "CodigoAsesor", objparametros.strcodigoasesor },
             { "Email", objparametros.stremail }
         };
                var encodedParams = new FormUrlEncodedContent(urlParams);
                var paramText = await encodedParams.ReadAsStringAsync();

                return await _httpClient.GetFromJsonAsync<IEnumerable<ValidacionCliente>>($"api/Lista/GetUser?{paramText}");
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
