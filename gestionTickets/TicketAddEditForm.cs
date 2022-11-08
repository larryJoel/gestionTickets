using gestionTickets.funtion;
using gestionTickets.Model;
using System;
using System.Net.Mail;
using System.Windows.Forms;


namespace gestionTickets
{
    public partial class TicketAddEditForm : Form
    {
        public Ticket Ticket { get; private set; }  
        public TicketAddEditForm()
        {
            InitializeComponent();
        }
        public TicketAddEditForm(Ticket ticket)
        {
            InitializeComponent();
            tbxIdTicket.Text = ticket.Id;
            tbxNroTicket.Text = ticket.NroTicket;
            tbxCliente.Text = ticket.Cliente;
            tbxEmailCliente.Text = ticket.EmailCliente;
            tbxIncidencia.Text = ticket.Incidencia;
            tbxUsuario.Text = ticket.Usuario;
            dTFecha.Text = ticket.Fecha;
            cbxTipoIncidencia.Text=ticket.TipoIncidencia;
            cbxPrioridad.Text = ticket.Prioridad;
            cbxEstado.Text = ticket.Estado;
            tbxSolucion.Text = ticket.Solucion;
            tbxObservaciones.Text = ticket.Observaciones;

        }

        private void TicketAddEditForm_Load(object sender, EventArgs e)
        {
            TicketRepositorio ticketRepositorio = new TicketRepositorio();
            if (tbxIdTicket.Text == "") 
            {
                tbxIdTicket.Text = ticketRepositorio.GenerarID();
                tbxNroTicket.Text = ticketRepositorio.GenerarNroTicket();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ticketValidado = ValidarDatosTickets(out string errorMsq);
            if (ticketValidado)
            {
                Ticket = new Ticket(tbxIdTicket.Text, tbxNroTicket.Text, tbxCliente.Text, tbxEmailCliente.Text, tbxIncidencia.Text, tbxUsuario.Text, dTFecha.Text, cbxTipoIncidencia.Text, cbxPrioridad.Text, cbxEstado.Text, tbxSolucion.Text, tbxObservaciones.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(errorMsq, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }

        }
        private bool ValidarDatosTickets(out string errorMsq)
        {
            errorMsq = string.Empty;
            if (string.IsNullOrEmpty(tbxIdTicket.Text))
            {
                errorMsq = $"El id del Ticket no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxNroTicket.Text))
            {
                errorMsq = $"El Nro. del Ticket no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxCliente.Text))
            {
                errorMsq = $"El nombre del cliente no puede estar vacio{Environment.NewLine}";
            }
          
            if (string.IsNullOrEmpty(tbxIncidencia.Text))
            {
                errorMsq = $"La incidencia no puede estar vacia{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxUsuario.Text))
            {
                errorMsq = $"El nombre del usuario que atiende no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(dTFecha.Text))
            {
                errorMsq = $"El campo de fecha no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(cbxTipoIncidencia.Text))
            {
                errorMsq = $"El tipo de incidencia no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(cbxPrioridad.Text))
            {
                errorMsq = $"El campo de Prioridad no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(cbxEstado.Text))
            {
                errorMsq = $"El estado no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxSolucion.Text))
            {
                errorMsq = $"La solución no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxObservaciones.Text))
            {
                errorMsq = $"El campo de observaciones no puede estar vacio{Environment.NewLine}";
            }
            try
            {
                new MailAddress(tbxEmailCliente.Text);
            }
            catch (Exception)
            {

                errorMsq = $"El email del cliente no puede estar vacio{Environment.NewLine}";
            }
            return errorMsq == string.Empty;

        }
    }
}
