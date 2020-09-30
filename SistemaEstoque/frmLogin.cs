using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEstoque
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
           
            
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            
            this.Close();

           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Equals("") | txtPass.Text.Equals(""))
            {
                MessageBox.Show("Favor digitar um usuário e uma senha!");
                txtUser.Select();
                return;
                
                //txtUser.Focus();
            }
            if (txtUser.Text.Equals("admin") & txtPass.Text.Equals("123456"))
            {
                MessageBox.Show("Login bem sucedido!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                //txtUser.Text = "";
                //txtPass.Text = "";
                MessageBox.Show("Usuário ou senha inválidos!");
                

                txtUser.Select();
            }
            
            
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            ActiveControl = txtUser;

            txtPass.UseSystemPasswordChar=true;

        }
    }
}
