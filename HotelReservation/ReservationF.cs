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
    public partial class ReservationF : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        public ReservationF()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void ReservationF_Load(object sender, EventArgs e)
        {
            Mycon.con.Close();
            Mycon.con.Open();
            loadres();
        }

        public void loadres()
        {
            listView1.Items.Clear();

            if (search_box.Text == "")
            {
                Com.CommandText = "select reservation.*,customer.full_name,(select count(id) from room_res where reservation.id = room_res.res_id) as r from  reservation left join customer on customer.id = reservation.customer_id";
            }
            else
            {
                Com.CommandText = "select reservation.*,customer.full_name,(select count(id) from room_res where reservation.id = room_res.res_id) as r from  reservation left join customer on customer.id = reservation.customer_id where customer.full_name like '" + search_box.Text + "%' ";
                
            }

            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                string name = (reader["full_name"].ToString() == "") ? "N/A" : reader["full_name"].ToString();
                ListViewItem list = new ListViewItem(name.ToString());
                list.SubItems.Add(reader["r"].ToString());
                list.SubItems.Add(reader["adult"].ToString());
                list.SubItems.Add(reader["child"].ToString());
                list.SubItems.Add(reader["chcek_in"].ToString());
                list.SubItems.Add(reader["check_out"].ToString());
                list.SubItems.Add(reader["total"].ToString());
                list.SubItems.Add(reader["r_date"].ToString());
                listView1.Items.AddRange(new ListViewItem[] { list });
            }
            reader.Close();
            Com.Dispose();
        }

        private void search_Click(object sender, EventArgs e)
        {
            loadres();
        }
    }
}
