using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Unidad3Lab2
{
    public partial class formListaUsuarios : Form
    {
        private Usuario usuarios;

        public Entidades.Usuario oUsuarios
        {
            get { return usuarios; }
            set { usuarios = value; }
        }
        public formListaUsuarios()
        {
            InitializeComponent();
            this.oUsuarios = new Entidades.Usuario();
            this.dgvUsuarios.DataSource = this.oUsuarios.GetAll();
        }

        private void formListaUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarCambios();
            this.RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            this.dgvUsuarios.DataSource = this.usuarios.GetAll();
        }

        private void GuardarCambios()
        {
            this.usuarios.GuardarCambios((DataTable)this.dgvUsuarios.DataSource);
        }
    }
}
