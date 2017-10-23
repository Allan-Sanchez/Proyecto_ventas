using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;
namespace CapaNegocio
{
   public class NPresentacion
    {

        //metodo insertar que llama al metodo insertar de la clase DPresentacion
        //de la capaDatos

        public static string Insertar(string nombre, string descripcion)
        {

            DPresentacion Obj = new DPresentacion();

            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        //metodo editar que llama al metodo editar de la clase DPresentacion
        //de la capaDatos

        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {

            DPresentacion Obj = new DPresentacion();
        
            Obj.Idpresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }
        //Metodo eliminar que llama al metodo eliminar de la clases DPresentacion
        //de la capaDatos

        public static string Eliminar(int idpresentacion)
        {

            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            return Obj.Eliminar(Obj);
        }
        //metodo mostrar que llama al metodo mostrar de la clase DPresentacion
        //de la CapaDatos

        public static DataTable Mostrar()
        {
            //hago una instancia directa al clase Dcategoria en su metodo mostrar
            return new DPresentacion().Mostrar();
        }

        //metodo buscarNombre que llama al metodo buscarNombre de la clase DPresentacion
        //de la capadatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarNombre(Obj);

        }




    }
}
