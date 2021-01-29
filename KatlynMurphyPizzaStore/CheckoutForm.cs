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
    public partial class CheckoutForm : Form
    {
        //MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = Summer123; database = katiespizza;");

        //menu amounts
        public static int shoppingCartItem = 0;
        public static int cheesePizzaAmount = 0;
        public static int pepperoniPizzaAmount = 0;
        public static int veggiePizzaAmount = 0;
        public static int fruitPizzaAmount = 0;
        public static double totalPrice = 0.0;
        public static String datePlaced = ("dd/MM/yyyy HH:mm");
        DateTime date = DateTime.Today;
        DateTime dateTime = DateTime.UtcNow.Date;
        //datePlaced = dateTime.ToString("dd/MM/yyyy");
        


        //label titles 
        public static String cheeseAmountTitle = "Amount in Shopping Cart: ";
        public static String pepperoniAmountTitle = "Amount in Shopping Cart: ";
        public static String veggieAmountTitle = "Amount in Shopping Cart: ";
        public static String fruitAmountTitle = "Amount in Shopping Cart: ";

        public static String shoppingCartTitle = "Total Menu Items in Shopping Cart: ";
        public static String totalPriceTitle = "Total Price: ";

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
        public static String orderStatus = "Just Recieved";
        public static int orderNum;
        public static Boolean login;
        public static Boolean accountCreated;
        public static Boolean camefromcheckout;

        public static String validfirstname = "";
        public static String validlastname = "";
        public static String validusername = "";
        public static String validpassword = "";
        public static String validstreet = "";
        public static String validcardsecurity = "";
        public static String validcardexp = "";
        public static String validcardnum = "";
        public static String validcustID = "";
        public static String validorderNum = "";

        public CheckoutForm()
        {
            InitializeComponent();
            
        }

        public void CheckoutForm_Load(object sender, EventArgs e)
        {
            if (login == false)
            {
                panel2.Visible = true;
                panel3.Visible = false;
              
            }
            else
            {
                panel2.Visible = false;
                panel3.Visible = true;
            }
            

            textBox10.Text = cardNum;
            textBox11.Text = cardExp;
            textBox12.Text = cardSecurity;

            cheeseAmountLabel.Text = cheeseAmountTitle + cheesePizzaAmount;
            pepperoniAmountLabel.Text = pepperoniAmountTitle + pepperoniPizzaAmount;
            veggieAmountLabel.Text = veggieAmountTitle + veggiePizzaAmount;
            fruitAmountLabel.Text = fruitAmountTitle + fruitPizzaAmount;

            totalCheeseLabel.Text = "Total Price of Cheese Pizza: " + cheesePizzaAmount * 9.99;
            totalPepperoniLabel.Text = "Total Price of Pepperoni Pizza: " + pepperoniPizzaAmount * 12.99;
            totalVeggieLabel.Text = "Total Price of Veggie Pizza: " + veggiePizzaAmount * 12.99;
            totalFruitLabel.Text = "Total Price of Fruit Pizza: " + fruitPizzaAmount * 10.99;
            totalPriceLabel.Text = "Total Price of Menu Items in Shopping Cart: " + totalPrice;

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            //create order
            //string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
            string constr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                
                string sql = "INSERT INTO murphycustomerorder (custID, orderStatus, cheese, pepperoni, veggie, fruit, price, datePlaced) VALUES (@custID, @orderStatus, @cheesePizzaAmount, @pepperoniPizzaAmount, @veggiePizzaAmount, @fruitPizzaAmount, @totalPrice, @datePlaced)";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@custID", custID);
                cmd.Parameters.AddWithValue("@orderStatus", orderStatus);
                cmd.Parameters.AddWithValue("@cheesePizzaAmount", cheesePizzaAmount);
                cmd.Parameters.AddWithValue("@pepperoniPizzaAmount", pepperoniPizzaAmount);
                cmd.Parameters.AddWithValue("@veggiePizzaAmount", veggiePizzaAmount);
                cmd.Parameters.AddWithValue("@fruitPizzaAmount", fruitPizzaAmount);
                cmd.Parameters.AddWithValue("@totalPrice", totalPrice);
                cmd.Parameters.AddWithValue("@datePlaced", datePlaced = dateTime.ToString("MM/dd/yyyy hh:mm"));
                cmd.ExecuteNonQuery();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");



            //get order confirmation number

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                
                string str1 = "SELECT * FROM murphycustomerorder WHERE custID = @custID AND orderStatus = @orderStatus AND cheese = @cheesePizzaAmount AND pepperoni = @pepperoniPizzaAmount AND veggie = @veggiePizzaAmount AND fruit = @fruitPizzaAmount AND price = @totalPrice AND datePlaced = @datePlaced";
                MySqlCommand cmd1 = new MySqlCommand(str1, conn);
                cmd1.Parameters.AddWithValue("@custID", custID);
                cmd1.Parameters.AddWithValue("@orderStatus", orderStatus);
                cmd1.Parameters.AddWithValue("@cheesePizzaAmount", cheesePizzaAmount);
                cmd1.Parameters.AddWithValue("@pepperoniPizzaAmount", pepperoniPizzaAmount);
                cmd1.Parameters.AddWithValue("@veggiePizzaAmount", veggiePizzaAmount);
                cmd1.Parameters.AddWithValue("@fruitPizzaAmount", fruitPizzaAmount);
                cmd1.Parameters.AddWithValue("@totalPrice", totalPrice);
                cmd1.Parameters.AddWithValue("@datePlaced", datePlaced = dateTime.ToString("MM/dd/yyyy hh:mm"));
                MySqlDataReader da = cmd1.ExecuteReader();

                if (da.Read())
                {
                    validorderNum = da["orderNum"].ToString();
                    orderNum = (Int32.Parse(validorderNum));
                }
                da.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

            label3.Text = "Payment Successful!";
            label4.Text = "Order Confirmation Number: " + orderNum;
            label5.Text = "Order Status: " + orderStatus;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cancel
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //main menu
            this.Hide();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //card num change
            cardNum = textBox10.Text;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //card exp changed
            cardExp = textBox11.Text;
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            //card security changed
            cardSecurity = textBox12.Text;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
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
                    validcardnum = da["cardNum"].ToString();
                    validcardexp = da["cardExp"].ToString();
                    validcardsecurity = da["cardSecurity"].ToString();
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
                panel3.Visible = true;
                panel2.Visible = false;
                login = true;
                Form1.custUser = validusername;
                Form1.custPass = validpassword;
                Form1.cardNum = validcardnum;
                Form1.cardExp = validcardexp;
                Form1.cardSecurity = validcardsecurity;
                CheckoutForm.custUser = validusername;
                CheckoutForm.custPass = validpassword;
                CheckoutForm.cardNum = validcardnum;
                CheckoutForm.cardExp = validcardexp;
                CheckoutForm.cardSecurity = validcardsecurity;
                textBox10.Text = cardNum;
                textBox11.Text = cardExp;
                textBox12.Text = cardSecurity;
                MessageBox.Show("Login Successful!");
            }
            else
            {
                MessageBox.Show("Login Unsuccessful! Please try again.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
