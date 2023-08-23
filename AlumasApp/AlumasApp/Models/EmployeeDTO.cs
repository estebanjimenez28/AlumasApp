using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlumasApp.Models
{
    public class EmployeeDTO
    {
        public RestRequest Request { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string BackUpEmail { get; set; } = null!;
        public string EmployeeAddress { get; set; } = null!;
        public string EmployeePhoneNumber { get; set; } = null!;
        public bool Active { get; set; }
        public int BranchBranchId { get; set; }
        public string Name { get; set; } = null!;

        //Funciones 

        public async Task<EmployeeDTO> GetEmployeeInfo(string PemployeeName)
        {
            try
            {


                //usaremos el prefijo de la ruta URL del API que se indica en
                //services\APIConnection para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar.

                string RouteSufix = String.Format("Employees/GetInfoByEmployeeName?PemployeeName={0}", PemployeeName);

                //armamos la rura completa al endpoint en el API
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                //agregamos mecanismo de seguridad, en este caso API key

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);
                Request.AddHeader(GlobalObjects.ContentType, GlobalObjects.MimeType);

                //ejecutar la llamada al API

                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<EmployeeDTO>>(response.Content);
                    var item = list[0];
                    return item;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;

                throw;
            }

        }


    }
}
