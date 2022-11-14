using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Prueba_hotel
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();

            Clases.Usuarios usuarios = new Clases.Usuarios();
            usuarios.mostrarUsuarios(mostrarUser);
        }

        private void mostrarUser_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //clases.Usuario usuario = new clases.Usuario();
            //usuario.seleccionarUsuario(dataGridView1, txId, txNombre, txApellido, txEdad);

            Clases.Usuarios usuario = new Clases.Usuarios();
            usuario.seleccionarUsuario(mostrarUser, txtID);
        }

        private void btnBorrarUser_Click(object sender, EventArgs e)
        {
            //Usuarios usuario = new Usuarios();
            Clases.Usuarios usuario = new Clases.Usuarios();
            usuario.eliminarrUsuario(txtID);
            usuario.mostrarUsuarios(mostrarUser);
        }
    }
}
