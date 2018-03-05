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
    public partial class Hotel : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        public Hotel()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User us = new User();
            us.Show();
        }

        private void custoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer cs = new Customer();
            cs.Show();
        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Room room = new Room();
            room.Show();
        }

        private void reservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reservation res = new Reservation();
            res.Show();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Hide();
            fr.Show();
        }

        private void reservationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReservationF resf = new ReservationF();
            resf.Show();
        }

        private void Hotel_Load(object sender, EventArgs e)
        {
            Mycon.con.Close();
            Mycon.con.Open();
            loadTotalDue();
            loadCustomer();
            loadtotalrestoday();
            loadpaymenttoday();
        }

        public void loadTotalDue()
        {
            string total = "0.0";
            Com.CommandText = "select sum(due) as total from customer";
            reader = Com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    total = reader["total"].ToString();
                }
                totaldue.Text = total;
            }
            reader.Close();
            Com.Dispose();
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
            Com.CommandText = "select count(id) as total from reservation where CAST(r_date AS DATE) = '"+today.ToString("yyyy-MM-dd") +"'";
           
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

        public void loadpaymenttoday()
        {
            string total = "0.0";
            DateTime today = DateTime.Today;
            Com.CommandText = "select sum(amount) as total from payment where CAST(p_date AS DATE) = '"+ today.ToString("yyyy-MM-dd") + "'";
            reader = Com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    total = reader["total"].ToString();
                }
                totalp.Text = total;
            }
            reader.Close();
            Com.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void totalcu_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void totaldue_Click(object sender, EventArgs e)
        {

        }

        private void totalp_Click(object sender, EventArgs e)
        {

        }

        private void totalr_Click(object sender, EventArgs e)
        {

        }

        private void refresh_Click(object sender, EventArgs e)
        {
            loadTotalDue();
            loadCustomer();
            loadtotalrestoday();
            loadpaymenttoday();
        }
    }
}
