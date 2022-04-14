using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProjAndreAirLinesAPI3._0Models;
using Newtonsoft.Json;

namespace Service
{
    public class ServicoBuscaApi
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<Usuario> BuscarLoginSenhaNaApiUsuario(string login, string senha)
        {
            try
            {
                HttpResponseMessage  response = await client.GetAsync("https://localhost:44361/api/Usuarios/LoginSenha?login=" + login + "&senha=" + senha);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var UsuarioJson = JsonConvert.DeserializeObject<Usuario>(responseBody);
                return UsuarioJson;
            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}
