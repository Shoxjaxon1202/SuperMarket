using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMarketSystem
{
    public partial class CategoriesControl : UserControl
    {
        public CategoriesControl()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=SHOXJAXON\SQLEXPRESS;Initial Catalog=MiniMarketDB;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("insert into catab values(@CategoriesId, @CategoriesName)", con);
                cnn.Parameters.AddWithValue("@CategoriesId", int.Parse(txtId.Text));
                cnn.Parameters.AddWithValue("@CategoriesName", txtName.Text);

                cnn.ExecuteNonQuery();
                MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlDataAdapter da = new SqlDataAdapter("select * from catab", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;

                txtId.Text = "";
                txtName.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=SHOXJAXON\SQLEXPRESS;Initial Catalog=MiniMarketDB;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("UPDATE catab SET categoriesname = @CategoriesName WHERE categoriesid = @CategoriesId", con);
                cnn.Parameters.AddWithValue("@CategoriesId", int.Parse(txtId.Text));
                cnn.Parameters.AddWithValue("@CategoriesName", txtName.Text);

                cnn.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Jadvalni yangilash
                SqlDataAdapter da = new SqlDataAdapter("select * from catab", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;

                txtId.Text = "";
                txtName.Text = "";
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=SHOXJAXON\SQLEXPRESS;Initial Catalog=MiniMarketDB;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("DELETE FROM catab WHERE categoriesid = @CategoriesId", con);
                cnn.Parameters.AddWithValue("@CategoriesId", int.Parse(txtId.Text));

                cnn.ExecuteNonQuery();
                MessageBox.Show("Record Deleted Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlDataAdapter da = new SqlDataAdapter("select * from catab", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;

                txtId.Text = "";
                txtName.Text = "";
            }
        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=SHOXJAXON\SQLEXPRESS;Initial Catalog=MiniMarketDB;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cnn = new SqlCommand("select * from catab", con);
                SqlDataAdapter da = new SqlDataAdapter(cnn);
                DataTable table = new DataTable();
                da.Fill(table);
                dataGridView1.DataSource = table;
            }
        }
    }
}
