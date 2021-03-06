﻿using System;
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
        string Sstatus;
        public User()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void save_Click(object sender, EventArgs e)
        {
            validation();
        }

        private void User_Load(object sender, EventArgs e)
        {
            Sstatus = "save";
            Mycon.con.Close();
            Mycon.con.Open();
            combvalue();
            loadUserList();
            comboBox1.SelectedIndex = 0;

        }

        void loadUserList()
        {
            listView1.Items.Clear();
            if (search.Text == "")
            {
                Com.CommandText = "SELECT id,first_name,last_name,email,role,contact_number FROM users ORDER BY id ASC";
            }
            else
            {
                Com.CommandText = "SELECT id,first_name,last_name,email,role,contact_number FROM users where email like '" + search.Text + "%' ORDER BY id ASC";
            }
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem list = new ListViewItem(reader["id"].ToString());
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

        public void combvalue()
        {
            comboBox1.Items.Insert(0, "< Select Person >");
            comboBox1.Items.Insert(1,"Admin");
            comboBox1.Items.Insert(2, "Manager");

        }

        public void validation()
        {

            if (first_name.Text == "")
            {
                MessageBox.Show("First Name is Required");
            }

            else if(last_name.Text == "")
            {
                MessageBox.Show("Last Name is Required");
            }
            else if (Sstatus=="save")
            {
                if (password.Text == "")
                {
                    MessageBox.Show("Password is Required");
                }
            }
            

            else if(email.Text == "")
            {
                MessageBox.Show("Email is Required");
            }

            else if(comboBox1.SelectedIndex < 1)
            {
                MessageBox.Show("Select a Role");
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
                    Com.CommandText = "Insert into users(email,first_name,last_name,password,role,contact_number) Values('" + email.Text + "','" + first_name.Text + "','" + last_name.Text + "','" + encryption(password.Text) + "','" + comboBox1.SelectedIndex + "','" + contact.Text + "')";
                    Com.ExecuteNonQuery();
                    Com.Dispose();
                    MessageBox.Show("New User Create SuccessFUlly");
                    reset();
                }
                else if (Sstatus == "edit")
                {
                    int a = listView1.SelectedIndices[0];
                    string id = listView1.Items[a].Text;
                    string p = "";
                    if (password.Text != "")
                    {
                        p = "',password='" + encryption(password.Text);
                    }
                    string d = Com.CommandText = "Update users set email='" + email.Text +
                                "',first_name ='" + first_name.Text +
                                "',contact_number ='" + contact.Text +
                                "',last_name ='" + last_name.Text + p +
                                "',role ='" + comboBox1.SelectedIndex + "' Where id='" + id + "'";
                    MessageBox.Show(d);
                    Com.ExecuteNonQuery();
                    Com.Dispose();
                    reset();
                    Sstatus = "save";
                    MessageBox.Show("Update User Info");
                }
                loadUserList();
            }
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
            if (Sstatus=="edit")
            {
                int a = listView1.SelectedIndices[0];
                string id = listView1.Items[a].Text;
                Com.CommandText = "SELECT id FROM users WHERE email= '" + email + "' and id != '" + id +"'";
            }else
            {
                Com.CommandText = "SELECT id FROM users WHERE email= '" + email + "'";
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

        public string encryption(String password)
        {
            byte[] asciiBytes = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashedBytes = MD5CryptoServiceProvider.Create().ComputeHash(asciiBytes);
            string hashedString = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            return hashedString.ToString();
        }

        public void reset()
        {
            email.Text = first_name.Text = last_name.Text = password.Text = contact.Text = "";
            comboBox1.SelectedIndex = 0;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int a =  listView1.SelectedIndices[0];
            string id = listView1.Items[a].Text;
            Com.CommandText = "SELECT * FROM users WHERE id = '" + id + "'";
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                email.Text = reader["email"].ToString();
                first_name.Text = reader["first_name"].ToString();
                last_name.Text = reader["last_name"].ToString();
                contact.Text = reader["contact_number"].ToString();
                comboBox1.SelectedIndex = reader.GetInt32("role");
            }
            reader.Close();
            Sstatus = "edit";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadUserList();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int a = listView1.SelectedIndices[0];
                string id = listView1.Items[a].Text;
                MessageBox.Show(id);
                Com.CommandText = "delete from users WHERE id = '" + id + "'";
                reader = Com.ExecuteReader();
                reader.Close();
                reset();
                loadUserList();
            }else
            {
                reset();
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Sstatus = "save";
            reset();
        }
    }
}
