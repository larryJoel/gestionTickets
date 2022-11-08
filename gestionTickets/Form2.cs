using gestionTickets.funtion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using gestionTickets.Model;

namespace gestionTickets
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            UsuarioRepositorio.InizializarRepositorio();
            VisualizarUsuario();

        }

        private void VisualizarUsuario()
        {
            dataGridView1.Rows.Clear();
            foreach (Model.User usuario in UsuarioRepositorio.Usuarios)
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells[0].Value = usuario.Id.ToString();
                dataGridView1.Rows[rowIndex].Cells[1].Value = usuario.Nombre.ToString();
                dataGridView1.Rows[rowIndex].Cells[2].Value = usuario.Apellido.ToString();
                dataGridView1.Rows[rowIndex].Cells[3].Value = usuario.Dni.ToString();
                dataGridView1.Rows[rowIndex].Cells[4].Value = usuario.Cargo.ToString();
                dataGridView1.Rows[rowIndex].Cells[5].Value = usuario.Email.ToString();
                dataGridView1.Rows[rowIndex].Cells[6].Value = usuario.Usuario.ToString();
                dataGridView1.Rows[rowIndex].Cells[7].Value = usuario.Sector.ToString();
                dataGridView1.Rows[rowIndex].Cells[8].Value = usuario.Password.ToString();
                dataGridView1.Rows[rowIndex].Cells[9].Value = usuario.nivelAcceso.ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UsarioForm usuarioForm = new UsarioForm();
            DialogResult dialogResult =  usuarioForm.ShowDialog();
            if(dialogResult == DialogResult.OK)
            {
                UsuarioRepositorio.AddUsuario(usuarioForm.Usuarios);
                VisualizarUsuario();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string idUsuarioEliminar = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                UsuarioRepositorio.DeleteUsuario(idUsuarioEliminar);
                VisualizarUsuario();
            }
            else
            {
                MessageBox.Show($"No se ha seleccionado ningún usuario...!", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string idUsuarioMod = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string NombreUsuarioMod = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string apellidoUsuarioMod = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string dniUsuarioMod = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string cargoUsuarioMod = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string emailUsuarioMod = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string usuarioUsuarioMod = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                string sectorUsuarioMod = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                string passwordUsuarioMod = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                string nivelAccesoUsuarioMod = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                User usuarioModificar = new User(idUsuarioMod, NombreUsuarioMod, apellidoUsuarioMod, dniUsuarioMod, cargoUsuarioMod, emailUsuarioMod, usuarioUsuarioMod, sectorUsuarioMod, passwordUsuarioMod, nivelAccesoUsuarioMod);
                UsarioForm usuarioForm = new UsarioForm(usuarioModificar);
                DialogResult dialogResult = usuarioForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    UsuarioRepositorio.UpdateUsuario(idUsuarioMod, usuarioForm.Usuarios);
                    VisualizarUsuario();
                }
            }
            else
            {
                MessageBox.Show($"No se ha seleccionado un usuario para editar..!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PantallaPpal p1 = new PantallaPpal();
            p1.Show();
        }
    }
}
