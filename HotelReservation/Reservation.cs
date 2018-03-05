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
            roombookc();
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
            room_list.Items.Clear();
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
                        int indexx = listView1.Items.Count;
                        ListViewItem list = new ListViewItem(reader["id"].ToString());
                        list.SubItems.Add(reader["room_number"].ToString());
                        list.SubItems.Add(reader["price"].ToString());
                        listView1.Items.AddRange(new ListViewItem[] { list });
                        string t = total.Text;
                        float value;
                        float.TryParse(t, out value);
                        value = value + (reader.GetFloat("price") * getday());
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
            for (int i = listView1.Items.Count-1; i >= 0; i--)

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
                
               
                if (check_in.Value.Date >= check_out.Value.Date)
                {
                    MessageBox.Show("Check Out Time is To earlier");
                }else
                {
                    string cus_id = ((customer_list.SelectedItem as ComboboxItem).Value.ToString());
                    string child = (textBox3.Text != "") ? textBox3.Text : "0";
                    string adult = (textBox2.Text != "") ? textBox2.Text : "1";
                    string totalp = (textBox1.Text != "") ? textBox1.Text : "0"; ;
                    string chcekin = check_in.Value.ToString("yyyy-MM-dd");
                    string chcekout = check_out.Value.ToString("yyyy-MM-dd");
                    float ti, pi;
                    float.TryParse(total.Text, out ti);
                    float.TryParse(totalp, out pi);
                    float due = (ti <= pi)?0: ti-pi;
                    Com.CommandText = "Insert into reservation(customer_id,chcek_in,check_out,adult,child,total) Values('" + cus_id + "','" + chcekin + "','" + chcekout + "','" + adult + "','" + child + "','" + total.Text + "')";
                    int lastiInId = Com.ExecuteNonQuery();
                    if (pi>0)
                    {
                        Com.CommandText = "Insert into payment(cu_id,amount) Values('" + cus_id + "','" + totalp + "')";
                        Com.ExecuteNonQuery();
                    }
                    Com.CommandText = " UPDATE customer t2,( SELECT due FROM customer where id = "+ cus_id + " ) t1 SET t2.due = "+ due + "+t1.due WHERE t2.id = " +cus_id;
                    Com.ExecuteNonQuery();
                    Com.Dispose();
                    BulkToMySQL(lastiInId, chcekout);
                    bupdate();
                    roombookc();
                    roomlist();
                    reset();
                    MessageBox.Show("Room Book Successfully");
                }

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void test()
        {
            foreach (ListViewItem itemRow in this.listView1.Items)
            {
                MessageBox.Show((itemRow.SubItems[1]).ToString());
            }
        }

        public void reset()
        {
            listView1.Items.Clear();
            textBox1.Text = textBox2.Text = textBox3.Text = "";
            due.Text = total.Text = "0.0";
            customer_list.SelectedIndex = room_list.SelectedIndex = 0;
        }

        public void BulkToMySQL(int lid,string chout)
        {
            string ConnectionString = "server=localhost; uid=root; password=; database=hotel";
            StringBuilder sCommand = new StringBuilder("INSERT INTO room_res (res_id, room_number,check_out,price) VALUES ");
            using (MySqlConnection mConnection = new MySqlConnection(ConnectionString))
            {
                List<string> Rows = new List<string>();
                foreach (ListViewItem itemRow in this.listView1.Items)
                {
                    Rows.Add(string.Format("('{0}','{1}','{2}','{3}')", MySqlHelper.EscapeString(lid.ToString()), MySqlHelper.EscapeString(itemRow.SubItems[1].Text), MySqlHelper.EscapeString(chout), MySqlHelper.EscapeString(itemRow.SubItems[2].Text)));
                }

                sCommand.Append(string.Join(",", Rows));
                sCommand.Append(";");
                mConnection.Open();
                using (MySqlCommand myCmd = new MySqlCommand(sCommand.ToString(), mConnection))
                {
                    myCmd.CommandType = CommandType.Text;
                    myCmd.ExecuteNonQuery();
                    mConnection.Dispose();
                }
            }
        }

        public void bupdate()
        {
            string qs = "";
            
            foreach (ListViewItem itemRow in this.listView1.Items)
            {
                qs += itemRow.SubItems[0].Text+",";
            }
            qs = qs.TrimEnd(',');
            Com.CommandText = "Update room set book = 1 Where id in ( " + qs + " )";
            Com.ExecuteNonQuery();
            Com.Dispose();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public void roombookc()
        {
            DateTime today = DateTime.Today;
            Com.CommandText = "update room set book = 0 where room_number in (select room_number from room_res where check_out <= '"+ today.ToString("yyyy-MM-dd") + "')";
            Com.ExecuteNonQuery();
            Com.Dispose();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            keycheck(sender, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            keycheck(sender, e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            keycheck(sender,e);
        }

        public void keycheck(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void listView1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var confirmation = MessageBox.Show("Sure to Delete Room From List", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    for (int i = listView1.SelectedItems.Count - 1; i >= 0; i--)
                    {
                        ListViewItem itm = listView1.SelectedItems[i];
                        string price = itm.SubItems[2].Text;
                        string t = total.Text;
                        float value,pr;
                        float.TryParse(t, out value);
                        float.TryParse(price, out pr);
                        value = value- (pr * getday() );
                        total.Text = value.ToString();
                        listView1.Items[itm.Index].Remove();
                    }
                }
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "")
            {
                string t = total.Text;
                float value, pr;
                float.TryParse(t, out value);
                float.TryParse(textBox1.Text.ToString(), out pr);
                if (value < pr)
                {
                    due.Text = "0.0";
                }else{
                    value = value - pr;
                    due.Text = value.ToString();
                }
            }else
            {
                due.Text = "0.0";
            }
        }

        public int getday()
        {
            DateTime febDate = new DateTime(2014, 2, 20);
            DateTime checkin = check_in.Value;
            DateTime checkout = check_out.Value;
            TimeSpan tspan = checkout - checkin;
            int differenceInDays = tspan.Days;
            if (differenceInDays>0)
            {
                return differenceInDays+1;
            }else
            {
                return 1;
            }
        }

        private void check_out_ValueChanged(object sender, EventArgs e)
        {
            if (getTotalPrice()>0)
            {
                float a = getday() * getTotalPrice();
                total.Text = a.ToString();
            }
        }

        
        public float getTotalPrice()
        {
            float total = 0;
            if (listView1.Items.Count > 0)
            {
                foreach (ListViewItem itemRow in this.listView1.Items)
                {
                    float single = 0;
                    float.TryParse(itemRow.SubItems[2].Text, out single);
                    total += single;
                }
            }
            return total;
        }

        private void check_in_ValueChanged(object sender, EventArgs e)
        {
            if (getTotalPrice() > 0)
            {
                float a = getday() * getTotalPrice();
                total.Text = a.ToString();
            }
        }
    }
}
