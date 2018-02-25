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
    public partial class User : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        public User()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void save_Click(object sender, EventArgs e)
        {

        }

        private void User_Load(object sender, EventArgs e)
        {
            Mycon.con.Close();
            Mycon.con.Open();
            loadUserList();
        }

        void loadUserList()
        {
            listView1.Items.Clear();
            if (search.Text == "")
            {
                Com.CommandText = "SELECT id,username,first_name,last_name,email,role,contact_number FROM users ORDER BY id ASC";
            }
            else
            {
                //Com.CommandText = "SELECT * FROM production_staff WHERE prod_staff_fn LIKE '" + search.Text + "%' ORDER BY prod_staff_fn ASC";
            }
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                
                ListViewItem list = new ListViewItem(reader["username"].ToString());
                list.SubItems.Add(reader["first_name"].ToString() + " " + reader["last_name"].ToString());
                list.SubItems.Add(reader["email"].ToString());
                list.SubItems.Add(role(reader["role"].ToString()));
                list.SubItems.Add(reader["contact_number"].ToString());
                listView1.Items.AddRange(new ListViewItem[] { list });
            }
            reader.Close();
            Com.Dispose();
        }

        public string role(string id) {
            string name;
            if (id =="1")
            {
                name = "Admin";
            }
            else
            {
                name = "Manager";
            }
            return name;
        }

    }
}
