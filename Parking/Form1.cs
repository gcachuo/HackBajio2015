using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parking
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'estacionamientoDataSet.Consulta' table. You can move, or remove it, as needed.
            this.consultaTableAdapter.Fill(this.estacionamientoDataSet.Consulta);

        }
    }
}
