using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class CN_Conexion
    {
        CD_Conexion conexion = new CD_Conexion();


        public SqlConnection ConexionAbrir()
        {
            SqlConnection conexionabrir = conexion.AbrirConexion();

            return conexionabrir;
        }


        public SqlConnection ConexionCerrar()
        {

            SqlConnection conexioncerrar = conexion.CerrarConexion();

            return conexioncerrar;
        }
    }
}
