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
using System.Collections;

namespace KatlynMurphyPizzaStore
{
    public partial class EmployeeMenu : Form
    {

        public static String custfirstname = "";
        public static String custlastname = "";
        public static String custusername = "";
        public static String custpassword = "";
        public static String custstreet = "";
        public static String custcity = "";
        public static String custstate = "";
        public static String custzip = "";
        public static String custphone = "";
        public static String custcardsecurity = "";
        public static String custcardexp = "";
        public static String custcardnum = "";

        public static int searchCustID;

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
        //public static String orderStatus = "Recieved";
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
        public static int checkOrderNumber;
        public static String validorderStatus;
        public static String changeorderStatus;
        public static Boolean validnum = false;
        public static String validorderID;
        public static int orderID;

        //arraylist to getter and setter data  
        public static ArrayList ListorderNumber = new ArrayList();
        public static ArrayList ListcustomerID = new ArrayList();
        private static ArrayList ListorderStatus = new ArrayList();

        public static int rowIndex;
        public static int columnIndex;

        //MySqlConnection con = new MySqlConnection("server = localhost; user id = root; password = Summer123; database = katiespizza;");
        public EmployeeMenu()
        {
            InitializeComponent();
            

  
        }

        private void EmployeeMenu_Load(object sender, EventArgs e)
        {

            //dataGridView1.Rows[rowIndex].Cells[columnIndex].Value = value;


            //string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
            string constr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(constr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                con.Open();

                string sql = "SELECT * FROM murphycustomerorder";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, con);
                MySqlDataReader row = cmd.ExecuteReader();

                if (row.HasRows)
                {
                    while (row.Read())
                    {
                        ListorderNumber.Add(row.GetString(0));
                        ListcustomerID.Add(row.GetString(1));
                        ListorderStatus.Add(row.GetString(2));
                    }
                }
                else
                {
                    MessageBox.Show("Data not found");
                }

                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

















            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListorderNumber.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = ListorderNumber[i];
                newRow.Cells[1].Value = ListcustomerID[i];
                newRow.Cells[2].Value = ListorderStatus[i];
                dataGridView1.Rows.Add(newRow);
            }

            panel3.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            searchCustID = Int32.Parse(textBox2.Text); //get inputted number
            //check if custID in database
            //string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
            string constr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                string str1 = "SELECT * FROM murphycustomer WHERE custID = @custID";
                MySqlCommand cmd1 = new MySqlCommand(str1, conn);
                cmd1.Parameters.AddWithValue("@custID", searchCustID);
                MySqlDataReader da = cmd1.ExecuteReader();

                if (da.Read())
                {
                    
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
                    validcustID = da["custID"].ToString();
                    custID = (Int32.Parse(validcustID));
                }
                da.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

            //if order number in database then:
            if (custID == searchCustID)
            {
                label20.Visible = false;
                panel3.Visible = true;
                textBox14.Text = validfirstname;
                textBox13.Text = validlastname;
                textBox3.Text = validstreet;
                textBox4.Text = validcity;
                textBox5.Text = validstate;
                textBox6.Text = validzip;
                textBox7.Text = validphone;
                textBox8.Text = validusername;
                textBox9.Text = validpassword;
                textBox10.Text = validcardnum;
                textBox11.Text = validcardexp;
                textBox12.Text = validcardsecurity;
            }
            else
            {
                label20.Visible = true;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;
            if (selectedIndex == 0)
            {
                changeorderStatus = "Just Recieved";
            }
            else if (selectedIndex == 1)
            {
                changeorderStatus = "Preparing";
            }
            else if (selectedIndex == 2)
            {
                changeorderStatus = "Ready For Pickup";
            }
            else if (selectedIndex == 3)
            {
                changeorderStatus = "Picked Up";
            }

            checkOrderNumber = Int32.Parse(textBox1.Text); //get inputted number

            //check if order number in database
            //string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
            string constr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
            //get order confirmation number

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                string str1 = "SELECT * FROM murphycustomerorder WHERE orderNum = @orderNum";
                MySqlCommand cmd1 = new MySqlCommand(str1, conn);
                cmd1.Parameters.AddWithValue("@orderNum", checkOrderNumber);
                MySqlDataReader da = cmd1.ExecuteReader();

                if (da.Read())
                {
                    validnum = true;
                    validorderNum = da["orderNum"].ToString();
                    orderNum = (Int32.Parse(validorderID));
                    validorderStatus = da["orderStatus"].ToString();
                }
                da.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");

            //if order number in database then:
            if (orderNum == checkOrderNumber)
            {
                
                label21.Visible = false;
                //string constr = "server = localhost; user id = root; password = Summer123; database = katiespizza;";
                //string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
                //MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(constr);
                try
                {
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    string sql1 = "UPDATE murphycustomerorder SET orderStatus = @orderStatus WHERE orderNum = @orderNum";
                    MySql.Data.MySqlClient.MySqlCommand cmd1 = new MySql.Data.MySqlClient.MySqlCommand(sql1, conn);
                    cmd1.Parameters.AddWithValue("@orderStatus", changeorderStatus);
                    cmd1.Parameters.AddWithValue("@orderNum", orderID);
                    cmd1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
                Console.WriteLine("Done.");



                //update datagrid
                dataGridView1.Rows.Clear();
                for (int i = 0; i < ListorderNumber.Count; i++)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = ListorderNumber[i];
                    newRow.Cells[1].Value = ListcustomerID[i];
                    newRow.Cells[2].Value = ListorderStatus[i];
                    dataGridView1.Rows.Add(newRow);
                }
            }
            else
            {
                label21.Visible = true;
            }


           

            //textBox3.Text = validorderStatus;


            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //update datagrid
            dataGridView1.Rows.Clear();
            for (int i = 0; i < ListorderNumber.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridView1);
                newRow.Cells[0].Value = ListorderNumber[i];
                newRow.Cells[1].Value = ListcustomerID[i];
                newRow.Cells[2].Value = ListorderStatus[i];
                dataGridView1.Rows.Add(newRow);
            }
        }
    }
}
