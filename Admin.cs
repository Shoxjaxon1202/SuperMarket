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
using System.Xml.Linq;

namespace MiniMarketSystem
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=SHOXJAXON\SQLEXPRESS;Initial Catalog=MiniMarketDB;Integrated Security=True");
            con.Open();

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            SqlCommand cnn = new SqlCommand("select Username, Password from admintab where Username='" + username + "'and Password='" + password + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Dashboard mn = new Dashboard();
                mn.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            con.Close();
            username = "";
            password = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form1 user = new Form1();
            user.Show();
            this.Hide();
        }
    }
}
