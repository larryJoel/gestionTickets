using gestionTickets.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace gestionTickets.funtion
{
    public class SeguimientoRepositorio
    {
        private const string _Ruta = @"c:\Json Sample\Ticket.json";
        private const string _Seguir = @"c:\Json Sample\Seguimiento.json";
        private static string idTicket;
        private static string estadoTicket;
        
        public static List<Seguimiento> Sequimiento { get; private set; }
        public static void InicializarSeg()
        {
            if (File.Exists(_Seguir))
            {
                string json = File.ReadAllText(_Seguir);
                Sequimiento = JsonConvert.DeserializeObject<List<Seguimiento>>(json);
            }
            else
            {
                Sequimiento = new List<Seguimiento>();
            }
        }
        public static string Mostrar(string id)
        {
            try
            {
                string ticketFile;
                
                using (var reader = new StreamReader(_Ruta))
                {
                    ticketFile = reader.ReadToEnd();
                }
                var resultado = JsonConvert.DeserializeObject<List<Ticket>>(ticketFile);

                int indiceTicketOriginal = resultado.FindIndex(e => e.NroTicket == id);
                idTicket = resultado[indiceTicketOriginal].NroTicket;
                estadoTicket=resultado[indiceTicketOriginal].Estado;
                return string.Format("Nro. del ticket: " + resultado[indiceTicketOriginal].NroTicket + " / " + resultado[indiceTicketOriginal].Fecha
                    + Environment.NewLine + "Cliente: " + resultado[indiceTicketOriginal].Cliente + " - " + resultado[indiceTicketOriginal].EmailCliente
                    + Environment.NewLine + "Tipo de incidencia: " + resultado[indiceTicketOriginal].TipoIncidencia
                    + Environment.NewLine + "Incidencia: " + resultado[indiceTicketOriginal].Incidencia
                    + Environment.NewLine + "Estado: " + resultado[indiceTicketOriginal].Estado
                    + Environment.NewLine + "Observaciones: " + resultado[indiceTicketOriginal].Observaciones
                    + Environment.NewLine + Environment.NewLine + "Soluciones: " + resultado[indiceTicketOriginal].Solucion);
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado..!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                throw;
            } 
        }
        public static string Seguimiento(string id)
        {
            try
            {
                var salida = "";
                var temporal = "";
                string SeguimientoFiel;
                using (var leer = new StreamReader(_Seguir))
                {
                    SeguimientoFiel = leer.ReadToEnd();
                }
                
                var seguido = JsonConvert.DeserializeObject<List<Seguimiento>>(SeguimientoFiel);

                List<Seguimiento> SegOriginal = new List<Seguimiento>();
                SegOriginal = seguido.FindAll(f => f.NroTicket == id);

                foreach (var m in SegOriginal)
                {
                    temporal = string.Format($"Usuario: {m.Usuario}"
                       + Environment.NewLine + $"Nro: {m.NroTicket} - Estado: {m.Estado} - Fecha: {m.Fecha}"
                       + Environment.NewLine + $"Mensaje: {m.Mensaje}");
                    salida = temporal + Environment.NewLine + Environment.NewLine + salida + Environment.NewLine;
                }

                return salida;
            }
            catch (Exception)
            {
                MessageBox.Show("Error inesperado..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
           
        }
        public static string generarIdSeg()
        {
            InicializarSeg();
            int incremento = 0;
            foreach (Seguimiento u in Sequimiento)
            {
                incremento = int.Parse(u.Id) + 1;
            }
            return incremento.ToString();
        }
        public static void CargarSeguimiento(string comentario, string user)
        {
            string id = generarIdSeg();
            string NroTicket = idTicket;
            string usuario = user;
            string Estado = estadoTicket;
            string fecha = DateTime.Now.ToLongDateString();
            string comentado = comentario;
            Seguimiento seg = new Seguimiento(id, NroTicket, Estado, usuario, fecha,comentario);
            Sequimiento.Add(seg);
            string json = JsonConvert.SerializeObject(Sequimiento, Formatting.Indented);
            File.WriteAllText(_Seguir, json);
        }
        public static void PrintSeguimiento()
        {

            //idTicket;
            string temporal="";
            string salida="";
            //Seguimiento(idTicket);
            TextWriter escribir = new StreamWriter("C:\\Json Sample\\Test.txt");
            escribir.WriteLine("Seguimiento del Ticket Nro."+ idTicket);
            escribir.WriteLine("***************************************");
            escribir.WriteLine(Seguimiento(idTicket));
            escribir.WriteLine("***************************************");
            MessageBox.Show("Se imprimió correctamente el Seguimiento");
            escribir.Close();
        }

    }
}
