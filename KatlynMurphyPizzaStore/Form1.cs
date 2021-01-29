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
    public partial class Form1 : Form
    {

        //menu amounts
        public static int shoppingCartItem = 0;
        public static int cheesePizzaAmount = 0;
        public static int pepperoniPizzaAmount = 0;
        public static int veggiePizzaAmount = 0;
        public static  int fruitPizzaAmount = 0;
        public static double totalPrice = 0.0;


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
        public static String cardNum;
        public static String cardExp;
        public static String cardSecurity;

        public static String welcome = "Welcome!";
        public static Boolean login;

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        public void buyCheeseButton_Click(object sender, EventArgs e)
        {
            cheesePizzaAmount++;
            shoppingCartItem++;
            totalPrice += 9.99;
            cheeseAmountLabel.Text = cheeseAmountTitle + cheesePizzaAmount;
            shoppingCartLabel.Text = shoppingCartTitle + shoppingCartItem;
            totalPriceLabel.Text = totalPriceTitle + totalPrice;
        }

        public void buyPepperoniButton_Click(object sender, EventArgs e)
        {
            pepperoniPizzaAmount++;
            shoppingCartItem++;
            totalPrice += 12.99;
            pepperoniAmountLabel.Text = pepperoniAmountTitle + pepperoniPizzaAmount;
            shoppingCartLabel.Text = shoppingCartTitle + shoppingCartItem;
            totalPriceLabel.Text = totalPriceTitle + totalPrice;

        }

        public void buyVeggieButton_Click(object sender, EventArgs e)
        {
            veggiePizzaAmount++;
            shoppingCartItem++;
            totalPrice += 12.99;
            veggieAmountLabel.Text = veggieAmountTitle + veggiePizzaAmount;
            shoppingCartLabel.Text = shoppingCartTitle + shoppingCartItem;
            totalPriceLabel.Text = totalPriceTitle + totalPrice;

        }

        public void buyFruitButton_Click(object sender, EventArgs e)
        {
            fruitPizzaAmount++;
            shoppingCartItem++;
            totalPrice += 10.99;
            fruitAmountLabel.Text = fruitAmountTitle + fruitPizzaAmount;
            shoppingCartLabel.Text = shoppingCartTitle + shoppingCartItem;
            totalPriceLabel.Text = totalPriceTitle + totalPrice;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //customer login
            CustomerLogin custLogin = new CustomerLogin();
            custLogin.ShowDialog();

        }

        public void button4_Click(object sender, EventArgs e)
        {
            //employee 
            EmployeeLogin empLogin = new EmployeeLogin();
            empLogin.ShowDialog();

        }

        public void button1_Click(object sender, EventArgs e)
        {
            //trace order status
            TraceOrderStatus orderStatus = new TraceOrderStatus();
            orderStatus.Show();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            //create customer account
            CreateCustomerAccount newCustomerForm = new CreateCustomerAccount();
            newCustomerForm.Show();
            
        }

        public void checkOutButton_Click(object sender, EventArgs e)
        {
            CheckoutForm checkout = new CheckoutForm();
            CheckoutForm.cheesePizzaAmount = cheesePizzaAmount;
            CheckoutForm.pepperoniPizzaAmount = pepperoniPizzaAmount;
            CheckoutForm.veggiePizzaAmount = veggiePizzaAmount;
            CheckoutForm.fruitPizzaAmount = fruitPizzaAmount;
            CheckoutForm.totalPrice = totalPrice;
            CheckoutForm.cardNum = cardNum;
            CheckoutForm.cardExp = cardExp;
            CheckoutForm.cardSecurity = cardSecurity;
            checkout.ShowDialog();
        }

        public void clearOrderButton_Click(object sender, EventArgs e)
        {
            cheesePizzaAmount = 0;
            pepperoniPizzaAmount = 0;
            veggiePizzaAmount = 0;
            fruitPizzaAmount = 0;
            shoppingCartItem = 0;
            totalPrice = 0.0;
            cheeseAmountLabel.Text = cheeseAmountTitle + cheesePizzaAmount;
            pepperoniAmountLabel.Text = pepperoniAmountTitle + pepperoniPizzaAmount;
            veggieAmountLabel.Text = veggieAmountTitle + veggiePizzaAmount;
            fruitAmountLabel.Text = fruitAmountTitle + cheesePizzaAmount;
            shoppingCartLabel.Text = shoppingCartTitle + shoppingCartItem;
            totalPriceLabel.Text = totalPriceTitle + totalPrice;
        }

        public void button6_Click(object sender, EventArgs e)
        {
            //check order history
            OrderHistory customerOrderHistory = new OrderHistory();
            customerOrderHistory.Show();
        }

        public void button5_Click(object sender, EventArgs e)
        {
            //edit customer account
            EditCustomerAccount editAccount = new EditCustomerAccount();
            editAccount.Show();
        }

    }
}