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
    public partial class Reservation : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        public Reservation()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            Mycon.con.Close();
            Mycon.con.Open();
            customerlist();
            roomlist();
            room_list.SelectedIndex = 0;
            customer_list.SelectedIndex = 0;
            check_in.MaxDate = DateTime.Today.AddMonths(1);
            check_in.MinDate = DateTime.Today;
            check_out.MinDate = DateTime.Today.AddDays(1);
            check_out.MaxDate = DateTime.Today.AddMonths(1);
        }

        public void customerlist()
        {
            Com.CommandText = "SELECT id,full_name FROM customer";
            reader = Com.ExecuteReader();
            customer_list.Items.Insert(0, "< Select Customer >");
            
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = reader["full_name"].ToString();
                item.Value = reader["id"].ToString();
                customer_list.Items.Add(item);
            }
            reader.Close();
        }

        public void roomlist()
        {
            Com.CommandText = "SELECT id,room_number FROM room WHERE book <> '" + 1 + "'";
            reader = Com.ExecuteReader();
            room_list.Items.Insert(0, "< Select Room >");
            while (reader.Read())
            {
                room_list.Items.Add(reader["room_number"].ToString());
            }
            reader.Close();

        }

        private void room_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string room_number = "";
            if (room_list.Text != "")
            {
                room_number = room_list.Text;
            }
            Com.CommandText = "SELECT * FROM room WHERE room_number = '" + room_number + "'";
            reader = Com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (!roomexist(reader["id"].ToString()))
                    {
                        ListViewItem list = new ListViewItem(reader["id"].ToString());
                        list.SubItems.Add(reader["room_number"].ToString());
                        list.SubItems.Add(reader["price"].ToString());
                        listView1.Items.AddRange(new ListViewItem[] { list });
                        string t = total.Text;
                        int value;
                        int.TryParse(t, out value);
                        value = value + reader.GetInt32("price");
                        total.Text = value.ToString();
                    } else
                    {
                        MessageBox.Show("Room Already Add In List");
                    }
                    
                }
            }
            reader.Close();
        }

        bool roomexist(string rnumber)
        {
            bool a = false;
            for (int i = listView1.Items.Count - 1; i >= 0; i--)
            {
                var item = listView1.Items[i];
                if (item.Text.ToLower().Contains(rnumber.ToLower()))
                {
                    a = true;
                    break;
                    
                }
            }
            return a;
        }

        private void book_Click(object sender, EventArgs e)
        {
            //string id = ((customer_list.SelectedItem as ComboboxItem).Value.ToString());
            validation();
        }

        public void validation()
        {

            if (check_in.Text == "")
            {
                MessageBox.Show("Room Number is Required");
            }
            else if (check_out.Text == "")
            {
                MessageBox.Show("Room Price is Required");
            }
            else if (customer_list.SelectedIndex < 1)
            {
               MessageBox.Show("Select A Customer");

            }
            else if (listView1.Items.Count - 1 < 0)
            {
                MessageBox.Show("Select Room");
            }else
            {
                MessageBox.Show("Save");
            }
        }
    }
}
