using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using User = gestionTickets.Model.User;

namespace gestionTickets.funtion
{
    public static class AccesoUsuario
    {
        private const string _path = @"c:\Json Sample\Usuario.json";
        private static string GetUserFromFile()
        {
            string userJsonFronFile;
            using (var reader = new StreamReader(_path))
            {
                userJsonFronFile = reader.ReadToEnd();
            }
            return userJsonFronFile;
        }
        private static List<User> DeserializeJsonFile()
        {
            var contact = JsonConvert.DeserializeObject<List<User>>(GetUserFromFile());
            return contact;
        }

        public static bool validarUsuario(string UserName, string Password)
        {
            var listaDeUsuarios = DeserializeJsonFile();
            if (listaDeUsuarios.Any(a => a.Usuario == UserName && a.Password == Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string MostrarUser(string usuario, string pass)
        {
            var lista = DeserializeJsonFile();
            
            if(lista.Any(a => a.Usuario == usuario && a.Password == pass))
            {
                foreach (var este in lista)
                {
                    if (este.Usuario == usuario && este.Password == pass){
                        string nombreApellido = este.Apellido + ", " + este.Nombre;
                        return nombreApellido;
                    }
                }
                
            }
            return "";
        }

    }
}
