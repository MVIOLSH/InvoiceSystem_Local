//Debug
#define MyDebug

using InvoiceSystem.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace InvoiceSystem
{
    public partial class frmAdminDashboard : Form
    {
#if MyDebug
        protected override void OnPaint(PaintEventArgs e)
        {
            int _cursX = 0;
            int _cursY = 0;

            Graphics dc = e.Graphics;

            TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.EndEllipsis;
            Font _font = new System.Drawing.Font("Stencil", 12, FontStyle.Regular);
            TextRenderer.DrawText(dc, "X=" + _cursX.ToString() + ":" + "Y=" + _cursY.ToString(), _font,
                        new Rectangle(300,1000 , 120, 20), SystemColors.ControlLight, flags);
        }
#endif
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            lblLogedInUser.Text = frmLogin.loggedIn;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblLName_Click(object sender, EventArgs e)
        {

        }

       
        private void usersToolStripMenu1Item_Click(object sender, EventArgs e)
        {
            
        }

        private void usersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();
        }

        private void frmAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategories cat = new frmCategories();
            cat.Show();
        }

        private void lblSHead_Click(object sender, EventArgs e)
        {

        }

        private void mV1ServicesWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://szymanskim.uk");
        }
    }
}
