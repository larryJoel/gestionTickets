using gestionTickets.funtion;
using gestionTickets.Model;
using System;
using System.IO;
using System.Windows.Forms;


namespace gestionTickets
{
    public partial class SeguimientoForm : Form
    {
        string validarId;
       public SeguimientoForm()
        {
            InitializeComponent();
        }
        public SeguimientoForm(string id)
        {
            InitializeComponent();
            validarId = id;
            label1.Text =  SeguimientoRepositorio.Mostrar(id);
            textBox1.Text = SeguimientoRepositorio.Seguimiento(id);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            TicketForm p1 = new TicketForm();
            p1.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SeguimientoRepositorio.CargarSeguimiento(textBox2.Text,textBox3.Text);
            textBox3.Text = "";
            textBox2.Text = "";
            label1.Text = SeguimientoRepositorio.Mostrar(validarId);
            textBox1.Text = SeguimientoRepositorio.Seguimiento(validarId);

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SeguimientoRepositorio.PrintSeguimiento();
        }
    }

}

