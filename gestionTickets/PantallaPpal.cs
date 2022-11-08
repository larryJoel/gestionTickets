using System;
using System.Windows.Forms;

namespace gestionTickets
{
    public partial class PantallaPpal : Form
    {
     
        public PantallaPpal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            TicketForm ticket = new TicketForm();
            ticket.Show();
        }
    }
}
