using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InicioCrud
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        string sql;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Server=DESKTOP-13CB4OC\SQLEXPRESS;Database=Cliente;Trusted_Connection=True");
                sql = "INSERT INTO CADCLIENTE (NOME, NUMERO) VALUES (@NOME, @NUMERO)";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@NOME", txtNome.Text);
                command.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ez)
            {

                MessageBox.Show(ez.Message);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
            }
          
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Server=DESKTOP-13CB4OC\SQLEXPRESS;Database=Cliente;Trusted_Connection=True");
                sql = "SELECT * FROM CADCLIENTE";

                DataSet ds = new DataSet();
                adapter = new SqlDataAdapter(sql,connection);

                connection.Open();
               
                connection.Close();

                adapter.Fill(ds);
                
                dgwResultados.DataSource = ds.Tables[0];

            }
            catch (Exception ez)
            {

                MessageBox.Show(ez.Message);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
            }
        }

        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(@"Server=DESKTOP-13CB4OC\SQLEXPRESS;Database=Cliente;Trusted_Connection=True");
                sql = "SELECT * FROM CADCLIENTE WHERE ID = @ID";
                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@ID", txtId.Text);
               

                connection.Open();
                reader = command.ExecuteReader();

               

            }
            catch (Exception ez)
            {

                MessageBox.Show(ez.Message);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
            }
        }
    }
}
