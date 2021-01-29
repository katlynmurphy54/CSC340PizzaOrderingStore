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
    public partial class CustomerLogin : Form
    {

        //MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = Summer123; database = katiespizza;");

        public static String firstName;
        public static String lastName;
        public static String street;
        public static String city;
        public static String state;
        public static String zip;
        public static String phone;
        public static String custUser;
        public static String custPass;
        public static String cardNum;
        public static String cardExp;
        public static String cardSecurity;
        public static int custID;


        public static String validfirstname = "";
        public static String validlastname = "";
        public static String validusername = "";
        public static String validpassword = "";
        public static String validstreet = "";
        public static String validcardsecurity = "";
        public static String validcardexp = "";
        public static String validcardnum = "";
        public static String validcustID = "";

        public static String validstate = "";
        public static String validcity = "";
        public static String validzip= "";
        public static String validphone = "";

        public static Boolean login = false;
        public static Boolean validLoginBefore = false;

        public CustomerLogin()
        {
            InitializeComponent();

        }

        private void CustomerLogin_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            //check if customer exists && validate


            string constr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            //string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                con.Open();

                string str = "SELECT * FROM murphycustomer WHERE custUser = @custUser AND custPass = @custPass";
                MySqlCommand cmd = new MySqlCommand(str, con);

                cmd.Parameters.AddWithValue("@custUser", textBox1.Text);
                cmd.Parameters.AddWithValue("@custPass", textBox2.Text);

                MySqlDataReader da = cmd.ExecuteReader();

                if (da.Read())
                {
                    validusername = da["custUser"].ToString();
                    validpassword = da["custPass"].ToString();
                    validfirstname = da["firstName"].ToString();
                    validlastname = da["lastName"].ToString();
                    validstreet = da["street"].ToString();
                    validcity = da["city"].ToString();
                    validzip = da["zip"].ToString();
                    validstate = da["state"].ToString();
                    validphone = da["phone"].ToString();
                    validcardnum = da["cardNum"].ToString();
                    validcardsecurity = da["cardSecurity"].ToString();
                    validcardexp = da["cardExp"].ToString();
                    validcustID = da["custID"].ToString();
                    custID = (Int32.Parse(validcustID));
                    //validcustID = da["custID"].ToString();
                }

                da.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            con.Close();



            if (textBox1.Text == validusername && textBox2.Text == validpassword)
            {
                login = true;
                MessageBox.Show("Login Successful!");
                EditCustomerAccount.firstName = validfirstname;
                EditCustomerAccount.lastName = validlastname;
                EditCustomerAccount.street = validstreet;
                EditCustomerAccount.city = validcity;
                EditCustomerAccount.state = validstate;
                EditCustomerAccount.zip = validzip;
                EditCustomerAccount.phone = validphone;
                EditCustomerAccount.cardNum = validcardnum;
                EditCustomerAccount.cardExp = validcardexp;
                EditCustomerAccount.cardSecurity = validcardsecurity;
                EditCustomerAccount.validLoginBefore = true;

                Form1.custUser = validusername;
                Form1.custPass = validpassword;
                Form1.cardNum = validcardnum;
                Form1.cardExp = validcardexp;
                Form1.login = true;
                Form1.cardSecurity = validcardsecurity;
                CheckoutForm.custUser = validusername;
                CheckoutForm.custPass = validpassword;
                CheckoutForm.cardNum = validcardnum;
                CheckoutForm.cardExp = validcardexp;
                CheckoutForm.cardSecurity = validcardsecurity;
                CheckoutForm.custID = custID;
                CheckoutForm.login = true;
                
                EditCustomerAccount.login = true;
                //Form1.welcome = "Welcome " + validfirstname + " " + validlastname + "!";
                this.Hide();
            }
            else
            {
                CheckoutForm.login = false;
                Form1.login = false;
                MessageBox.Show("Login Unsuccessful! Please try again.");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //main menu button
            this.Hide();
        }
    }
}
