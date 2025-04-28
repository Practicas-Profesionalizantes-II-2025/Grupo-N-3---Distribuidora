namespace CPresentacion
{
    public partial class CU_003____Cliente____Armado_interfaz_principal__Encargado : Form
    {
        public CU_003____Cliente____Armado_interfaz_principal__Encargado()
        {
            InitializeComponent();
        }

        private void CU_003____Cliente____Armado_interfaz_principal__Encargado_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void BTN_COMPRAS_Click(object sender, EventArgs e)
        {

        }


        private void BTN_PRODUCTOS_Click(object sender, EventArgs e)
        {
            CU_020___Producto___Armado_interfaz interfazProducto = new CU_020___Producto___Armado_interfaz();
            interfazProducto.ShowDialog();
        }

        private void BTN_EMPLEADOS_Click(object sender, EventArgs e)
        {
            CU_008___Empleado___Armado_interfaz interfazEmpleados = new CU_008___Empleado___Armado_interfaz();
            interfazEmpleados.ShowDialog();
        }

        private void BTN_CLIENTES_Click(object sender, EventArgs e)
        {
            CU_003____cliente____Armado_interfaz__Cliente interfazClientes = new CU_003____cliente____Armado_interfaz__Cliente();
            interfazClientes.ShowDialog();
        }
    }
}
