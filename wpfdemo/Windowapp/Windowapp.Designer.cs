namespace Windowapp
{
    partial class Windowapp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.altitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pdop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hdop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vdop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GPSused = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GLOused = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSVused = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Eleivation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Azimuth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.more = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Time,
            this.Address,
            this.longitude,
            this.altitude,
            this.quality,
            this.pdop,
            this.hdop,
            this.vdop,
            this.GPS,
            this.GPSused,
            this.GLO,
            this.GLOused,
            this.totalSV,
            this.totalSVused,
            this.PRN,
            this.Eleivation,
            this.Azimuth,
            this.SNR,
            this.more});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 158);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(985, 256);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Location = new System.Drawing.Point(106, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "no file attached";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(22, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Upload a file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(22, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Output";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            this.label2.UseWaitCursor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(834, 142);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(151, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "For more information click here";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 129);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(710, 129);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(92, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "Export To Excel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(605, 129);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Export To Text";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Time
            // 
            this.Time.DataPropertyName = "Time";
            this.Time.HeaderText = "Time";
            this.Time.Name = "Time";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "latitude";
            this.Address.HeaderText = "Latitude";
            this.Address.Name = "Address";
            // 
            // longitude
            // 
            this.longitude.DataPropertyName = "longitude";
            this.longitude.HeaderText = "Longitude";
            this.longitude.Name = "longitude";
            // 
            // altitude
            // 
            this.altitude.DataPropertyName = "altitude";
            this.altitude.HeaderText = "Altitude";
            this.altitude.Name = "altitude";
            // 
            // quality
            // 
            this.quality.DataPropertyName = "quality";
            this.quality.HeaderText = "Quality";
            this.quality.Name = "quality";
            this.quality.ToolTipText = "0-invalid, 1-fix";
            // 
            // pdop
            // 
            this.pdop.DataPropertyName = "pdop";
            this.pdop.HeaderText = "pdop";
            this.pdop.Name = "pdop";
            // 
            // hdop
            // 
            this.hdop.DataPropertyName = "hdop";
            this.hdop.HeaderText = "hdop";
            this.hdop.Name = "hdop";
            // 
            // vdop
            // 
            this.vdop.DataPropertyName = "vdop";
            this.vdop.HeaderText = "vdop";
            this.vdop.Name = "vdop";
            // 
            // GPS
            // 
            this.GPS.DataPropertyName = "GPS";
            this.GPS.HeaderText = "GPS(Visible)";
            this.GPS.Name = "GPS";
            // 
            // GPSused
            // 
            this.GPSused.DataPropertyName = "GPSused";
            this.GPSused.HeaderText = "GPS(used)";
            this.GPSused.Name = "GPSused";
            // 
            // GLO
            // 
            this.GLO.DataPropertyName = "GLO";
            this.GLO.HeaderText = "GLO(visible)";
            this.GLO.Name = "GLO";
            // 
            // GLOused
            // 
            this.GLOused.DataPropertyName = "GLOused";
            this.GLOused.HeaderText = "GLO(used)";
            this.GLOused.Name = "GLOused";
            // 
            // totalSV
            // 
            this.totalSV.DataPropertyName = "totalSV";
            this.totalSV.HeaderText = "Total SV visible";
            this.totalSV.Name = "totalSV";
            // 
            // totalSVused
            // 
            this.totalSVused.DataPropertyName = "totalSVused";
            this.totalSVused.HeaderText = "Total SV used";
            this.totalSVused.Name = "totalSVused";
            // 
            // PRN
            // 
            this.PRN.HeaderText = "PRN";
            this.PRN.Name = "PRN";
            this.PRN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PRN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Eleivation
            // 
            this.Eleivation.HeaderText = "Eleivation";
            this.Eleivation.Name = "Eleivation";
            this.Eleivation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Eleivation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Azimuth
            // 
            this.Azimuth.HeaderText = "Azimuth";
            this.Azimuth.Name = "Azimuth";
            this.Azimuth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Azimuth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SNR
            // 
            this.SNR.HeaderText = "SNR";
            this.SNR.Name = "SNR";
            this.SNR.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SNR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // more
            // 
            this.more.DataPropertyName = "more";
            this.more.HeaderText = "More";
            this.more.Name = "more";
            // 
            // Windowapp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(985, 414);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkBlue;
            this.Name = "Windowapp";
            this.Text = "SumanDepannita";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn altitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn quality;
        private System.Windows.Forms.DataGridViewTextBoxColumn pdop;
        private System.Windows.Forms.DataGridViewTextBoxColumn hdop;
        private System.Windows.Forms.DataGridViewTextBoxColumn vdop;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPS;
        private System.Windows.Forms.DataGridViewTextBoxColumn GPSused;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLO;
        private System.Windows.Forms.DataGridViewTextBoxColumn GLOused;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSVused;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Eleivation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Azimuth;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn more;
    }
}

