﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Conexion
    {
        private SqlConnection conexion = new SqlConnection("Server=LAPTOP-7CT9LAKR\\SQLEXPRESS;Database=NaturVida;Integrated Security=True");
        //private SqlConnection conexion = new SqlConnection("Data Source=SQL5110.site4now.net;Initial Catalog=db_a9823f_naturvida;User Id=db_a9823f_naturvida_admin;Password=NaturVida123");


        public SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }


        public SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
