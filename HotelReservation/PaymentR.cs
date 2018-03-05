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
    public partial class PaymentR : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        public PaymentR()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void searchb_Click(object sender, EventArgs e)
        {
            loadUserList();
        }

        private void PaymentR_Load(object sender, EventArgs e)
        {
            Mycon.con.Close();
            Mycon.con.Open();
            loadUserList();
        }

        void loadUserList()
        {
            listView1.Items.Clear();
            if (search.Text=="")
            {
                Com.CommandText = "SELECT amount,p_date,customer.full_name FROM payment left join customer on customer.id = cu_id  order by p_date desc";
            }
            else
            {
                Com.CommandText = "SELECT amount,p_date,customer.full_name FROM payment left join customer on customer.id = cu_id where customer.full_name='"+ search.Text+ "' order by p_date desc";
            }
            
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
