using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTickets.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Sector { get; set; }
        public string Password { get; set; }
        public string nivelAcceso { get; set; }

        public User(string id, string nombre, string apellido, string dni, string cargo, string email, string usuario, string sector, string password, string nivelAcceso)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Cargo = cargo;
            Email = email;
            Usuario = usuario;
            Sector = sector;
            Password = password;
            this.nivelAcceso = nivelAcceso;
        }

    }
}
