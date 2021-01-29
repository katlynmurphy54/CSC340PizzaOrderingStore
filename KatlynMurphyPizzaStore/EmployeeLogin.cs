using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace KatlynMurphyPizzaStore
{
    public partial class EmployeeLogin : Form
    {
        //MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = Summer123; database = katiespizza;");
        public EmployeeLogin()
        {
            InitializeComponent();
        }

        private void EmployeeLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Employee1" && textBox2.Text == "Pass1")
            {
                EmployeeMenu empMenu = new EmployeeMenu();
                empMenu.ShowDialog();
                this.Close();
            }
            else
            {
                label4.Text = "Unsuccessful! Please try again.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //main menu
            this.Hide();
        }
    }
}
