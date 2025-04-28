using Microsoft.IdentityModel.Tokens;
using Shared.Entities;
using System.Windows.Forms;
using VirtualCommerce.Enumeraciones;

namespace CPresentacion
{
    public partial class CU_020__Producto__Alta_producto : Form
    {
        private int _indexRowGrid;
        // private EnumAccionUsuario _accionUsuario; // Ver de borrar
        public CU_020__Producto__Alta_producto()
        {
            InitializeComponent();
            textBox_NombreProducto.MaxLength = Shared.Entities.Productos.LengthNombre;
        }

        private void label4_Email_Click(object sender, EventArgs e)
        {

        }

        private void textBox_NombreProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private async void BTN_Conf_Alta_Prod_Click(object sender, EventArgs e)
        {
            int precioUnitario;
            bool valorIvalido = int.TryParse(textBox4_PrecioUnitario.Text, out precioUnitario);
            List<string> listaDeErrores = new List<string>();
            if (string.IsNullOrEmpty(textBox_NombreProducto.Text))
            {
                //MessageBox.Show(
                //    "Debe indicar el nombre del Producto",
                //    "Ingreso de Datos...",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error
                //);
                //textBox_NombreProducto.Focus();
                listaDeErrores.Add("Nombre");
            }
            else if (string.IsNullOrEmpty(cb_Proveedor.Text))
            {
                listaDeErrores.Add("Proveedor");
            }
            else if (string.IsNullOrEmpty(cb_Categoria.Text))
            {
                listaDeErrores.Add("Categoria");
            }
            else if (string.IsNullOrEmpty(tb_Foto.Text))
            {
                listaDeErrores.Add("Foto del producto");
            }
            else if (string.IsNullOrEmpty(textBox4_PrecioUnitario.Text) || precioUnitario < 0 || valorIvalido)
            {
                listaDeErrores.Add("Precio Unitario");
            }
            else if (listaDeErrores.Count > 0)
            {
                MessageBox.Show(
                    "Hay errores en las siguientes entradas" + String.Join(", ", listaDeErrores),
                    "Ingreso de Datos...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

            }
            else
            {
                try
                {
                    await Negocio.CasoDeUso.Productos.Crear(
                        new Shared.Dtos.Productos.CrearDTOProductos
                        {
                            IdProveedor = Negocio.CasoDeUso.Proveedores.obtenerPorNombre(cb_Proveedor.Text).Id,
                            Nombre = cb_Proveedor.Text.Trim(),
                            IdCategoria = Negocio.CasoDeUso.Categorias.obtenerPorNombre(cb_Categoria.Text).Id,
                            PrecioProducto = precioUnitario
                            // Agregar lo de la foto
                        }
                    );
                }
                catch
                {
                    MessageBox.Show(
                        "Se presentó un problema al persistir la información",
                        "Persistencia de Datos...",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        private void button1_Canc_Alta_Prod_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}