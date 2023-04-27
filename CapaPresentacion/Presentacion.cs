using CapaNegocios;
using CE_Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Presentacion : Form
    {
        CN_Vendedores oCN_Vendedores = new CN_Vendedores();


        public Presentacion()
        {
            InitializeComponent();
        }


        private void Presentacion_Load(object sender, EventArgs e)
        {
            TraerNombreVendedor();
        }


        private void BtnDesarrolladores_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Desarrollado por:\nSantiago Bonilla Ramírez\nMiguel Ángel Cadavid");
        }


        private void TraerNombreVendedor()
        {
            CE_Vendedores vendedor = new CE_Vendedores();
            vendedor.Usuario = Form1.VendedorGlobal.vendedor1;
            LblNombreUsuario.Text = oCN_Vendedores.TraerNombreUsuario(vendedor);
        }
    }
}
