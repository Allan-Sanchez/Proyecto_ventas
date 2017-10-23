using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NCategoria
    {

        //metodo insertar que llama al metodo insertar de la clase Dcategoria
        //de la capaDatos

        public static string Insertar(string nombre, string descripcion)
        {

            DCategoria Obj = new DCategoria();

            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        //metodo editar que llama al metodo editar de la clase Dcategoria
        //de la capaDatos

        public static string Editar(int idcategoria, string nombre, string descripcion)
        {

            DCategoria Obj = new DCategoria();

            Obj.Idcategoria = idcategoria;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }
        //Metodo eliminar que llama al metodo eliminar de la clases Dcategoria
        //de la capaDatos

        public static string Eliminar(int idcategoria)
        {

            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategoria;
            return Obj.Eliminar(Obj);
        }
        //metodo mostrar que llama al metodo mostrar de la clase Dcategoria
        //de la CapaDatos

        public static DataTable Mostrar()
        {
            //hago una instancia directa al clase Dcategoria en su metodo mostrar
            return new DCategoria().Mostrar(); 
        }
        
        //metodo buscarNombre que llama al metodo buscarNombre de la clase Dcategoria
        //de la capadatos

        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarNombre(Obj);
        
        }




    }
}
