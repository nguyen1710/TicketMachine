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
    public partial class LoginForm : Form
    {
        public static string userName = "";
        public static DateTime dateOfBirth;
        public static string address = "";
        public static string sdt = "";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            String sSQL = "SELECT userName, userPwd FROM Users WHERE " +
            "userName='" + txtUsersName.Text + "' and userPwd='" +
            txtPwd.Text + "'";
            SqlCommand cmd = new SqlCommand(sSQL, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login Successful!");
                String queryName = "select hoten from Users WHERE userName = '" + txtUsersName.Text + "'";
                String queryAddress = "select diachi from Users WHERE userName = '" + txtUsersName.Text + "'";
                String queryDateOfBirth = "select dateOfBirth from Users WHERE userName = '" + txtUsersName.Text + "'";
                String querySdt = "select sdt from Users WHERE userName = '" + txtUsersName.Text + "'";

                SqlCommand cmdName = new SqlCommand(queryName, conn);
                SqlCommand cmdAddress = new SqlCommand(queryAddress, conn);
                SqlCommand cmdDate = new SqlCommand(queryDateOfBirth, conn);
                SqlCommand cmdSdt = new SqlCommand(querySdt, conn);


                userName = (string)cmdName.ExecuteScalar();
                dateOfBirth = Convert.ToDateTime(cmdDate.ExecuteScalar());
                address = (string)cmdAddress.ExecuteScalar();
                sdt = (string)cmdSdt.ExecuteScalar();

                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Login. Please check userID or Password!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignInForm f = new SignInForm();
            f.ShowDialog();
        }
    }
}
