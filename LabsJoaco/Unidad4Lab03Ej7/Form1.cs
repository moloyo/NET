using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unidad4Lab03Ej7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.customersTableAdapter.Fill(this.net2017DataSet.customers);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'net2017DataSet.customers' Puede moverla o quitarla según sea necesario.
            this.customersTableAdapter.Fill(this.net2017DataSet.customers);

        }
    }
}
