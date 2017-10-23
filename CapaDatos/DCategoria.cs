using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
   public  class DCategoria
    {
        private int _Idcategoria;
        private string _Nombre;
        private string _Descripcion;
        private string _TextoBuscar;


        public int Idcategoria
        {
            get { return _Idcategoria; }
            set { _Idcategoria = value; }
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


        //contructor vacio

        public DCategoria()
        {

        }

        public DCategoria(int idcategoria, string nombre, string descripcion, string textobuscar)
        {
            this.Idcategoria = idcategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;

        }

        //metodos

        //insertar

        public string Insertar(DCategoria categoria)
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
                SqlCmd.CommandText = "spinsertar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                

                //codigo para hacer posible el ingreso del parametro idcategoria
                SqlParameter ParIdcategoria = new SqlParameter();

                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Direction = ParameterDirection.Output;

                SqlCmd.Parameters.Add(ParIdcategoria);
                //codigo para el ingreso del segundo parametro nombre

                SqlParameter Parnombre = new SqlParameter();

                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = categoria.Nombre;
                SqlCmd.Parameters.Add(Parnombre);
                //codigo para el ingreso de una descripcion

                SqlParameter Pardescripcion = new SqlParameter();

                Pardescripcion.ParameterName = "@descripcion";
                Pardescripcion.SqlDbType = SqlDbType.VarChar;
                Pardescripcion.Size = 50;
                Pardescripcion.Value = categoria.Descripcion;
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
        public string Editar(DCategoria categoria)
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
                SqlCmd.CommandText = "speditar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //codigo para hacer posible el ingreso del parametro idcategoria
                SqlParameter ParIdcategoria = new SqlParameter();

                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = categoria.Idcategoria;

                SqlCmd.Parameters.Add(ParIdcategoria);
                //codigo para el ingreso del segundo parametro nombre

                SqlParameter Parnombre = new SqlParameter();

                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = categoria.Nombre;
                SqlCmd.Parameters.Add(Parnombre);
                //codigo para el ingreso de una descripcion

                SqlParameter Pardescripcion = new SqlParameter();

                Pardescripcion.ParameterName = "@descripcion";
                Pardescripcion.SqlDbType = SqlDbType.VarChar;
                Pardescripcion.Size = 50;
                Pardescripcion.Value = categoria.Descripcion;
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
        public string Eliminar(DCategoria categoria)
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
                SqlCmd.CommandText = "speliminar_categoria";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //codigo para hacer posible el ingreso del parametro idcategoria
                SqlParameter ParIdcategoria = new SqlParameter();

                ParIdcategoria.ParameterName = "@idcategoria";
                ParIdcategoria.SqlDbType = SqlDbType.Int;
                ParIdcategoria.Value = categoria.Idcategoria;

                SqlCmd.Parameters.Add(ParIdcategoria);
          

              
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
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();

                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText="spmostrar_categoria";
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

        public DataTable BuscarNombre(DCategoria categoria)
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection Sqlcon = new SqlConnection();

            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();

                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscar_categoria";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Partextobuscar = new SqlParameter();

                Partextobuscar.ParameterName = "@textobuscar";
                Partextobuscar.SqlDbType = SqlDbType.VarChar;
                Partextobuscar.Size = 50;
                Partextobuscar.Value = categoria.TextoBuscar;
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

