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
    public partial class CreateCustomerAccount : Form
    {
        //MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = Summer123; database = katiespizza;");
        public String firstName;
        public String lastName;
        public String street;
        public String city;
        public String state;
        public String zip;
        public String phone;
        public String custUser;
        public String custPass;
        public String cardNum;
        public String cardExp;
        public String cardSecurity;
        public static Boolean accountCreated = false;
        public static Boolean camefromcheckout;


        public CreateCustomerAccount()
        {
            InitializeComponent();
        }

        private void CreateCustomerAccount_Load(object sender, EventArgs e)
        {
            label14.Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            //first name
            firstName = textBox1.Text;
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            //last name
            lastName = textBox2.Text;

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //street address
            street = textBox3.Text;

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //city
            city = textBox4.Text;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //state
            state = textBox5.Text;

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //zip
            zip = textBox6.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //phone
            phone = textBox7.Text;

        }

        public void textBox8_TextChanged(object sender, EventArgs e)
        {
            //username
            custUser = textBox8.Text;

        }

        public void textBox9_TextChanged(object sender, EventArgs e)
        {
            //password
            custPass = textBox9.Text;

        }

        public void textBox10_TextChanged(object sender, EventArgs e)
        {
            //card number
            cardNum = textBox10.Text;

        }

        public void textBox11_TextChanged(object sender, EventArgs e)
        {
            //card expiration
            cardExp = textBox11.Text;

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            //card cvv
            cardSecurity = textBox12.Text;

        }

        public void button1_Click(object sender, EventArgs e)
        {

            firstName = textBox1.Text;
            lastName = textBox2.Text;
            street = textBox3.Text;
            city = textBox4.Text;
            state = textBox5.Text;
            zip = textBox6.Text;
            phone = textBox7.Text;
            custUser = textBox8.Text;
            custPass = textBox9.Text;
            cardNum = textBox10.Text;
            cardExp = textBox11.Text;
            cardSecurity = textBox12.Text;


            //string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
            string constr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM murphycustomer WHERE custUser = @custUser";
                MySql.Data.MySqlClient.MySqlCommand command = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);

                command.Parameters.AddWithValue("@custUser", custUser);
                int exists = Convert.ToInt32(command.ExecuteScalar());

                if (exists != 0)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";

                    label14.Visible = true;
                }
                else
                {
                    string sql1 = "INSERT INTO murphycustomer (firstName, lastName, street, city, state, zip, phone, custUser, custPass, cardNum, cardExp, cardSecurity) VALUES (@firstName, @lastName, @street, @city, @state, @zip, @phone, @custUser, @custPass, @cardNum, @cardExp, @cardSecurity)";
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand(sql1, conn);
                    cmd1.Parameters.AddWithValue("@firstName", firstName);
                    cmd1.Parameters.AddWithValue("@lastName", lastName);
                    cmd1.Parameters.AddWithValue("@street", street);
                    cmd1.Parameters.AddWithValue("@city", city);
                    cmd1.Parameters.AddWithValue("@state", state);
                    cmd1.Parameters.AddWithValue("@zip", zip);
                    cmd1.Parameters.AddWithValue("@phone", phone);
                    cmd1.Parameters.AddWithValue("@custUser", custUser);
                    cmd1.Parameters.AddWithValue("@custPass", custPass);
                    cmd1.Parameters.AddWithValue("@cardNum", cardNum);
                    cmd1.Parameters.AddWithValue("@cardExp", cardExp);
                    cmd1.Parameters.AddWithValue("@cardSecurity", cardSecurity);
                    cmd1.ExecuteNonQuery();

                    MessageBox.Show("Account created Successfully!");
                    if (camefromcheckout == true)
                    {
                        CheckoutForm checkout = new CheckoutForm();
                        CheckoutForm.accountCreated = true;
                        CheckoutForm.login = true;
                        checkout.Show();
                    }

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
