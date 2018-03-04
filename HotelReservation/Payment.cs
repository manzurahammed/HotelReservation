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
    public partial class Payment : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        public Payment()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Payment_Load(object sender, EventArgs e)
        {
            Mycon.con.Close();
            Mycon.con.Open();
            customerlist();
            customer_list.SelectedIndex = 0;
            loadUserList();

        }

        public void customerlist()
        {
            customer_list.Items.Clear();
            Com.CommandText = "SELECT id,full_name,due FROM customer where due>0";
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

        private void customer_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customer_list.SelectedIndex > 0)
            {
                string duea = "0";
                string cus_id = ((customer_list.SelectedItem as ComboboxItem).Value.ToString());
                Com.CommandText = "SELECT due FROM customer where id="+cus_id;
                reader = Com.ExecuteReader();
                while (reader.Read())
                {
                    duea = reader["due"].ToString();
                }
                due.Text = duea;
                reader.Close();
            }
            else
            {
                due.Text = "0.0";
            }
        }

        private void pay_Click(object sender, EventArgs e)
        {
            if(customer_list.SelectedIndex < 1)
            {
                MessageBox.Show("Select Customer");
            }else if(paid.Text=="")
            {
                MessageBox.Show("Enter A Payment Value");
            }else
            {
                string cus_id = ((customer_list.SelectedItem as ComboboxItem).Value.ToString());
                float ti, pi;
                float.TryParse(paid.Text, out pi);
                float.TryParse(due.Text, out ti);
                float p = (ti <= pi) ? 0 : ti - pi;
                Com.CommandText = "UPDATE customer set due = "+p+" where id="+ cus_id;
                Com.ExecuteNonQuery();
                Com.CommandText = "Insert into payment(cu_id,amount) Values('" + cus_id + "','" + pi + "')";
                Com.ExecuteNonQuery();
                Com.Dispose();
                MessageBox.Show("Transaction SuccessFully Complete");
                reset();
            }
        }

        public void reset()
        {
            customerlist();
            due.Text = "0.0";
            paid.Text = "";
            customer_list.SelectedIndex = 0;
            loadUserList();
        }

        void loadUserList()
        {
            listView1.Items.Clear();
            
            Com.CommandText = "SELECT amount,p_date,customer.full_name FROM payment left join customer on customer.id = cu_id  order by p_date desc";
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                string name = (reader["full_name"].ToString() == "") ? "N/A" : reader["full_name"].ToString();
                ListViewItem list = new ListViewItem(name.ToString());
                list.SubItems.Add(reader["amount"].ToString());
                list.SubItems.Add(reader["p_date"].ToString());
                listView1.Items.AddRange(new ListViewItem[] { list });
            }
            reader.Close();
            Com.Dispose();
        }
    }
}
