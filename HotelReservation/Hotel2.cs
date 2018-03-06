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
    public partial class Hotel2 : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        public Hotel2()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void Hotel2_Load(object sender, EventArgs e)
        {
            Mycon.con.Close();
            Mycon.con.Open();
            loadCustomer();
            loadtotalrestoday();
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReservationF resf = new ReservationF();
            resf.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentR payr = new PaymentR();
            payr.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Hide();
            fr.Show();
        }

        public void loadCustomer()
        {
            string total = "0";
            Com.CommandText = "select count(id) as total from customer";
            reader = Com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    total = reader["total"].ToString();
                }
                totalcu.Text = total;
            }
            reader.Close();
            Com.Dispose();
        }

        public void loadtotalrestoday()
        {
            string total = "0";
            DateTime today = DateTime.Today;
            Com.CommandText = "select count(id) as total from reservation where CAST(r_date AS DATE) = '" + today.ToString("yyyy-MM-dd") + "'";

            reader = Com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    total = reader["total"].ToString();
                }
                totalr.Text = total;
            }
            reader.Close();
            Com.Dispose();
        }
    }
}
