using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class Conexion
    {
        public static string Cn = Properties.Settings.Default.cn;
       // SqlConnection Conexion = new SqlConnection("server= DESKTOP-02FCSK2\BASE_DATOS; database=dbVentas: Integrated security = true");
    }
}
