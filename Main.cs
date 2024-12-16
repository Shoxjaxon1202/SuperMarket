using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MiniMarketSystem
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            SidePanel.Height = btnDashboard.Height;
            SidePanel.Top = btnDashboard.Top;
        }


        private void label3_Click(object sender, EventArgs e) { }
        private void panelCategories_Paint(object sender, PaintEventArgs e) { }

        private void panelCategories_EnabledChanged(object sender, EventArgs e)
        {
        
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.instagram.com/shoxjaxon1202/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/shoxjaxon1202/");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            var forms = Application.OpenForms.Cast<Form>().ToList();

            foreach (var form in forms)
            {
                form.Close();
            }

            Application.Exit();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnDashboard.Height;
            SidePanel.Top = btnDashboard.Top;
            dashboardControl2.BringToFront();
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCategories.Height;
            SidePanel.Top = btnCategories.Top;
            categoriesControl1.BringToFront();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnProducts.Height;
            SidePanel.Top = btnProducts.Top;
            productsControl1.BringToFront();
        }
    }
}
