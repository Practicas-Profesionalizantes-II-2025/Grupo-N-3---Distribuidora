using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPresentacion
{
    public partial class CU_008___Empleado___Armado_interfaz : Form
    {
        private int _indexRowGrid;
        public CU_008___Empleado___Armado_interfaz()
        {
            _indexRowGrid = -1;
            InitializeComponent();
            ObtieneDatosDesdeRepositorio();
        }

        private void listView1_Resultado_Busqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CU_008___Empleado___Armado_interfaz_Load(object sender, EventArgs e)
        {

        }

        private void BTN_Agregar_Click(object sender, EventArgs e)
        {
            CU___015___Empleado___Alta_empleado interfazEmpleadosAgregar = new CU___015___Empleado___Alta_empleado();
            interfazEmpleadosAgregar.ShowDialog();
        }

        private void BTN_Modificar_Click(object sender, EventArgs e)
        {
            CU_015___Empleado___Modificar_empleado interfazEmpleadosAgregar = new CU_015___Empleado___Modificar_empleado();
            interfazEmpleadosAgregar.ShowDialog();

        }

        private void ObtieneDatosDesdeRepositorio()
        {
            Task.Run(() =>
            {
                try
                {
                    bool datosCargados = false;
                    // Realizo la Api Call para obtener todos los Empleados
                    var listaEmpleadados = Negocio.CasoDeUso.Empleados.ObtenerTodo().GetAwaiter().GetResult();
                    // Para cada uno saco todos sus subatributos
                    List<object> listaEmpleadosConSubAtributos = new List<object>();

                    foreach (var empleado in listaEmpleadados)
                    {
                            listaEmpleadosConSubAtributos.Add(new
                            {
                                empleado.Persona.Nombre,
                                empleado.Persona.Apellido,
                                empleado.Persona.Tipo_Doc.NombreTipoDocumento,
                                empleado.Persona.Nro_Doc,
                                empleado.EstadoEmpleado.Descripcion
                            });
                    }
                    datosCargados = true;

                    // BeginInvoke me permite actualizar la UI desde otro Hilo de Ejecución que no sea el principal
                    dataGridView_Empleados.BeginInvoke(
                        new Action(() =>
                        {
                            dataGridView_Empleados.DataSource = null;
                            dataGridView_Empleados.Rows.Clear();

                            dataGridView_Empleados.DataSource = listaEmpleadosConSubAtributos;

                            //if (listaEmpleadosConSubAtributos != null)
                            //{
                            //    dataGridView_Empleados.Columns[0].DisplayIndex = 1; // Intercambio las columnas para que quede Id y luego Nombre
                            //    dataGridView_Empleados.Columns[1].DisplayIndex = 0; // probar comentar estas dos líneas para ver como se comporta
                            //}

                            dataGridView_Empleados.Tag = listaEmpleadosConSubAtributos;

                            dataGridView_Empleados.Enabled = true;
                        })
                    );
                    if(datosCargados)
                    {
                        btn_Agregar.BeginInvoke(
                            new Action(() =>
                            {
                                btn_Agregar.Enabled = true;
                            })
                        );
                    }
                    if (listaEmpleadosConSubAtributos.Count > 0 && datosCargados)
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
                        
                        dataGridView_Empleados.BeginInvoke(
                            new Action(() =>
                            {
                                dataGridView_Empleados.Enabled = true;
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
                        
                        dataGridView_Empleados.BeginInvoke(
                            new Action(() =>
                            {
                                dataGridView_Empleados.Enabled = false;
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

        private void dataGridView_Empleados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null && dataGridView_Empleados.Rows.Count > 0)
            {
                _indexRowGrid = e.RowIndex;

                label_CodigoEmpleado.Text = dataGridView_Empleados[1, e.RowIndex].Value.ToString();
                label_CodigoEmpleado.Text =
                    (dataGridView_Empleados[0, e.RowIndex].Value != null)
                        ? dataGridView_Empleados[0, e.RowIndex].Value.ToString()
                        : "";

            }
            else
            {
                label_CodigoEmpleado.Text = "0";
                _indexRowGrid = -1;

            }
        }

        private void button1_Buscar_Cliente_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_Empleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
