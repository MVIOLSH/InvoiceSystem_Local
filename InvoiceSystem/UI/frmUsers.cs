using InvoiceSystem.BLL;
using InvoiceSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceSystem.UI
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        userBLL u = new userBLL();
        userDAL dal = new userDAL();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Getting data from UI

        }
    }
}
