using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmCategoria : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
      
        public FrmCategoria()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre de la categoria");
            
        }
        //Metodo de mensaje de confirmacion 

        private void Mensajeok(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        //mostrar mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        //metodo para limpiar todos los controles del formulario

        private void Limpiar()
        {
            //string.empty==vacio
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtidcategoria.Text = string.Empty;
        }
        //metodo para habilitar los controles de este formulario

        private void Habilitar(bool valor)
        {
            //solo lectura readonly
           
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtidcategoria.ReadOnly = !valor;

        }
        //metodo para habilitar los botones
        private void Botones()
        {
            
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;//enabled activado o desactivado 
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {

                this.Habilitar(false);
                this.btnNuevo.Enabled = true;//enabled activado o desactivado 
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;

            }


        }

        //Metodo para ocultar columnas

        private void OcultarColumnas()
        {
            //ocultamos las columnas del datagribview
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }
        //Metodo Mostrar los registros de categoria


        private void Mostar()
        {

            this.dataListado.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros:" + Convert.ToString(dataListado.Rows.Count);//datalistado.filas.contador
        }
        //Metodo buscar por nombre
        private void BuscarNombre()
        {

            this.dataListado.DataSource = NCategoria.BuscarNombre(txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = ("Total de Registor: "+ Convert.ToString(dataListado.Rows.Count));//datalistado.filas.contador
            
        }




        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostar();
            this.Habilitar(false);
            this.Botones();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                string rpta = "";
                if (txtNombre.Text == string.Empty) 
                {
                    MensajeError("Falta ingresar algunos datos,seran remarcados");
                    erroricono.SetError(txtNombre, "debes ingresar un nombre");
                }
                else
                {
                    if ( this.IsNuevo)
                    {
                        //metodo trim es para borrar los espacios
                        rpta=NCategoria.Insertar(this.txtNombre.Text.Trim().ToUpper(),this.txtDescripcion.Text.Trim());
                    }
                    else
                    {
                        //hacemos una conversion porque en nuestra base de datos el campo IDcategoria en un 'Int'
                        rpta = NCategoria.Editar(Convert.ToInt32(txtidcategoria.Text),this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim());
                    }
                    //equals espara comparar una cadena
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.Mensajeok("Se inserto un nuevo registro");
                        }
                        else
                        {
                            this.Mensajeok("Se modifico un registro exitosamente");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                        //respuesta nos de el resultado de la varibale rpta de la clase Ncategoria
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);//mostrar el posible error 
            }
        }

        private void dataListado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //.currentrow devuelve la fila que contiene la celda actual
            this.txtidcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtidcategoria.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                MensajeError("Debe Seleccionar primero el registro a eliminar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);


            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion;

                opcion = MessageBox.Show("Realmente desea elimnar los registros", "Sitemas de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion==DialogResult.OK)
                {
                    string Codigo;
                    string Rpta;

                    foreach (DataGridViewRow Row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(Row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(Row.Cells[1].Value);
                            Rpta=NCategoria.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.Mensajeok("Registro Eliminado");
                            }
                            else
                            {
                                MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+ex.StackTrace);
            }
        }
        
       
       

       








    }
}
