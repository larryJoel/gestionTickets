using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestionTickets.funtion;
using gestionTickets.Model;

namespace gestionTickets
{
    public partial class UsarioForm : Form
    {
        public User Usuarios { get; private set; }

        public UsarioForm()
        {
            InitializeComponent();
        }

        public UsarioForm(User usuario)
        {
            InitializeComponent();
            tbxIdUsuario.Text = usuario.Id;
            tbxNombre.Text = usuario.Nombre;
            tbxApellido.Text= usuario.Apellido;
            tbxDni.Text = usuario.Dni;
            tbxCargo.Text = usuario.Cargo;
            tbxEmail.Text = usuario.Email;
            tbxUsuario.Text = usuario.Usuario;
            tbxSector.Text = usuario.Sector;
            tbxPassword.Text = usuario.Password;
            tbxNivelAcceso.Text = usuario.nivelAcceso;
        }

        private void UsarioForm_Load(object sender, EventArgs e)
        {
            UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();
            tbxIdUsuario.Text = usuarioRepositorio.GenerarID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool usuarioValidado = ValidarUsuario(out string ErrorMsg);
            if (usuarioValidado)
            {   
                
                Usuarios = new User(tbxIdUsuario.Text, tbxNombre.Text, tbxApellido.Text, tbxDni.Text, tbxCargo.Text, tbxEmail.Text, tbxUsuario.Text, tbxSector.Text, tbxPassword.Text, tbxNivelAcceso.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(ErrorMsg,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }

        }
        private bool ValidarUsuario(out string errorMsg)
        {
            errorMsg = string.Empty;
            if (string.IsNullOrEmpty(tbxIdUsuario.Text))
            {
                errorMsg = $"El Id no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxNombre.Text))
            {
                errorMsg = $"El Nombre no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxApellido.Text))
            {
                errorMsg = $"El apellido no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxDni.Text))
            {
                errorMsg = $"El DNI no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxCargo.Text))
            {
                errorMsg = $"El Cargo no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxUsuario.Text))
            {
                errorMsg = $"El Usuario no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxSector.Text))
            {
                errorMsg = $"El sector no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxPassword.Text))
            {
                errorMsg = $"El password no puede estar vacio{Environment.NewLine}";
            }
            if (string.IsNullOrEmpty(tbxNivelAcceso.Text))
            {
                errorMsg = $"El nivel de acesso no puede estar vacio{Environment.NewLine}";
            }
            
            try
            {
                new MailAddress(tbxEmail.Text);
            }
            catch (Exception )
            {

                errorMsg = $"El Email debe tener el formato adecuado{Environment.NewLine}";
            }

            return errorMsg == String.Empty;
        }
    }
}
