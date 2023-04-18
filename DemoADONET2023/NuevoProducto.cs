using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace DemoADONET2023
{
    public partial class NuevoProducto : Form
    {
        public NuevoProducto()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                BProducto negocio = new BProducto();
                negocio.Insertar(new Entidad.Producto
                {
                    Nombre = txtNombre.Text,
                    Precio = double.Parse(txtPrecio.Text)

                });
                MessageBox.Show("Registro exitoso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex);

            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            BProducto negocio = new BProducto();
            dgvProducto.DataSource = negocio.Listar(txtNombre.Text);

        }
    }
}
