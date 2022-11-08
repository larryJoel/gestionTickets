using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionTickets.Model
{
    public class Ticket
    {
        public string Id { get; set; }
        public string NroTicket { get; set; }
        public string Cliente { get; set; }
        public string EmailCliente { get; set; }
        public string Incidencia { get; set; }
        public string Usuario { get; set; }
        public string Fecha { get; set; }
        public string TipoIncidencia { get; set; }
        public string Prioridad { get; set; }
        public string Estado { get; set; }
        public string Solucion { get; set; }
        public string Observaciones { get; set; }
        public Ticket(string id, string nroTicket, string cliente, string emailCliente, string incidencia, string usuario, string fecha, string tipoIncidencia, string prioridad, string estado, string solucion, string observaciones)
        {
            Id = id;
            NroTicket = nroTicket;
            Cliente = cliente;
            EmailCliente = emailCliente;
            Incidencia = incidencia;
            Usuario = usuario;
            Fecha = fecha;
            TipoIncidencia = tipoIncidencia;
            Prioridad = prioridad;
            Estado = estado;
            Solucion = solucion;
            Observaciones = observaciones;
        }

    }
}
