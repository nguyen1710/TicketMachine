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
    public partial class Bill : Form
    {
        public Bill()
        {
            InitializeComponent();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
             lbName.Text = LoginForm.userName;
             lbDateofBirth.Text = LoginForm.dateOfBirth.ToString("dd/MM/yyyy");
             lbSdt.Text= LoginForm.sdt;
             lbAddress.Text = LoginForm.address;
             lbHanhtrinh.Text = MainForm.diemdi + " - " + MainForm.diemden;
             lbLoaixe.Text = MainForm.loaixe;
             lbDate.Text = MainForm.ngaydi;
             lbSotien.Text = Convert.ToString(MainForm.sotien);
             lbThanhToan.Text = MainForm.status;
        }
    }
}
