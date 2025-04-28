using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VirtualCommerce.Enumeraciones;

namespace CPresentacion
{
    public partial class CU_020___Producto___Armado_interfaz : Form
    {
        private int _indexRowGrid;
        private EnumAccionUsuario _accionUsuario;
        public CU_020___Producto___Armado_interfaz()
        {
            InitializeComponent();
            BTN_Agregar.Enabled = false;
            BTN_Modificar.Enabled = false;
            BTN_Eliminar.Enabled = false;
            button1_Buscar_Cliente.Enabled = false;
            textBox1_Busqueda_Cliente.Enabled = false;

            _indexRowGrid = -1;
            //_accionUsuario = EnumAccionUsuario.Nada;
            ObtieneDatosDesdeRepositorio();
        }

        private void BTN_Agregar_Click(object sender, EventArgs e)
        {
            CU_020__Producto__Alta_producto interfazAltaProducto = new CU_020__Producto__Alta_producto();
            interfazAltaProducto.ShowDialog();
        }

        private void BTN_Modificar_Click(object sender, EventArgs e)
        {
            CU_020___Producto___Modificar_producto interfazModificarProducto = new CU_020___Producto___Modificar_producto();
            interfazModificarProducto.ShowDialog();
        }
        

        private void ObtieneDatosDesdeRepositorio()
        {
            Task.Run(() =>
            {
                try
                {
                    // Realizo la Api Call para obtener todos los Productos
                    var lista = Negocio.CasoDeUso.Productos.ObtenerTodo().GetAwaiter().GetResult();

                    // BeginInvoke me permite actualizar la UI desde otro Hilo de Ejecución que no sea el principal
                    dataGridView_InterfazProductos.BeginInvoke(
                        new Action(() =>
                        {
                            dataGridView_InterfazProductos.DataSource = null;
                            dataGridView_InterfazProductos.Rows.Clear();

                            dataGridView_InterfazProductos.DataSource = lista;

                            if (lista != null)
                            {
                                dataGridView_InterfazProductos.Columns[0].DisplayIndex = 1; // Intercambio las columnas para que quede Id y luego Nombre
                                dataGridView_InterfazProductos.Columns[1].DisplayIndex = 0; // probar comentar estas dos líneas para ver como se comporta
                            }

                            dataGridView_InterfazProductos.Tag = lista;

                            dataGridView_InterfazProductos.Enabled = true;
                        })
                    );
                    if (lista.Count > 0)
                    {
                        BTN_Agregar.BeginInvoke(
                            new Action(() =>
                            {
                                BTN_Agregar.Enabled = true;
                            })
                        );
                        BTN_Modificar.BeginInvoke(
                            new Action(() =>
                            {
                                BTN_Modificar.Enabled = true;
                            })
                        );
                        BTN_Eliminar.BeginInvoke(
                            new Action(() =>
                            {
                                BTN_Eliminar.Enabled = true;
                            })
                        );
                        button1_Buscar_Cliente.BeginInvoke(
                            new Action(() =>
                            {
                                button1_Buscar_Cliente.Enabled = true;
                            })
                        );
                        textBox1_Busqueda_Cliente.BeginInvoke(
                            new Action(() =>
                            {
                                textBox1_Busqueda_Cliente.Enabled = true;
                            })
                        );
                    }
                    else
                    {
                        BTN_Agregar.BeginInvoke(
                            new Action(() =>
                            {
                                BTN_Agregar.Enabled = false;
                            })
                        );
                        BTN_Modificar.BeginInvoke(
                            new Action(() =>
                            {
                                BTN_Modificar.Enabled = true;
                            })
                        );
                        BTN_Eliminar.BeginInvoke(
                            new Action(() =>
                            {
                                BTN_Eliminar.Enabled = false;
                            })
                        );
                        button1_Buscar_Cliente.BeginInvoke(
                            new Action(() =>
                            {
                                button1_Buscar_Cliente.Enabled = false;
                            })
                        );
                        textBox1_Busqueda_Cliente.BeginInvoke(
                            new Action(() =>
                            {
                                textBox1_Busqueda_Cliente.Enabled = false;
                            })
                        );
                    }
                }
                catch
                {
                    MessageBox.Show(
                        "Se presentó un problema al recuperar la información",
                        "Recuperación de Datos...",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            });
        }
    }
}
