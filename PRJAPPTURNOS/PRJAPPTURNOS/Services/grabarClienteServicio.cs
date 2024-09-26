using Entidades;

namespace PRJAPPTURNOS.Services
{
    public class grabarClienteServicio : IgrabarClienteServicio
    {
        private readonly HttpClient _httpClient;
        public grabarClienteServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task InsertClientes(TABLE_CLIENTES_TURNOS ClientesTurnos)
        {
            try
            {
                //insert
                var data = await _httpClient.PostAsJsonAsync<TABLE_CLIENTES_TURNOS>($"api/GrabarClientes/PostGrabar", ClientesTurnos);
            }
            catch (Exception E)
            {

                throw E;
            }

        }



        public async Task GrabarCita(TABLE_ASESOR_HORARIO Models_Clientes_Citasx)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync<TABLE_ASESOR_HORARIO>($"api/GrabarClientes/GrabarCita", Models_Clientes_Citasx);

                //if (response.IsSuccessStatusCode)
                //{

                //}
                //else
                //{
                //    throw new Exception(string.Concat(response.StatusCode.ToString(),response.Content.ToString(),response.RequestMessage.ToString(), response.Content.ReadAsStringAsync().Result));

                //    //Console.WriteLine("Internal server Error");
                //}
            }
            catch (Exception E)
            {

                throw E;
            }
        }

        public async Task DeleteReserva(PARAMETROS objparametros)
        {
            var urlParams = new Dictionary<string, string>{
             { "CodigoReserva", objparametros.strcodigoasesor },
             { "EmailCliente", objparametros.stremail }
         };
            var encodedParams = new FormUrlEncodedContent(urlParams);
            var paramText = await encodedParams.ReadAsStringAsync();

            await _httpClient.DeleteAsync($"api/GrabarClientes/DeleteReserva?{paramText}");
        }

        public async Task ActualizacionAtencionCliente(PARAMETROS objparametros)
        {
            var urlParams = new Dictionary<string, string>{
             { "strcodigoreserva", objparametros.strcodigoasesor },
             { "estado", objparametros.strfechareserva },
             { "mensaje", objparametros.stremail },
         };
            var encodedParams = new FormUrlEncodedContent(urlParams);
            var paramText = await encodedParams.ReadAsStringAsync();

            try
            {
                await _httpClient.DeleteAsync($"api/GrabarClientes/ActualizacionAtencionCliente?{paramText}");
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
