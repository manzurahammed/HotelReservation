﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class Hotel : Form
    {
        public Hotel()
        {
            InitializeComponent();
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
    }
}
