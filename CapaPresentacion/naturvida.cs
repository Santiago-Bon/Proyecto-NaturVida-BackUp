using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class naturvida : Form
    {
        CN_Conexion conexion = new CN_Conexion();


        public naturvida()
        {
            InitializeComponent();
        }


        private void Abrir(Form hijo) //Craga los formularios en el panel
        {
            this.panel1.Controls.Clear(); //limpia el panel
            //Form2 hijo = new Form2(); //Instancia
            hijo.TopLevel = false; //Para que no sea mas grande que el panel
            hijo.Dock = DockStyle.Fill; //Da formato completo
            this.panel1.Controls.Add(hijo); //Agrega el formulario que está en hijo
            hijo.Show(); //Abre el formulario en el panel
        }


        //Inicio Naturvida al cargar


        private void naturvida_Load(object sender, EventArgs e)
        {
            Form presentacion = new Presentacion();
            Abrir(presentacion);
        }


        //Productos


        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Gestion_productos = new Gestion_productos();
            Abrir(Gestion_productos);
        }


        //Clientes


        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form clientes = new Clientes();
            Abrir(clientes);
        }


        //Inventario


        private void consultarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form inventario = new Inventario();
            Abrir(inventario);
        }


        //Facturación


        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form factura = new Factura();
            Abrir(factura);
        }


        //Vendedores


        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form vendedores = new Vendedores();
            Abrir(vendedores);
        }


        //Inicio de Sesión


        private void inicioSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form inicio_sesion = new Form1();
            inicio_sesion.Show();
            Hide();
        }


        //Inicio Naturvida


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form presentacion = new Presentacion();
            Abrir(presentacion);
        }


        //Salir


        private void salirToolStripMenuItem_Click(object sender, EventArgs e) //Sale de la aplicación
        {
            Application.Exit();
        }


        //Generar BackUp


        private void generarBakUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string comando_consulta;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo txt (*.bak)|*.bak";
            sfd.Title = "Guardar";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                comando_consulta = "BACKUP DATABASE [" + conexion.ConexionAbrir().Database + "] TO  DISK = N'" + sfd.FileName + "'";
                try
                {
                    conexion.ConexionAbrir();
                    SqlCommand cmd = new SqlCommand(comando_consulta, conexion.ConexionAbrir());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("La copia se ha creado satisfactoriamente");
                    conexion.ConexionCerrar();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            sfd.Dispose();
        }


        //Restaurar Base de Datos


        private void restaurarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Restaurar";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string database = conexion.ConexionAbrir().Database.ToString();
                conexion.ConexionAbrir();
                try
                {
                    string stri = "ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE"; //alterar la base de datos [" + base de datos + "] establecer usuario único con reversión inmediata
                    SqlCommand comando = new SqlCommand(stri, conexion.ConexionAbrir());
                    comando.ExecuteNonQuery();

                    string stri2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK ='" + dlg.FileName + "' WITH REPLACE;"; //use la base de datos de restauración maestra [" + base de datos + "] desde el disco = '" + txt_restaura.Text + "' con reemplazar
                    SqlCommand comando2 = new SqlCommand(stri2, conexion.ConexionAbrir());
                    comando2.ExecuteNonQuery();

                    string stri3 = "ALTER DATABASE [" + database + "] SET MULTI_USER"; //modificar base de datos[" + base de datos + "] establecer multiusuario
                    SqlCommand comando3 = new SqlCommand(stri3, conexion.ConexionAbrir());
                    comando3.ExecuteNonQuery();

                    MessageBox.Show("Restauracion Completa");
                    conexion.ConexionCerrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
