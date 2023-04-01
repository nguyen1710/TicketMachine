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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TicketMachine
{
    public partial class MainForm : Form
    {
        public static string diemdi = "";
        public static string diemden = "";
        public static string loaixe = "";
        public static string ngaydi = "";
        public static int sotien = 0;
        public static string status = "";


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm f = new LoginForm();
            f.ShowDialog();
            LoadData();
        }

        private void LoadData()
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Journey", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
                dataGridView1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Data");
            }

            conn.Close();
        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQRCode_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Program.strConn);
            conn.Open();
            String queryMoney = "Select sotien from Journey Where diemden = '" + cbbDen.Text + "'";
            String queryKhoangCach = "Select khoangcach from Journey Where diemden = '" + cbbDen.Text + "'";
            SqlCommand cmdMoney = new SqlCommand(queryMoney, conn);
            SqlCommand cmdKC = new SqlCommand(queryKhoangCach, conn);
            sotien = Convert.ToInt32(cmdMoney.ExecuteScalar()) * Convert.ToInt32(cmdKC.ExecuteScalar());
            diemdi = cbbDi.Text;
            diemden = cbbDen.Text;
            loaixe = cbbXe.Text;
            ngaydi = txtNgaydi.Text;
            status = "Đã chuyển khoản bằng mã QR";
            QRForm f = new QRForm();
            f.ShowDialog();
        }

        private void btnCK_Click(object sender, EventArgs e)
        {
            DialogResult bank = MessageBox.Show("Ngân hàng Sacombank \r" +
                "Tài khoản thị hưởng: NGUYEN THANH NGUYEN \r" +
                "STK: 070120125751", "Chuyển khoản", MessageBoxButtons.YesNo); 
            if(bank == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection(Program.strConn);
                conn.Open();
                String queryMoney = "Select sotien from Journey Where diemden = '" + cbbDen.Text + "'";
                String queryKhoangCach = "Select khoangcach from Journey Where diemden = '" + cbbDen.Text + "'";
                SqlCommand cmdMoney = new SqlCommand(queryMoney, conn);
                SqlCommand cmdKC = new SqlCommand(queryKhoangCach, conn);
                sotien = Convert.ToInt32(cmdMoney.ExecuteScalar()) * Convert.ToInt32(cmdKC.ExecuteScalar());
                diemdi = cbbDi.Text;
                diemden = cbbDen.Text;
                loaixe = cbbXe.Text;
                ngaydi = txtNgaydi.Text;
                status = "Đã chuyển khoản bằng chuyển khoản";
                Bill f = new Bill();
                f.ShowDialog();
            }
        }
    }
}
