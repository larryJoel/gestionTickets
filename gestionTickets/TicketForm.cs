using gestionTickets.funtion;
using gestionTickets.Model;
using System;
using System.Windows.Forms;

namespace gestionTickets
{
    public partial class TicketForm : Form
    {
        public string usuario;
        public TicketForm()
        {
            InitializeComponent();
            TicketRepositorio.Inicializar();
            VisualizarTickets();
        }

       /* public TicketForm(string user)
        {
            InitializeComponent();
            label2.Text = user;
            usuario = user;
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaPpal p1 = new PantallaPpal();
            p1.Show();
        }

        private void VisualizarTickets()
        {
            dataGridView1.Rows.Clear();
            foreach (Ticket t in TicketRepositorio.Tickets)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = t.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = t.NroTicket.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = t.Cliente.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = t.EmailCliente.ToString();
                dataGridView1.Rows[rowIndex].Cells[4].Value = t.Incidencia.ToString();
                dataGridView1.Rows[rowIndex].Cells[5].Value = t.Usuario.ToString();
                dataGridView1.Rows[rowIndex].Cells[6].Value = t.Fecha.ToString();
                dataGridView1.Rows[rowIndex].Cells[7].Value = t.TipoIncidencia.ToString();
                dataGridView1.Rows[rowIndex].Cells[8].Value = t.Prioridad.ToString();
                dataGridView1.Rows[rowIndex].Cells[9].Value = t.Estado.ToString();
                dataGridView1.Rows[rowIndex].Cells[10].Value = t.Solucion.ToString();
                dataGridView1.Rows[rowIndex].Cells[11].Value = t.Observaciones.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TicketAddEditForm ticketForm = new TicketAddEditForm();
            DialogResult dialogResult = ticketForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                TicketRepositorio.AddTicket(ticketForm.Ticket);
                VisualizarTickets();
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idTicketMod = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string nroTicketMod = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string clienteMod = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string emailClienteMod = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string incidenciaMod = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string usuarioMod = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string fechaMod = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();//verificar
                string tipoIncidenciaMod = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string prioridadMod = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                string estadoMod = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                string solucionMod = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                string observacionesMod = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();


                Ticket ticketModificado = new Ticket(idTicketMod, nroTicketMod, clienteMod, emailClienteMod, incidenciaMod, usuarioMod, fechaMod, tipoIncidenciaMod, prioridadMod, estadoMod, solucionMod, observacionesMod);
                TicketAddEditForm ticketFormAE = new TicketAddEditForm(ticketModificado);
                DialogResult dialogResult = ticketFormAE.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    TicketRepositorio.UpdateTicket(idTicketMod, ticketFormAE.Ticket);
                    VisualizarTickets();
                }
            }
            else
            {
                MessageBox.Show($"No seleccionado ningún Ticket para editar", " Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string idTicketEliminar = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                TicketRepositorio.DeleteTicket(idTicketEliminar);
                VisualizarTickets();
            }
            else
            {
                MessageBox.Show($"No has seleccionado ningún Ticket..!", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                SeguimientoForm seguimientoForm = new SeguimientoForm(id);
                this.Hide();
                seguimientoForm.Show();
            }
            else
            {
                MessageBox.Show($"No has seleccionado ningún Ticket..!", "Error..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
