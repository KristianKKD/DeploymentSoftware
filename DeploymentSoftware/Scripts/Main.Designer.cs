namespace DeploymentSoftware
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel2 = new System.Windows.Forms.Panel();
            this.cB_Port = new System.Windows.Forms.ComboBox();
            this.l_Connected = new System.Windows.Forms.Label();
            this.b_Connect = new System.Windows.Forms.Button();
            this.tB_IP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.p_Control = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.slider_Zoom = new System.Windows.Forms.TrackBar();
            this.b_DDEOff = new System.Windows.Forms.Button();
            this.b_DDEOn = new System.Windows.Forms.Button();
            this.tB_DDE = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.slider_DDE = new System.Windows.Forms.TrackBar();
            this.tB_Brightness = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.slider_Brightness = new System.Windows.Forms.TrackBar();
            this.tB_Contrast = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.slider_Contrast = new System.Windows.Forms.TrackBar();
            this.cB_AGC = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cB_Flip = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cB_Palette = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.b_Play = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p_Extended = new System.Windows.Forms.Panel();
            this.tB_Extend_Port = new System.Windows.Forms.TextBox();
            this.tB_Extend_RTSP = new System.Windows.Forms.TextBox();
            this.tB_Extend_Password = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tB_Extend_IP = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tB_Extend_Username = new System.Windows.Forms.TextBox();
            this.p_Basic = new System.Windows.Forms.Panel();
            this.tB_Basic_RTSP = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.check_Extend = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.VLCPlayer = new AxAXVLC.AxVLCPlugin2();
            this.tB_Zoom = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.p_Control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Zoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_DDE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Brightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.p_Extended.SuspendLayout();
            this.p_Basic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cB_Port);
            this.panel2.Controls.Add(this.l_Connected);
            this.panel2.Controls.Add(this.b_Connect);
            this.panel2.Controls.Add(this.tB_IP);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 130);
            this.panel2.TabIndex = 1;
            // 
            // cB_Port
            // 
            this.cB_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cB_Port.FormattingEnabled = true;
            this.cB_Port.Items.AddRange(new object[] {
            "4001",
            "6791"});
            this.cB_Port.Location = new System.Drawing.Point(95, 59);
            this.cB_Port.Name = "cB_Port";
            this.cB_Port.Size = new System.Drawing.Size(220, 28);
            this.cB_Port.TabIndex = 7;
            this.cB_Port.Text = "6791";
            // 
            // l_Connected
            // 
            this.l_Connected.AutoSize = true;
            this.l_Connected.Location = new System.Drawing.Point(234, 9);
            this.l_Connected.Name = "l_Connected";
            this.l_Connected.Size = new System.Drawing.Size(79, 13);
            this.l_Connected.TabIndex = 6;
            this.l_Connected.Text = "Not Connected";
            // 
            // b_Connect
            // 
            this.b_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Connect.Location = new System.Drawing.Point(94, 92);
            this.b_Connect.Name = "b_Connect";
            this.b_Connect.Size = new System.Drawing.Size(219, 30);
            this.b_Connect.TabIndex = 5;
            this.b_Connect.Text = "CONNECT";
            this.b_Connect.UseVisualStyleBackColor = true;
            this.b_Connect.Click += new System.EventHandler(this.b_Connect_Click);
            // 
            // tB_IP
            // 
            this.tB_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_IP.Location = new System.Drawing.Point(96, 28);
            this.tB_IP.Name = "tB_IP";
            this.tB_IP.Size = new System.Drawing.Size(219, 26);
            this.tB_IP.TabIndex = 3;
            this.tB_IP.Text = "192.168.1.74";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Camera Info";
            // 
            // p_Control
            // 
            this.p_Control.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_Control.Controls.Add(this.tB_Zoom);
            this.p_Control.Controls.Add(this.label19);
            this.p_Control.Controls.Add(this.slider_Zoom);
            this.p_Control.Controls.Add(this.b_DDEOff);
            this.p_Control.Controls.Add(this.b_DDEOn);
            this.p_Control.Controls.Add(this.tB_DDE);
            this.p_Control.Controls.Add(this.label18);
            this.p_Control.Controls.Add(this.slider_DDE);
            this.p_Control.Controls.Add(this.tB_Brightness);
            this.p_Control.Controls.Add(this.label17);
            this.p_Control.Controls.Add(this.slider_Brightness);
            this.p_Control.Controls.Add(this.tB_Contrast);
            this.p_Control.Controls.Add(this.label16);
            this.p_Control.Controls.Add(this.slider_Contrast);
            this.p_Control.Controls.Add(this.cB_AGC);
            this.p_Control.Controls.Add(this.label15);
            this.p_Control.Controls.Add(this.label7);
            this.p_Control.Controls.Add(this.cB_Flip);
            this.p_Control.Controls.Add(this.label6);
            this.p_Control.Controls.Add(this.cB_Palette);
            this.p_Control.Controls.Add(this.label5);
            this.p_Control.Enabled = false;
            this.p_Control.Location = new System.Drawing.Point(12, 226);
            this.p_Control.Name = "p_Control";
            this.p_Control.Size = new System.Drawing.Size(328, 314);
            this.p_Control.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(7, 122);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 18);
            this.label19.TabIndex = 31;
            this.label19.Text = "Digital Zoom:";
            // 
            // slider_Zoom
            // 
            this.slider_Zoom.Location = new System.Drawing.Point(170, 122);
            this.slider_Zoom.Maximum = 16;
            this.slider_Zoom.Minimum = 2;
            this.slider_Zoom.Name = "slider_Zoom";
            this.slider_Zoom.Size = new System.Drawing.Size(145, 45);
            this.slider_Zoom.TabIndex = 30;
            this.slider_Zoom.TickFrequency = 2;
            this.slider_Zoom.Value = 2;
            this.slider_Zoom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_Zoom_MouseUp);
            // 
            // b_DDEOff
            // 
            this.b_DDEOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_DDEOff.Location = new System.Drawing.Point(7, 268);
            this.b_DDEOff.Name = "b_DDEOff";
            this.b_DDEOff.Size = new System.Drawing.Size(149, 30);
            this.b_DDEOff.TabIndex = 13;
            this.b_DDEOff.Text = "DDE Off";
            this.b_DDEOff.UseVisualStyleBackColor = true;
            this.b_DDEOff.Click += new System.EventHandler(this.b_DDEOff_Click);
            // 
            // b_DDEOn
            // 
            this.b_DDEOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_DDEOn.Location = new System.Drawing.Point(166, 268);
            this.b_DDEOn.Name = "b_DDEOn";
            this.b_DDEOn.Size = new System.Drawing.Size(149, 30);
            this.b_DDEOn.TabIndex = 12;
            this.b_DDEOn.Text = "DDE On";
            this.b_DDEOn.UseVisualStyleBackColor = true;
            this.b_DDEOn.Click += new System.EventHandler(this.b_DDEOn_Click);
            // 
            // tB_DDE
            // 
            this.tB_DDE.Location = new System.Drawing.Point(115, 228);
            this.tB_DDE.Name = "tB_DDE";
            this.tB_DDE.Size = new System.Drawing.Size(49, 20);
            this.tB_DDE.TabIndex = 29;
            this.tB_DDE.TextChanged += new System.EventHandler(this.tB_DDE_TextChanged);
            this.tB_DDE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_DDE_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(7, 230);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(40, 18);
            this.label18.TabIndex = 28;
            this.label18.Text = "DDE";
            // 
            // slider_DDE
            // 
            this.slider_DDE.Location = new System.Drawing.Point(170, 228);
            this.slider_DDE.Maximum = 7;
            this.slider_DDE.Name = "slider_DDE";
            this.slider_DDE.Size = new System.Drawing.Size(145, 45);
            this.slider_DDE.TabIndex = 27;
            this.slider_DDE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_DDE_MouseUp);
            // 
            // tB_Brightness
            // 
            this.tB_Brightness.Location = new System.Drawing.Point(115, 193);
            this.tB_Brightness.Name = "tB_Brightness";
            this.tB_Brightness.Size = new System.Drawing.Size(49, 20);
            this.tB_Brightness.TabIndex = 26;
            this.tB_Brightness.TextChanged += new System.EventHandler(this.tB_Brightness_TextChanged);
            this.tB_Brightness.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_Brightness_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(7, 196);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 18);
            this.label17.TabIndex = 25;
            this.label17.Text = "Brightness:";
            // 
            // slider_Brightness
            // 
            this.slider_Brightness.Location = new System.Drawing.Point(170, 196);
            this.slider_Brightness.Maximum = 511;
            this.slider_Brightness.Name = "slider_Brightness";
            this.slider_Brightness.Size = new System.Drawing.Size(143, 45);
            this.slider_Brightness.TabIndex = 24;
            this.slider_Brightness.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_Brightness_MouseUp);
            // 
            // tB_Contrast
            // 
            this.tB_Contrast.Location = new System.Drawing.Point(115, 158);
            this.tB_Contrast.Name = "tB_Contrast";
            this.tB_Contrast.Size = new System.Drawing.Size(49, 20);
            this.tB_Contrast.TabIndex = 23;
            this.tB_Contrast.TextChanged += new System.EventHandler(this.tB_Contrast_TextChanged);
            this.tB_Contrast.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tB_Contrast_KeyDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 158);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 18);
            this.label16.TabIndex = 22;
            this.label16.Text = "Contrast:";
            // 
            // slider_Contrast
            // 
            this.slider_Contrast.Location = new System.Drawing.Point(170, 158);
            this.slider_Contrast.Maximum = 255;
            this.slider_Contrast.Name = "slider_Contrast";
            this.slider_Contrast.Size = new System.Drawing.Size(145, 45);
            this.slider_Contrast.TabIndex = 21;
            this.slider_Contrast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.slider_Contrast_MouseUp);
            // 
            // cB_AGC
            // 
            this.cB_AGC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_AGC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cB_AGC.FormattingEnabled = true;
            this.cB_AGC.Items.AddRange(new object[] {
            "Manual",
            "Auto 0",
            "Auto 1",
            "-"});
            this.cB_AGC.Location = new System.Drawing.Point(114, 83);
            this.cB_AGC.Name = "cB_AGC";
            this.cB_AGC.Size = new System.Drawing.Size(200, 26);
            this.cB_AGC.TabIndex = 20;
            this.cB_AGC.SelectedIndexChanged += new System.EventHandler(this.cB_AGC_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(7, 86);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(86, 18);
            this.label15.TabIndex = 19;
            this.label15.Text = "AGC Mode:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "Image Flip:";
            // 
            // cB_Flip
            // 
            this.cB_Flip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Flip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cB_Flip.FormattingEnabled = true;
            this.cB_Flip.Items.AddRange(new object[] {
            "No Flip",
            "Mirror Flip",
            "-"});
            this.cB_Flip.Location = new System.Drawing.Point(115, 53);
            this.cB_Flip.Name = "cB_Flip";
            this.cB_Flip.Size = new System.Drawing.Size(200, 26);
            this.cB_Flip.TabIndex = 18;
            this.cB_Flip.SelectedValueChanged += new System.EventHandler(this.cB_Flip_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "Colour Palette:";
            // 
            // cB_Palette
            // 
            this.cB_Palette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Palette.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cB_Palette.FormattingEnabled = true;
            this.cB_Palette.Items.AddRange(new object[] {
            "White Hot",
            "Black Hot",
            "Rainbow1",
            "Rainbow2",
            "Red Hot",
            "-"});
            this.cB_Palette.Location = new System.Drawing.Point(114, 23);
            this.cB_Palette.Name = "cB_Palette";
            this.cB_Palette.Size = new System.Drawing.Size(201, 26);
            this.cB_Palette.TabIndex = 16;
            this.cB_Palette.SelectedValueChanged += new System.EventHandler(this.cB_Palette_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Control";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(490, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 66);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 62);
            this.label1.TabIndex = 4;
            this.label1.Text = "THERMAL Camera\r\nStaging Tool\r\n";
            // 
            // b_Play
            // 
            this.b_Play.AccessibleRole = System.Windows.Forms.AccessibleRole.WhiteSpace;
            this.b_Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b_Play.Location = new System.Drawing.Point(659, 35);
            this.b_Play.Name = "b_Play";
            this.b_Play.Size = new System.Drawing.Size(155, 84);
            this.b_Play.TabIndex = 15;
            this.b_Play.Text = "Play";
            this.b_Play.UseVisualStyleBackColor = true;
            this.b_Play.Click += new System.EventHandler(this.b_Play_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.p_Extended);
            this.panel1.Controls.Add(this.p_Basic);
            this.panel1.Controls.Add(this.check_Extend);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.b_Play);
            this.panel1.Location = new System.Drawing.Point(11, 546);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 132);
            this.panel1.TabIndex = 18;
            // 
            // p_Extended
            // 
            this.p_Extended.Controls.Add(this.tB_Extend_Port);
            this.p_Extended.Controls.Add(this.tB_Extend_RTSP);
            this.p_Extended.Controls.Add(this.tB_Extend_Password);
            this.p_Extended.Controls.Add(this.label10);
            this.p_Extended.Controls.Add(this.label9);
            this.p_Extended.Controls.Add(this.label11);
            this.p_Extended.Controls.Add(this.label12);
            this.p_Extended.Controls.Add(this.tB_Extend_IP);
            this.p_Extended.Controls.Add(this.label8);
            this.p_Extended.Controls.Add(this.tB_Extend_Username);
            this.p_Extended.Location = new System.Drawing.Point(3, 27);
            this.p_Extended.Name = "p_Extended";
            this.p_Extended.Size = new System.Drawing.Size(650, 92);
            this.p_Extended.TabIndex = 21;
            // 
            // tB_Extend_Port
            // 
            this.tB_Extend_Port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Extend_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Extend_Port.Location = new System.Drawing.Point(273, 19);
            this.tB_Extend_Port.Name = "tB_Extend_Port";
            this.tB_Extend_Port.Size = new System.Drawing.Size(126, 26);
            this.tB_Extend_Port.TabIndex = 27;
            this.tB_Extend_Port.Text = "554";
            // 
            // tB_Extend_RTSP
            // 
            this.tB_Extend_RTSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Extend_RTSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Extend_RTSP.Location = new System.Drawing.Point(95, 61);
            this.tB_Extend_RTSP.Name = "tB_Extend_RTSP";
            this.tB_Extend_RTSP.Size = new System.Drawing.Size(304, 26);
            this.tB_Extend_RTSP.TabIndex = 23;
            this.tB_Extend_RTSP.Text = "/videoinput_1:0/h264_1/onvif.stm";
            // 
            // tB_Extend_Password
            // 
            this.tB_Extend_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Extend_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Extend_Password.Location = new System.Drawing.Point(492, 61);
            this.tB_Extend_Password.Name = "tB_Extend_Password";
            this.tB_Extend_Password.Size = new System.Drawing.Size(132, 26);
            this.tB_Extend_Password.TabIndex = 25;
            this.tB_Extend_Password.Text = "admin";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 18);
            this.label10.TabIndex = 22;
            this.label10.Text = "RTSP String:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "IP Address:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(405, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 18);
            this.label11.TabIndex = 24;
            this.label11.Text = "Password:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(227, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 18);
            this.label12.TabIndex = 26;
            this.label12.Text = "Port:";
            // 
            // tB_Extend_IP
            // 
            this.tB_Extend_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Extend_IP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Extend_IP.Location = new System.Drawing.Point(96, 19);
            this.tB_Extend_IP.Name = "tB_Extend_IP";
            this.tB_Extend_IP.Size = new System.Drawing.Size(125, 26);
            this.tB_Extend_IP.TabIndex = 20;
            this.tB_Extend_IP.Text = "192.168.1.74";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(405, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "Username:";
            // 
            // tB_Extend_Username
            // 
            this.tB_Extend_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Extend_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Extend_Username.Location = new System.Drawing.Point(492, 19);
            this.tB_Extend_Username.Name = "tB_Extend_Username";
            this.tB_Extend_Username.Size = new System.Drawing.Size(132, 26);
            this.tB_Extend_Username.TabIndex = 21;
            this.tB_Extend_Username.Text = "admin";
            // 
            // p_Basic
            // 
            this.p_Basic.Controls.Add(this.tB_Basic_RTSP);
            this.p_Basic.Controls.Add(this.label14);
            this.p_Basic.Location = new System.Drawing.Point(7, 27);
            this.p_Basic.Name = "p_Basic";
            this.p_Basic.Size = new System.Drawing.Size(644, 92);
            this.p_Basic.TabIndex = 28;
            this.p_Basic.Visible = false;
            // 
            // tB_Basic_RTSP
            // 
            this.tB_Basic_RTSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tB_Basic_RTSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tB_Basic_RTSP.Location = new System.Drawing.Point(140, 37);
            this.tB_Basic_RTSP.Name = "tB_Basic_RTSP";
            this.tB_Basic_RTSP.Size = new System.Drawing.Size(481, 26);
            this.tB_Basic_RTSP.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(8, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 18);
            this.label14.TabIndex = 22;
            this.label14.Text = "Full RTSP String:";
            // 
            // check_Extend
            // 
            this.check_Extend.AutoSize = true;
            this.check_Extend.Checked = true;
            this.check_Extend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_Extend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Extend.Location = new System.Drawing.Point(657, 10);
            this.check_Extend.Name = "check_Extend";
            this.check_Extend.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.check_Extend.Size = new System.Drawing.Size(157, 19);
            this.check_Extend.TabIndex = 20;
            this.check_Extend.Text = "Show Extended Options";
            this.check_Extend.UseVisualStyleBackColor = true;
            this.check_Extend.CheckedChanged += new System.EventHandler(this.check_Extend_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(-1, -1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(141, 25);
            this.label13.TabIndex = 19;
            this.label13.Text = "Video Stream";
            // 
            // VLCPlayer
            // 
            this.VLCPlayer.Enabled = true;
            this.VLCPlayer.Location = new System.Drawing.Point(346, 101);
            this.VLCPlayer.Name = "VLCPlayer";
            this.VLCPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("VLCPlayer.OcxState")));
            this.VLCPlayer.Size = new System.Drawing.Size(500, 400);
            this.VLCPlayer.TabIndex = 19;
            // 
            // tB_Zoom
            // 
            this.tB_Zoom.Location = new System.Drawing.Point(115, 123);
            this.tB_Zoom.Name = "tB_Zoom";
            this.tB_Zoom.Size = new System.Drawing.Size(49, 20);
            this.tB_Zoom.TabIndex = 32;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 544);
            this.Controls.Add(this.VLCPlayer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.p_Control);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Thermal Camera Staging Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.p_Control.ResumeLayout(false);
            this.p_Control.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Zoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_DDE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Brightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.p_Extended.ResumeLayout(false);
            this.p_Extended.PerformLayout();
            this.p_Basic.ResumeLayout(false);
            this.p_Basic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VLCPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel p_Control;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button b_Connect;
        public System.Windows.Forms.TextBox tB_IP;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button b_DDEOff;
        public System.Windows.Forms.Button b_DDEOn;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label l_Connected;
        public System.Windows.Forms.ComboBox cB_Palette;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cB_Flip;
        public System.Windows.Forms.Button b_Play;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label13;
        public AxAXVLC.AxVLCPlugin2 VLCPlayer;
        public System.Windows.Forms.CheckBox check_Extend;
        public System.Windows.Forms.Panel p_Extended;
        public System.Windows.Forms.Panel p_Basic;
        public System.Windows.Forms.TextBox tB_Basic_RTSP;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox tB_Extend_Port;
        public System.Windows.Forms.TextBox tB_Extend_RTSP;
        public System.Windows.Forms.TextBox tB_Extend_Password;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox tB_Extend_IP;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tB_Extend_Username;
        public System.Windows.Forms.TextBox tB_DDE;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.TrackBar slider_DDE;
        public System.Windows.Forms.TextBox tB_Brightness;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.TrackBar slider_Brightness;
        public System.Windows.Forms.TextBox tB_Contrast;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.TrackBar slider_Contrast;
        public System.Windows.Forms.ComboBox cB_AGC;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.ComboBox cB_Port;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.TrackBar slider_Zoom;
        public System.Windows.Forms.TextBox tB_Zoom;
    }
}