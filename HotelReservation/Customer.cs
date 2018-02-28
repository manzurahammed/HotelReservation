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
namespace HotelReservation
{
    public partial class Customer : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        string Sstatus;
        public Customer()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            Sstatus = "save";
            Mycon.con.Close();
            Mycon.con.Open();
            loadCustomerList();
        }

        private void save_Click(object sender, EventArgs e)
        {
            validation();
        }

        public void validation()
        {

            if (full_name.Text == "")
            {
                MessageBox.Show("First Name is Required");
            }

            else if (email.Text == "")
            {
                MessageBox.Show("Email is Required");
            }
            else if (contact.Text == "")
            {
                MessageBox.Show("COntact Number is Required");
            }
            else if (!IsValidEmail(email.Text))
            {
                MessageBox.Show("Give Valid Email Address");
            }
            else if (existemail(email.Text))
            {
                MessageBox.Show("Email Already Exist");
            }
            else
            {
                if (Sstatus == "save")
                {
                    Com.CommandText = "Insert into customer(full_name,email,contact,address) Values('" + full_name.Text + "','" + email.Text + "','" + contact.Text + "','" + address.Text + "')";
                    Com.ExecuteNonQuery();
                    Com.Dispose();
                    MessageBox.Show("New Customer Added SuccessFUlly");
                    reset();
                }
                else if (Sstatus == "edit")
                {
                    int a = listView1.SelectedIndices[0];
                    string id = listView1.Items[a].Text;
                    string d = Com.CommandText = "Update customer set email='" + email.Text +
                                "',full_name ='" + full_name.Text +
                                "',contact ='" + contact.Text +
                                "',address ='" + address.Text + "' Where id='" + id + "'";
                    Com.ExecuteNonQuery();
                    Com.Dispose();
                    reset();
                    Sstatus = "save";
                    MessageBox.Show("Update User Info");
                }
                loadCustomerList();
            }
        }

        public void reset()
        {
            email.Text = full_name.Text = email.Text = address.Text = contact.Text = "";
            
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        bool existemail(string email)
        {
            if (Sstatus == "edit")
            {
                int a = listView1.SelectedIndices[0];
                string id = listView1.Items[a].Text;
                Com.CommandText = "SELECT id FROM customer WHERE email= '" + email + "' and id != '" + id + "'";
            }
            else
            {
                Com.CommandText = "SELECT id FROM customer WHERE email= '" + email + "'";
            }

            reader = Com.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        void loadCustomerList()
        {
            
            listView1.Items.Clear();
            if (customer_search.Text == "")
            {
                string s = Com.CommandText = "SELECT id,full_name,email,contact,address FROM customer ORDER BY id ASC";
            }
            else
            {
                Com.CommandText = "SELECT id,full_name,email,contact,address FROM customer where full_name like '" + customer_search.Text + "%' ORDER BY id ASC";
            }
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                
                ListViewItem list = new ListViewItem(reader["id"].ToString());
                list.SubItems.Add(reader["full_name"].ToString());
                list.SubItems.Add(reader["email"].ToString());
                list.SubItems.Add(reader["contact"].ToString());
                list.SubItems.Add(reader["address"].ToString());
                listView1.Items.AddRange(new ListViewItem[] { list });
            }
            reader.Close();
            Com.Dispose();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void search_Click(object sender, EventArgs e)
        {
            loadCustomerList();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int a = listView1.SelectedIndices[0];
            string id = listView1.Items[a].Text;
            Com.CommandText = "SELECT * FROM customer WHERE id = '" + id + "'";
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                email.Text = reader["email"].ToString();
                full_name.Text = reader["full_name"].ToString();
                contact.Text = reader["contact"].ToString();
                address.Text = reader["address"].ToString();
            }
            reader.Close();
            Sstatus = "edit";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int a = listView1.SelectedIndices[0];
                string id = listView1.Items[a].Text;
                Com.CommandText = "delete from customer WHERE id = '" + id + "'";
                reader = Com.ExecuteReader();
                reader.Close();
                MessageBox.Show("Delete Row SuccessFully");
                loadCustomerList();
            }
            reset();
        }

        private void setn_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
