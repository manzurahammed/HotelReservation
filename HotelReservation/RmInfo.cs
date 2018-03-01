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
    public partial class RmInfo : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        string id;
        public RmInfo(string id)
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
            this.id = id;
            
        }

        private void RmInfo_Load(object sender, EventArgs e)
        {
            Mycon.con.Close();
            Mycon.con.Open();
            loadFormInfoData(this.id);
        }

        void loadFormInfoData(string id)
        {
            
            Com.CommandText = "SELECT * FROM room WHERE id = '" + id + "'";
            reader = Com.ExecuteReader();
            while (reader.Read())
            {

                room_num.Text = reader["room_number"].ToString();
                room_price.Text = reader["price"].ToString();
                room_rf.Text = (reader["rf"].ToString() == "1") ? "YES" : "NO";
                room_ac.Text = (reader["ac"].ToString() == "1") ? "YES" : "NO";
                room_bed.Text = getbed(reader["bed"].ToString());
                room_tv.Text = (reader["tv"].ToString()=="1")?"YES":"NO";

            }
            reader.Close();
        }

        public string getbed(string id)
        {
            string name;
            if (id == "1")
            {
                name = "Single Bed";
            }
            else
            {
                name = "Dubble Bed";
            }
            return name;
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
