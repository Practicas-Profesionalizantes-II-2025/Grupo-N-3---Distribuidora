using CPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualCommerce.TipoDoc
{
    public partial class CU_002___TipoDoc___Armado_Interfaz : Form
    {
        private int _indexRowGrid;
        public CU_002___TipoDoc___Armado_Interfaz()
        {
            InitializeComponent();

            //Desactivar los botones si no se establece conexion
            btn_buscar.Enabled = false;
            btn_eliminar.Enabled = false;
            btn_modificar.Enabled = false;
            btn_Agregar.Enabled = false;
            dataGridView_TipoDocumento.Enabled = false;

            ObtieneDatosDesdeRepositorio();
        }

        private void BTN_Agregar_Click(object sender, EventArgs e)
        {
            CU_002___TipoDoc___Alta_Doc interfazAltaTipoDocumento = new CU_002___TipoDoc___Alta_Doc();
            interfazAltaTipoDocumento.ShowDialog();
        }

        private void BTN_Modificar_Click(object sender, EventArgs e)
        {
            CU002___TipoDoc___Modificar_TipoDoc interfazAltaProducto = new CU002___TipoDoc___Modificar_TipoDoc();
            interfazAltaProducto.ShowDialog();
        }

        //Ver si esto su puede usar para el label del codigo de tipo documento y el nombre
        private void dataGridView_TipoDocumento_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null && dataGridView_TipoDocumento.Rows.Count > 0)
            {
                _indexRowGrid = e.RowIndex;

                // Asigna el ID (que es la primera columna: C1) al label de código
                label_codigoDocumento.Text = dataGridView_TipoDocumento[0, e.RowIndex].Value.ToString();

                // Asigna el nombre del documento (que es la segunda columna: C2) al label del tipo de documento
                label_TipoDocumento.Text = dataGridView_TipoDocumento[1, e.RowIndex].Value != null
                    ? dataGridView_TipoDocumento[1, e.RowIndex].Value.ToString()
                    : "";
            }
            else
            {
                label_codigoDocumento.Text = "0";
                label_TipoDocumento.Text = "";

                _indexRowGrid = -1;
            }
        }

        private void ObtieneDatosDesdeRepositorio()
        {
            Task.Run(() =>
            {
                try
                {
                    // Realizo la Api Call para obtener todos los TipoDocumento
                    var lista = Negocio.CasoDeUso.TipoDocumento.ObtenerTodo().GetAwaiter().GetResult();

                    // BeginInvoke me permite actualizar la UI desde otro Hilo de Ejecución que no sea el principal
                    dataGridView_TipoDocumento.BeginInvoke(
                        new Action(() =>
                        {
                            dataGridView_TipoDocumento.DataSource = null;
                            dataGridView_TipoDocumento.Rows.Clear();

                            dataGridView_TipoDocumento.DataSource = lista;

                            if (lista != null)
                            {
                                dataGridView_TipoDocumento.Columns[0].DisplayIndex = 1; // Intercambio las columnas para que quede Id y luego Nombre
                                dataGridView_TipoDocumento.Columns[1].DisplayIndex = 0; // probar comentar estas dos líneas para ver como se comporta
                            }

                            dataGridView_TipoDocumento.Tag = lista;

                            dataGridView_TipoDocumento.Enabled = true;
                        })
                    );
                    if (lista.Count > 0)
                    {
                        btn_buscar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_buscar.Enabled = true;
                            })
                        );
                        btn_eliminar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_eliminar.Enabled = true;
                            })
                        );
                        btn_modificar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_modificar.Enabled = true;
                            })
                        );
                        btn_Agregar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_Agregar.Enabled = true;
                            })
                        );
                        dataGridView_TipoDocumento.BeginInvoke(
                            new Action(() =>
                            {
                                dataGridView_TipoDocumento.Enabled = true;
                            })
                        );
                    }
                    else
                    {
                        btn_buscar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_buscar.Enabled = false;
                            })
                        );
                        btn_eliminar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_eliminar.Enabled = false;
                            })
                        );
                        btn_modificar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_modificar.Enabled = false;
                            })
                        );
                        btn_Agregar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_Agregar.Enabled = false;
                            })
                        );
                        dataGridView_TipoDocumento.BeginInvoke(
                            new Action(() =>
                            {
                                dataGridView_TipoDocumento.Enabled = false;
                            })
                        );
                    }
                }
                catch (Exception ex)
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

        private void dataGridView_TipoDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
