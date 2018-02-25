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
using System.Security.Cryptography;
namespace HotelReservation
{
    public partial class Form1 : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        public static string myID, userName, role;

        private void Form1_Load(object sender, EventArgs e)
        {
            Mycon.con.Open();
        }

        public Form1()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void login_Click(object sender, EventArgs e)
        {
            try
            {
                if (username.Text == "")
                {
                    MessageBox.Show("Please Enter User Name", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (password.Text == "")
                {
                    MessageBox.Show("Please Enter Password", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    string pass = encryption(password.Text);
                    string uname = username.Text;
                    Com.CommandText = "SELECT count(id),users.* FROM users WHERE username= '" + uname + "' AND password= '" + pass + "'";
                    reader = Com.ExecuteReader();
                    while (reader.Read())
                    {
                        myID = reader[0].ToString();
                        userName = reader["username"].ToString();
                        role = reader["role"].ToString();
                    }
                    reader.Close();
                    Com.Dispose();
                    if (Int32.Parse(myID) < 1)
                    {
                        MessageBox.Show("User does not exist.\nPlease check your username and password...", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        MessageBox.Show("Welcome " + userName + " !!!", "Access Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hotel h = new Hotel();
                        h.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public string encryption(String password)
        {
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedString.ToString();
        }
    }
}
