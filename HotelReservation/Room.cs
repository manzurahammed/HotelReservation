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
    public partial class Room : Form
    {
        MySqlCommand Com = new MySqlCommand();
        MySqlDataReader reader;
        string Sstatus;
        public Room()
        {
            InitializeComponent();
            Com.Connection = Mycon.con;
        }

        private void save_Click(object sender, EventArgs e)
        {
            validation();
            roombookc();
        }

        public void roombookc()
        {
            DateTime today = DateTime.Today;
            Com.CommandText = "update room set book = 0 where room_number in (select room_number from room_res where check_out <= '" + today.ToString("yyyy-MM-dd") + "')";
            Com.ExecuteNonQuery();
            Com.Dispose();
        }

        bool existRoomNumber(string room_number)
        {
            if (Sstatus == "edit")
            {
                int a = listView1.SelectedIndices[0];
                string id = listView1.Items[a].Text;
                Com.CommandText = "SELECT id FROM room WHERE room_number= '" + room_number + "' and id != '" + id + "'";
            }
            else
            {
                Com.CommandText = "SELECT id FROM room WHERE room_number= '" + room_number + "'";
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

        public void validation()
        {

            if (room_number.Text == "")
            {
                MessageBox.Show("Room Number is Required");
            }
            else if (bed.SelectedIndex < 1)
            {
                MessageBox.Show("Select a Bed");
            }

            else if (quality.SelectedIndex < 1)
            {
                MessageBox.Show("Select a Room Quality");
            }

            else if (floor.SelectedIndex < 1)
            {
                MessageBox.Show("Select a Floor");
            }
            else if (existRoomNumber(room_number.Text))
            {
                MessageBox.Show("Room Number Already Exist");
            }
            else if (price.Text == "")
            {
                MessageBox.Show("Room Price is Required");
            }
            else
            {
                
                int acv = (ac.Checked) ? 1 : 0;
                int tvv = (tv.Checked) ? 1 : 0;
                int rfv = (rf.Checked) ? 1 : 0;
                if (Sstatus == "save")
                {
                    Com.CommandText = "Insert into room(room_number,floor,bed,quality,ac,tv,rf,price) Values('" + room_number.Text + "','" + floor.SelectedIndex + "','" + bed.SelectedIndex + "','" + quality.SelectedIndex + "','" + acv + "','" + tvv + "','" + rfv + "','" + price.Text + "')";
                    Com.ExecuteNonQuery();
                    Com.Dispose();
                    MessageBox.Show("New Romm Addedd SuccessFUlly");
                    reset();
                }
                else if (Sstatus == "edit")
                {
                    int a = listView1.SelectedIndices[0];
                    string id = listView1.Items[a].Text;
                    
                    Com.CommandText = "Update room set room_number='" + room_number.Text +
                                "',price ='" + price.Text +
                                "',ac ='" + acv +
                                "',tv ='" + tvv +
                                "',rf ='" + rfv +
                                "',bed ='" + bed.SelectedIndex + 
                                "',quality ='" + quality.SelectedIndex +
                                "',floor ='" + floor.SelectedIndex + "' Where id='" + id + "'";
                    Com.ExecuteNonQuery();
                    Com.Dispose();
                    reset();
                    Sstatus = "save";
                    MessageBox.Show("Update Room Info");

                }
                loadRoomList();
            }
        }

        private void Room_Load(object sender, EventArgs e)
        {
            
            Sstatus = "save";
            Mycon.con.Close();
            Mycon.con.Open();
            roombookc();
            loadRoomList();
            bedlist();
            floorList();
            qualitylist();
            bed.SelectedIndex = 0;
            quality.SelectedIndex = 0;
            floor.SelectedIndex = 0;
        }

        void loadRoomList()
        {
            listView1.Items.Clear();
            if (search_text.Text == "")
            {
                Com.CommandText = "SELECT * FROM room ORDER BY id ASC";
            }
            else
            {
                Com.CommandText = "SELECT * FROM room where room_number like '" + search_text.Text + "%' ORDER BY id ASC";
            }
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                ListViewItem list = new ListViewItem(reader["id"].ToString());
                string booked = (reader["book"].ToString() == "1") ? "YES" : "NO";
                list.SubItems.Add(reader["room_number"].ToString());
                list.SubItems.Add(getbed(reader["bed"].ToString()));
                list.SubItems.Add(getquality(reader["quality"].ToString()));
                list.SubItems.Add(getfloor(reader["floor"].ToString()));
                list.SubItems.Add(reader["price"].ToString());
                list.SubItems.Add(booked);
                listView1.Items.AddRange(new ListViewItem[] { list });
            }
            reader.Close();
            Com.Dispose();
        }

        public void bedlist()
        {
            bed.Items.Insert(0, "< Select Bed >");
            bed.Items.Insert(1, "Single Bed");
            bed.Items.Insert(2, "Dubble Bed");

        }

        public void qualitylist()
        {
            quality.Items.Insert(0, "< Select Room Quality >");
            quality.Items.Insert(1, "Low");
            quality.Items.Insert(2, "High");

        }

        public void floorList()
        {
            floor.Items.Insert(0, "< Select Floor >");
            floor.Items.Insert(1, "Floor 1");
            floor.Items.Insert(2, "Floor 2");

        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
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

        public void reset()
        {
            room_number.Text = price.Text =  "";
            ac.Checked = tv.Checked = rf.Checked =  false;
            floor.SelectedIndex =  bed.SelectedIndex =  quality.SelectedIndex = 0;
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

        public string getfloor(string id)
        {
            string name;
            if (id == "1")
            {
                name = "Floor 1";
            }
            else
            {
                name = "Floor 2";
            }
            return name;
        }


        public string getquality(string id)
        {
            string name;
            if (id == "1")
            {
                name = "Low";
            }
            else
            {
                name = "High";
            }
            return name;
        }

        private void res_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void search_Click(object sender, EventArgs e)
        {
            loadRoomList();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            int a = listView1.SelectedIndices[0];
            string id = listView1.Items[a].Text;
            Com.CommandText = "SELECT * FROM room WHERE id = '" + id + "'";
            reader = Com.ExecuteReader();
            while (reader.Read())
            {
                room_number.Text = reader["room_number"].ToString();
                price.Text = reader["price"].ToString();
                bed.SelectedIndex = reader.GetInt32("bed");
                ac.Checked = (reader.GetInt32("ac") == 1) ? true : false;
                tv.Checked = (reader.GetInt32("tv") == 1) ? true : false;
                rf.Checked = (reader.GetInt32("rf") == 1) ? true : false;
                quality.SelectedIndex = reader.GetInt32("quality");
                floor.SelectedIndex = reader.GetInt32("floor");
            }
            reader.Close();
            Sstatus = "edit";
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int a = listView1.SelectedIndices[0];
            string id = listView1.Items[a].Text;
            RmInfo rminfo = new RmInfo(id);
            rminfo.Show();
        }
    }
}
