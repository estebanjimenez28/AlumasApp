using AlumasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlumasApp
{
    public class GlobalObjects
    {
        //definimos las propiedades de codificacion de los json
        //que usaremos en los modelos

        public static string MimeType = "application/json";
        public static string ContentType = "Content-Type";

        public static UserDTO MyLocalUser = new UserDTO();
        public static ClientDTO MyLocalClient = new ClientDTO();
        public static Branch MyLocaBranch = new Branch();
    }
}

