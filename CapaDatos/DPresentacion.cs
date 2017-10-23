using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPresentacion
    {
        private int _Idpresentacion;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;

        public int Idpresentacion
        {
            get { return _Idpresentacion; }
            set { _Idpresentacion = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }

        public DPresentacion()
        {

        }

        public DPresentacion(int idpresentacion, string nombre, string descripcion, string textoBuscar)
        {
            this.Idpresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar= textoBuscar;
        }

        //metodo insertar

        //insertar

        public string Insertar(DPresentacion Presentacion)
        {
            //rpta = respuesta
            string rpta = "";
            SqlConnection slqCon = new SqlConnection();

            try
            {
                //establecemos conexion con dbventas

                slqCon.ConnectionString = Conexion.Cn;
                slqCon.Open();
                //establecer el comando

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = slqCon;
                SqlCmd.CommandText = "spinsertar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //codigo para hacer posible el ingreso del parametro idcategoria
                SqlParameter ParIdpresentacion = new SqlParameter();

                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(ParIdpresentacion);
                //codigo para el ingreso del segundo parametro nombre

                SqlParameter Parnombre = new SqlParameter();

                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(Parnombre);
                //codigo para el ingreso de una descripcion

                SqlParameter Pardescripcion = new SqlParameter();

                Pardescripcion.ParameterName = "@descripcion";
                Pardescripcion.SqlDbType = SqlDbType.VarChar;
                Pardescripcion.Size = 200;
                Pardescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(Pardescripcion);

                //ejecutamos nuestros comandos

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro ";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }

            finally
            {
                if (slqCon.State == ConnectionState.Open) slqCon.Close();

            }

            return rpta;


        }
        //metodo editar
        public string Editar(DPresentacion Presentacion)
        {
            //rpta = respuesta
            string rpta = "";
            SqlConnection slqCon = new SqlConnection();

            try
            {
                //establecemos conexion con dbventas

                slqCon.ConnectionString = Conexion.Cn;
                slqCon.Open();
                //establecer el comando

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = slqCon;
                SqlCmd.CommandText = "speditar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //codigo para hacer posible el ingreso del parametro idcategoria
                SqlParameter ParIdpresentacion = new SqlParameter();

                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Presentacion.Idpresentacion;

                SqlCmd.Parameters.Add(ParIdpresentacion);
                //codigo para el ingreso del segundo parametro nombre

                SqlParameter Parnombre = new SqlParameter();

                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(Parnombre);
                //codigo para el ingreso de una descripcion

                SqlParameter Pardescripcion = new SqlParameter();

                Pardescripcion.ParameterName = "@descripcion";
                Pardescripcion.SqlDbType = SqlDbType.VarChar;
                Pardescripcion.Size = 200;
                Pardescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(Pardescripcion);

                //ejecutamos nuestros comandos

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualiso el registro: ";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }

            finally
            {
                if (slqCon.State == ConnectionState.Open) slqCon.Close();

            }

            return rpta;

        }

        //metodo eliminar
        public string Eliminar(DPresentacion Presentacion)
        {
            //rpta = respuesta
            string rpta = "";
            SqlConnection slqCon = new SqlConnection();

            try
            {
                //establecemos conexion con dbventas

                slqCon.ConnectionString = Conexion.Cn;
                slqCon.Open();
                //establecer el comando

                SqlCommand SqlCmd = new SqlCommand();

                SqlCmd.Connection = slqCon;
                SqlCmd.CommandText = "speliminar_presentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //codigo para hacer posible el ingreso del parametro idcategoria
                SqlParameter ParIdpresentacion = new SqlParameter();

                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Presentacion.Idpresentacion;

                SqlCmd.Parameters.Add(ParIdpresentacion);



                //ejecutamos nuestros comandos

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro: ";

            }
            catch (Exception ex)
            {

                rpta = ex.Message;
            }

            finally
            {
                if (slqCon.State == ConnectionState.Open) slqCon.Close();

            }

            return rpta;
        }

        //metodo mostrar

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();

                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "sp_mostrar_presentacion";
                Sqlcmd.CommandType = CommandType.StoredProcedure;//procedimiento almacenado


                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {

                DtResultado = null;
            }

            return DtResultado;

        }

        //metodo BuscarNombre

        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();

                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscar_presentacion_nombre";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Partextobuscar = new SqlParameter();

                Partextobuscar.ParameterName = "@textobuscar";
                Partextobuscar.SqlDbType = SqlDbType.VarChar;
                Partextobuscar.Size = 50;
                Partextobuscar.Value = Presentacion.TextoBuscar;
                Sqlcmd.Parameters.Add(Partextobuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {

                DtResultado = null;
            }

            return DtResultado;

        }




    }
}
