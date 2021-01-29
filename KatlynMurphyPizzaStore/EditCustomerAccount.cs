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

    public partial class EditCustomerAccount : Form
    {
        public static String firstName;
        public static String lastName;
        public static String street;
        public static String city;
        public static String state;
        public static String zip;
        public static String phone;
        public static String custUser;
        public static String custPass;
        public static int custID;
        public static String cardNum;
        public static String cardExp;
        public static String cardSecurity;
        public static String orderStatus = "Recieved";
        public static int orderNum;
        public static Boolean login = false;
        public static Boolean accountCreated;
        public static Boolean camefromcheckout;

        public static String validfirstname = "";
        public static String validlastname = "";
        public static String validusername = "";
        public static String validpassword = "";
        public static String validstreet = "";
        public static String validstate = "";
        public static String validcity = "";
        public static String validzip = "";
        public static String validphone = "";
        public static String validcardsecurity = "";
        public static String validcardexp = "";
        public static String validcardnum = "";
        public static String validcustID = "";
        public static String validorderNum = "";
        public static Boolean validlogin = false;
        public static Boolean validLoginBefore;




        //MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = Summer123; database = katiespizza;");
        public EditCustomerAccount()
        {
            InitializeComponent();
                panel1.Visible = false;
                panel2.Visible = true;
            
        }

        private void EditCustomerAccount_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {


            //check if customer exists && validate


            //string constr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                con.Open();

                string str = "SELECT * FROM murphycustomer WHERE custUser = @custUser AND custPass = @custPass";
                MySqlCommand cmd = new MySqlCommand(str, con);

                cmd.Parameters.AddWithValue("@custUser", textBox13.Text);
                cmd.Parameters.AddWithValue("@custPass", textBox14.Text);

                MySqlDataReader da = cmd.ExecuteReader();

                if (da.Read())
                {
                    validlogin = true;
                    validusername = da["custUser"].ToString();
                    validpassword = da["custPass"].ToString();
                    validfirstname = da["firstName"].ToString();
                    validlastname = da["lastName"].ToString();
                    validcardnum = da["cardNum"].ToString();
                    validcardexp = da["cardExp"].ToString();
                    validcardsecurity = da["cardSecurity"].ToString();
                    validstreet = da["street"].ToString();
                    validstate = da["state"].ToString();
                    validcity = da["city"].ToString();
                    validzip = da["zip"].ToString();
                    validphone = da["phone"].ToString();
                }
                da.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            con.Close();

            if (validlogin == true)
            {
                MessageBox.Show("Successful Login!");
                panel1.Visible = true;
                panel2.Visible = false;
                textBox1.Text = validfirstname;
                textBox2.Text = validlastname;
                textBox3.Text = validstreet;
                textBox4.Text = validcity;
                textBox5.Text = validstate;
                textBox6.Text = validzip;
                textBox7.Text = validphone;
                textBox10.Text = validcardnum;
                textBox11.Text = validcardexp;
                textBox12.Text = validcardsecurity;
            }
            else
            {
                MessageBox.Show("Unsuccessful Login! Please Try Again.");
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {

            //after confirming changes check creditals
            //string constr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
            MySqlConnection con = new MySqlConnection(constr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                con.Open();

                string str = "SELECT * FROM murphycustomer WHERE custUser = @custUser AND custPass = @custPass";
                MySqlCommand cmd = new MySqlCommand(str, con);

                cmd.Parameters.AddWithValue("@custUser", textBox13.Text);
                cmd.Parameters.AddWithValue("@custPass", textBox14.Text);

                MySqlDataReader da = cmd.ExecuteReader();

                if (da.Read())
                {
                    validlogin = true;
                    custUser = da["custUser"].ToString();
                    custPass = da["custPass"].ToString();
                    validcustID = da["custID"].ToString();
                    custID = (Int32.Parse(validcustID));
                }
                da.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            con.Close();

            if (textBox8.Text == custUser && textBox9.Text == custPass)
            {
                //custUser = validusername;
                //custPass = validpassword;

                login = true;
                MessageBox.Show("Account Successfully updated!");

                firstName = textBox1.Text;
                lastName = textBox2.Text;
                street = textBox3.Text;
                city = textBox4.Text;
                state = textBox5.Text;
                zip = textBox6.Text;
                phone = textBox7.Text;
                cardNum = textBox10.Text;
                cardExp = textBox11.Text;
                cardSecurity = textBox12.Text;


                //string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
                //string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    string sql1 = "UPDATE murphycustomer SET firstName = @firstname, lastName = @lastname, street = @street, city = @city, state = @state, zip = @zip, phone = @phone, cardNum = @cardNum, cardExp = @cardExp, cardSecurity = @cardSecurity WHERE custID = @custID";
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand(sql1, conn);
                    cmd1.Parameters.AddWithValue("@firstName", firstName);
                    cmd1.Parameters.AddWithValue("@lastName", lastName);
                    cmd1.Parameters.AddWithValue("@street", street);
                    cmd1.Parameters.AddWithValue("@city", city);
                    cmd1.Parameters.AddWithValue("@state", state);
                    cmd1.Parameters.AddWithValue("@zip", zip);
                    cmd1.Parameters.AddWithValue("@phone", phone);
                    cmd1.Parameters.AddWithValue("@cardNum", cardNum);
                    cmd1.Parameters.AddWithValue("@cardExp", cardExp);
                    cmd1.Parameters.AddWithValue("@cardSecurity", cardSecurity);
                    cmd1.Parameters.AddWithValue("@custID", custID);
                    cmd1.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
                Console.WriteLine("Done.");











                /*
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
                */
                EditCustomerAccount.login = true;
                //Form1.welcome = "Welcome " + validfirstname + " " + validlastname + "!";
                //MessageBox.Show("Account updated Successfully!");
            }
            else
            {
                CheckoutForm.login = false;
                Form1.login = false;
                MessageBox.Show("Account not successfully updated! Please try again.");
            }


        }
    }
}
