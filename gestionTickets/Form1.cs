using gestionTickets.funtion;
using System;
using System.Windows.Forms;

namespace gestionTickets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            void limpiar()
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
            var res = AccesoUsuario.validarUsuario(textBox1.Text, textBox2.Text);
            if (res)
            {
                
                string user = AccesoUsuario.MostrarUser(textBox1.Text, textBox2.Text);
                MessageBox.Show($"Bienvenido(a) {user} al sistema");
                PantallaPpal p1 = new PantallaPpal();
                limpiar();
                this.Hide();
                p1.Show();  

            }
            else
            {
                MessageBox.Show("El usuario o el password es incorrecto", "Error..!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                limpiar();
            }
        }
    }
}
