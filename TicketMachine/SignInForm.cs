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

namespace TicketMachine
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSignin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            int priority = 0;
            if (btnPriority.Checked == true)
                priority = 1;
            String sql = "insert into Users VALUES('" + txtUserName.Text + "','" + txtPwd.Text + "',N'" + txtName.Text + "','" +
                txtDate.Text + "','" + txtPhone.Text + "', N'" + txtAddress.Text + "'," + priority +")";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int row = cmd.ExecuteNonQuery();
            if (row == 1)
            {
                MessageBox.Show("Sign in Successfully!");
                this.Close();
            }
            conn.Close();
        }
    }
}
