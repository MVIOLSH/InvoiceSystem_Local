﻿using InvoiceSystem.BLL;
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

        userBLL u = new userBLL();
        userDAL dal = new userDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string loggedUser = frmLogin.loggedIn;
            userBLL usr = dal.GetIDFromUSername(loggedUser);

            //Getting data from UI
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAdress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUsertype.Text;
            u.added_date = DateTime.Now;
            u.added_by = usr.id;

            //Inserting data in to DB

            bool success = dal.Insert(u);

            if (success == true)
            {
                MessageBox.Show("User succesfully created");
                clear();
            }

            else
            {
                MessageBox.Show("Failed to add new user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;

        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }
        private void clear()
        {
            txtUserId.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            txtAdress.Text = "";
            txtContact.Text = "";
            cmbGender.Text = "";
            cmbUsertype.Text = "";
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the index of a particular row
            int rowIndex = e.RowIndex;
            txtUserId.Text = dgvUsers.Rows[rowIndex].Cells[0].Value.ToString();
            txtFirstName.Text = dgvUsers.Rows[rowIndex].Cells[1].Value.ToString();
            txtLastName.Text = dgvUsers.Rows[rowIndex].Cells[2].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[rowIndex].Cells[3].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[rowIndex].Cells[4].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[rowIndex].Cells[5].Value.ToString();
            txtContact.Text = dgvUsers.Rows[rowIndex].Cells[6].Value.ToString();
            txtAdress.Text = dgvUsers.Rows[rowIndex].Cells[7].Value.ToString();
            cmbGender.Text = dgvUsers.Rows[rowIndex].Cells[8].Value.ToString();
            cmbUsertype.Text = dgvUsers.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Get the values UI
            u.id = Convert.ToInt32(txtUserId.Text);
            u.first_name = txtFirstName.Text;
            u.last_name = txtLastName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAdress.Text;
            u.gender = cmbGender.Text;
            u.user_type = cmbUsertype.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;

            //Update data in BD

            bool success = dal.Update(u);

            if (success == true)
            {
                MessageBox.Show("User succesfully Updated");
                clear();
            }

            else
            {
                MessageBox.Show("Failed to Update the user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtUserId.Text);

            bool success = dal.Delete(u);

            if (success == true)
            {
                MessageBox.Show("User succesfully Deleted");
                clear();
            }

            else
            {
                MessageBox.Show("Failed to Delete the user");
            }
            //Refreshing Data Grid View
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Get Keyords from textbox

            string keywords = txtSearch.Text;

            //check if keyword is not null

            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;
            }

            else
            {
                MessageBox.Show("You didn't input any Keywords to search box");
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;
            }
        }
    }
}
