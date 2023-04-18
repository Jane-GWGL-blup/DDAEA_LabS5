using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DProducto { 
    private string connectionString = "Data Source=LAB707-04\\SQLEXPRESS01;Initial Catalog=BDLab05;Integrated Security=True;";


    public List<Producto> Listar()
    {

        //Obtengo la conexión
        SqlConnection connection = null;
        SqlParameter param = null;
        SqlCommand command = null;
        List<Producto> productos = null;
        try
        {
            connection = new SqlConnection(connectionString);

            connection.Open();

            //Hago mi consulta
            command = new SqlCommand("USP_GetProducto", connection);
            command.CommandType = CommandType.StoredProcedure;

            //param = new SqlParameter();
            //param.ParameterName = "@Description";
            //param.SqlDbType = SqlDbType.VarChar;
            //param.Value = description;

            //command.Parameters.Add(param);

            SqlDataReader reader = command.ExecuteReader();
            productos = new List<Producto>();


            while (reader.Read())
            {

                Producto producto = new Producto();
                producto.IdProducto= (int)reader["Id"];
                producto.Nombre = reader["Nombre"].ToString();
                producto.Precio = Convert.ToDouble( reader["Precio"]);
                producto.FechaCreacion =Convert.ToDateTime( reader["FechaCreacion"]);

                productos.Add(producto);

            }

            connection.Close();

            //Muestro la información
            return productos;


        }
        catch (Exception)
        {
            connection.Close();
            throw;
        }
        finally
        {
            connection = null;
            command = null;
            param = null;
            productos = null;

        }


    }

    public void Insertar(Producto producto)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("USP_InsProducto", connection); // Nombre del procedimiento almacenado
                command.CommandType = CommandType.StoredProcedure;

                // Parámetros del procedimiento almacenado                
                command.Parameters.AddWithValue("@Id", producto.IdProducto);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                //command.Parameters.AddWithValue("@FechaCreacion", producto.FechaCreacion);

                    command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

}
}
