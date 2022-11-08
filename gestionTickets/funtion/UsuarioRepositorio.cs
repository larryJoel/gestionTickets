using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using gestionTickets.Model;
using Formatting = Newtonsoft.Json.Formatting;
using System.Security.Cryptography;

namespace gestionTickets.funtion
{
    public class UsuarioRepositorio
    {
        private const string _ruta = @"c:\Json Sample\Usuario.json";
        public static List<User> Usuarios { get; private set; }
        public static void InizializarRepositorio()
        {
            if (File.Exists(_ruta))
            {
                string json = File.ReadAllText(_ruta);
                Usuarios = JsonConvert.DeserializeObject<List<User>>(json);
            }
            else
            {
                Usuarios = new List<User>();
            }
        }
        public static void AddUsuario(User usuario)
        {
            Usuarios.Add(usuario);
            string json = JsonConvert.SerializeObject(Usuarios, Formatting.Indented);
            File.WriteAllText(_ruta, json);
        }
        public static void DeleteUsuario(string id)
        {
            Usuarios.RemoveAll(e => e.Id.Equals(id));
            string json = JsonConvert.SerializeObject(Usuarios, Formatting.Indented);
            File.WriteAllText(_ruta, json);
        }
        public static void UpdateUsuario(string idOrigen, User usuarioModificado)
        {
            int indiceOriginal = Usuarios.FindIndex(e => e.Id == idOrigen);
            if(indiceOriginal != -1)
            {
                Usuarios[indiceOriginal] = usuarioModificado;
            }
            string json = JsonConvert.SerializeObject(Usuarios, Formatting.Indented);
            File.WriteAllText(_ruta, json);
        }
        public string GenerarID()
        {
            int incremento = 0;
            foreach (User u in Usuarios)
            {
                incremento = int.Parse(u.Id) + 1;
            }
            return incremento.ToString();
        }
    }
    
}