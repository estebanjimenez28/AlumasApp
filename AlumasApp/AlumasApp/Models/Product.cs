using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlumasApp.Models
{
    public class Product
    {
        public RestRequest Request { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Quantity { get; set; }
        public int Price { get; set; }
        public bool Active { get; set; }
        public int BranchBranchId { get; set; }
        public int ClientsClientId { get; set; }
        public int ProductCategoryProductCategoryId { get; set; }

        public virtual Client ClientsClient { get; set; } = null!;

        public Product()
        {
            Active = true;


        }


      
        public async Task<bool> AddProductAsync()
        {
            try
            {

                //usaremos el prefijo de la ruta URL del API que se indica en
                //services\APIConnection para agregar el sufijo y lograr la ruta
                //completa de consumo del end point que se quiere usar.

                string RouteSufix = String.Format("Products");

                //armamos la rura completa al endpoint en el API
                string URL = Services.APIConnection.ProductionPrefixURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);

                //agregamos mecanismo de seguridad, en este caso API key

                Request.AddHeader(Services.APIConnection.ApiKeyName, Services.APIConnection.ApiKeyValue);



                //en el caso de una operacion POST debemos serializar el objeto para pasarlo como
                //json al API

                string SerializeModelObject = JsonConvert.SerializeObject(this);
                //agregamos el objeto serializado en el cuerpo del request
                Request.AddBody(SerializeModelObject, GlobalObjects.MimeType);


                //ejecutar la llamada al API

                RestResponse response = await client.ExecuteAsync(Request);

                //saber si las cosas salieron bien

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
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
