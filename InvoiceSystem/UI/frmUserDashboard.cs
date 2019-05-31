#define MyDebug
using InvoiceSystem.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceSystem
{
    
    
    public partial class frmUserDashboard : Form
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
                        new Rectangle(30, 288, 120, 20), SystemColors.ControlLight, flags);
        }
#endif
        public frmUserDashboard()
        {
            InitializeComponent();
        }

        private void lblAppFName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmUserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin login = new frmLogin();
            login.Show();
            this.Hide();
        }

        private void frmUserDashboard_Load(object sender, EventArgs e)
        {
            lblLogedInUser.Text = frmLogin.loggedIn;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
