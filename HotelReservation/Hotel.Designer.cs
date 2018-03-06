namespace HotelReservation
{
    partial class Hotel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.custoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalcu = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.totaldue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.totalp = new System.Windows.Forms.Label();
            this.totalr = new System.Windows.Forms.Label();
            this.refresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.custoToolStripMenuItem,
            this.roomToolStripMenuItem,
            this.reservationToolStripMenuItem,
            this.paymentToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1152, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 19);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // custoToolStripMenuItem
            // 
            this.custoToolStripMenuItem.Name = "custoToolStripMenuItem";
            this.custoToolStripMenuItem.Size = new System.Drawing.Size(71, 19);
            this.custoToolStripMenuItem.Text = "Customer";
            this.custoToolStripMenuItem.Click += new System.EventHandler(this.custoToolStripMenuItem_Click);
            // 
            // roomToolStripMenuItem
            // 
            this.roomToolStripMenuItem.Name = "roomToolStripMenuItem";
            this.roomToolStripMenuItem.Size = new System.Drawing.Size(51, 19);
            this.roomToolStripMenuItem.Text = "Room";
            this.roomToolStripMenuItem.Click += new System.EventHandler(this.roomToolStripMenuItem_Click);
            // 
            // reservationToolStripMenuItem
            // 
            this.reservationToolStripMenuItem.Name = "reservationToolStripMenuItem";
            this.reservationToolStripMenuItem.Size = new System.Drawing.Size(80, 19);
            this.reservationToolStripMenuItem.Text = "Reservation";
            this.reservationToolStripMenuItem.Click += new System.EventHandler(this.reservationToolStripMenuItem_Click);
            // 
            // paymentToolStripMenuItem
            // 
            this.paymentToolStripMenuItem.Name = "paymentToolStripMenuItem";
            this.paymentToolStripMenuItem.Size = new System.Drawing.Size(66, 19);
            this.paymentToolStripMenuItem.Text = "Payment";
            this.paymentToolStripMenuItem.Click += new System.EventHandler(this.paymentToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservationToolStripMenuItem1,
            this.paymentToolStripMenuItem1});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 19);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // reservationToolStripMenuItem1
            // 
            this.reservationToolStripMenuItem1.Name = "reservationToolStripMenuItem1";
            this.reservationToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.reservationToolStripMenuItem1.Text = "Reservation";
            this.reservationToolStripMenuItem1.Click += new System.EventHandler(this.reservationToolStripMenuItem1_Click);
            // 
            // paymentToolStripMenuItem1
            // 
            this.paymentToolStripMenuItem1.Name = "paymentToolStripMenuItem1";
            this.paymentToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.paymentToolStripMenuItem1.Text = "Payment";
            this.paymentToolStripMenuItem1.Click += new System.EventHandler(this.paymentToolStripMenuItem1_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 19);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // totalcu
            // 
            this.totalcu.AutoSize = true;
            this.totalcu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalcu.ForeColor = System.Drawing.Color.White;
            this.totalcu.Location = new System.Drawing.Point(70, 49);
            this.totalcu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalcu.Name = "totalcu";
            this.totalcu.Size = new System.Drawing.Size(31, 20);
            this.totalcu.TabIndex = 2;
            this.totalcu.Text = "0.0";
            this.totalcu.Click += new System.EventHandler(this.totalcu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(50, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Total Due";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // totaldue
            // 
            this.totaldue.AutoSize = true;
            this.totaldue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totaldue.ForeColor = System.Drawing.Color.White;
            this.totaldue.Location = new System.Drawing.Point(70, 54);
            this.totaldue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totaldue.Name = "totaldue";
            this.totaldue.Size = new System.Drawing.Size(31, 20);
            this.totaldue.TabIndex = 4;
            this.totaldue.Text = "0.0";
            this.totaldue.Click += new System.EventHandler(this.totaldue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Total Customer";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Total Payment Today";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(4, 13);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Room Reservation Today";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // totalp
            // 
            this.totalp.AutoSize = true;
            this.totalp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalp.ForeColor = System.Drawing.Color.White;
            this.totalp.Location = new System.Drawing.Point(72, 49);
            this.totalp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalp.Name = "totalp";
            this.totalp.Size = new System.Drawing.Size(31, 20);
            this.totalp.TabIndex = 2;
            this.totalp.Text = "0.0";
            this.totalp.Click += new System.EventHandler(this.totalp_Click);
            // 
            // totalr
            // 
            this.totalr.AutoSize = true;
            this.totalr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalr.ForeColor = System.Drawing.Color.White;
            this.totalr.Location = new System.Drawing.Point(85, 54);
            this.totalr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.totalr.Name = "totalr";
            this.totalr.Size = new System.Drawing.Size(18, 20);
            this.totalr.TabIndex = 2;
            this.totalr.Text = "0";
            this.totalr.Click += new System.EventHandler(this.totalr_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(769, 79);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(97, 46);
            this.refresh.TabIndex = 5;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.totalcu);
            this.panel1.Location = new System.Drawing.Point(120, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.totalp);
            this.panel2.Location = new System.Drawing.Point(484, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.totaldue);
            this.panel3.Location = new System.Drawing.Point(120, 233);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.GrayText;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.totalr);
            this.panel4.Location = new System.Drawing.Point(484, 233);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1152, 515);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Hotel";
            this.Text = "Hotel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Hotel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem custoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem paymentToolStripMenuItem1;
        private System.Windows.Forms.Label totalcu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label totaldue;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label totalp;
        private System.Windows.Forms.Label totalr;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Timer timer1;
    }
}