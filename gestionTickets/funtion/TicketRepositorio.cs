using gestionTickets.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace gestionTickets.funtion
{
    public class TicketRepositorio
    {
        private const string _Ruta = @"c:\Json Sample\Ticket.json";
        public static List<Ticket> Tickets { get; private set; }
        public static void Inicializar()
        {
            if (File.Exists(_Ruta))
            {
                string json = File.ReadAllText(_Ruta);
                Tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);
            }
            else
            {
                Tickets = new List<Ticket>();
            }
        }
        public static void AddTicket( Ticket ticket)
        {
            Tickets.Add(ticket);
            string json = JsonConvert.SerializeObject(Tickets,Formatting.Indented);
            File.WriteAllText(_Ruta, json);
        }
        public static  void DeleteTicket(string id)
        {   
            Tickets.RemoveAll(e => e.Id.Equals(id));
            string json = JsonConvert.SerializeObject(Tickets,Formatting.Indented);
            File.WriteAllText(id, json);
        }
        public static void UpdateTicket(string idTicketOrig, Ticket ticketModificado)
        {
            int indiceTicketOriginal = Tickets.FindIndex(e => e.Id == idTicketOrig);
            if (indiceTicketOriginal != -1)
            {
                Tickets[indiceTicketOriginal] = ticketModificado;
            }
            string json = JsonConvert.SerializeObject(Tickets,Formatting.Indented);
            File.WriteAllText(_Ruta, json);
        }
        public string GenerarID()
        {
            int incremento = 0;
            foreach (Ticket u in Tickets)
            {
                incremento = int.Parse(u.Id) + 1;
            }
            return incremento.ToString();
        }
        public string GenerarNroTicket()
        {
                
                Random random = new Random();
                const string chars = "1234567890ABCDEFGHIJK";
                string NroTicket = new string(Enumerable.Repeat(chars, 9).Select(s => s[random.Next(s.Length)]).ToArray());
                return NroTicket;
        }
    }
}
