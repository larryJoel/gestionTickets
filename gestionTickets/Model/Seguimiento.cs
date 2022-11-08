using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTickets.Model
{
    public class Seguimiento
    {
        public Seguimiento(string id, string nroTicket, string estado, string usuario, string fecha, string mensaje)
        {
            Id = id;
            NroTicket = nroTicket;
            Estado = estado;
            Usuario = usuario;
            Fecha = fecha;
            Mensaje = mensaje;
        }

        public string Id { set; get; }
        public string NroTicket { set; get; }
        public string Estado { set; get; }
        public string Usuario { set; get; }
        public string Fecha { set; get; }
        public string Mensaje { set; get; }
    }
}
