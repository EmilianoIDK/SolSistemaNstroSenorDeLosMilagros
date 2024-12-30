﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion UnicaInstancia = new Conexion();

        public static Conexion Instancia
        {
            get
            {
                return Conexion.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=DESKTOP-ER1TIJ4\\SQLEXPRESS; Initial Catalog=DBNstroSenorDeLosMilagros; Integrated Security=True";

            return cn;
        }
        #endregion metodos
    }
}
