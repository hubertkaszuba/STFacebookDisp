namespace facebook_displayer
{
    partial class Facebook_displayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facebook_displayer));
            this.WebFacebook = new System.Windows.Forms.WebBrowser();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lstNotificationList = new System.Windows.Forms.ListBox();
            this.btn_Get_List = new System.Windows.Forms.Button();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pg_logowanie = new System.Windows.Forms.TabPage();
            this.lbl_token = new System.Windows.Forms.Label();
            this.txtBoxToken = new System.Windows.Forms.TextBox();
            this.btn_autoSignIn = new System.Windows.Forms.Button();
            this.pg_lista = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pg_serialport = new System.Windows.Forms.TabPage();
            this.btn_scan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_close_port = new System.Windows.Forms.Button();
            this.btn_open_port = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbl4 = new System.Windows.Forms.Label();
            this.btn_auto_wysylanie = new System.Windows.Forms.Button();
            this.btn_read = new System.Windows.Forms.Button();
            this.box_received_data = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_wyslij_liste = new System.Windows.Forms.Button();
            this.btn_send = new System.Windows.Forms.Button();
            this.box_sended_data = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.box_baud_rate = new System.Windows.Forms.ComboBox();
            this.box_port_names = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.tabControl1.SuspendLayout();
            this.pg_logowanie.SuspendLayout();
            this.pg_lista.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pg_serialport.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebFacebook
            // 
            this.WebFacebook.Location = new System.Drawing.Point(-387, -179);
            this.WebFacebook.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebFacebook.Name = "WebFacebook";
            this.WebFacebook.ScriptErrorsSuppressed = true;
            this.WebFacebook.Size = new System.Drawing.Size(1347, 518);
            this.WebFacebook.TabIndex = 0;
            this.WebFacebook.Url = new System.Uri("", System.UriKind.Relative);
            this.WebFacebook.WebBrowserShortcutsEnabled = false;
            this.WebFacebook.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebFacebook_DocumentCompleted);
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSignIn.Location = new System.Drawing.Point(8, 280);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(392, 23);
            this.btnSignIn.TabIndex = 1;
            this.btnSignIn.Text = "Manual login";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lstNotificationList
            // 
            this.lstNotificationList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lstNotificationList.FormattingEnabled = true;
            this.lstNotificationList.Location = new System.Drawing.Point(6, 19);
            this.lstNotificationList.Name = "lstNotificationList";
            this.lstNotificationList.Size = new System.Drawing.Size(500, 108);
            this.lstNotificationList.TabIndex = 2;
            // 
            // btn_Get_List
            // 
            this.btn_Get_List.Enabled = false;
            this.btn_Get_List.Location = new System.Drawing.Point(8, 280);
            this.btn_Get_List.Name = "btn_Get_List";
            this.btn_Get_List.Size = new System.Drawing.Size(95, 23);
            this.btn_Get_List.TabIndex = 3;
            this.btn_Get_List.Text = "Download list";
            this.btn_Get_List.UseVisualStyleBackColor = true;
            this.btn_Get_List.Click += new System.EventHandler(this.btn_Get_List_Click);
            // 
            // txtBox1
            // 
            this.txtBox1.Enabled = false;
            this.txtBox1.Location = new System.Drawing.Point(6, 16);
            this.txtBox1.Multiline = true;
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(500, 108);
            this.txtBox1.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(109, 280);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.pg_logowanie);
            this.tabControl1.Controls.Add(this.pg_lista);
            this.tabControl1.Controls.Add(this.pg_serialport);
            this.tabControl1.Location = new System.Drawing.Point(12, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(537, 331);
            this.tabControl1.TabIndex = 6;
            // 
            // pg_logowanie
            // 
            this.pg_logowanie.Controls.Add(this.lbl_token);
            this.pg_logowanie.Controls.Add(this.txtBoxToken);
            this.pg_logowanie.Controls.Add(this.btn_autoSignIn);
            this.pg_logowanie.Controls.Add(this.btnSignIn);
            this.pg_logowanie.Controls.Add(this.WebFacebook);
            this.pg_logowanie.Location = new System.Drawing.Point(4, 22);
            this.pg_logowanie.Name = "pg_logowanie";
            this.pg_logowanie.Padding = new System.Windows.Forms.Padding(3);
            this.pg_logowanie.Size = new System.Drawing.Size(529, 305);
            this.pg_logowanie.TabIndex = 0;
            this.pg_logowanie.Text = "Login";
            this.pg_logowanie.UseVisualStyleBackColor = true;
            this.pg_logowanie.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // lbl_token
            // 
            this.lbl_token.AutoSize = true;
            this.lbl_token.Location = new System.Drawing.Point(8, 235);
            this.lbl_token.Name = "lbl_token";
            this.lbl_token.Size = new System.Drawing.Size(79, 13);
            this.lbl_token.TabIndex = 4;
            this.lbl_token.Text = "Access Token:";
            // 
            // txtBoxToken
            // 
            this.txtBoxToken.Location = new System.Drawing.Point(8, 254);
            this.txtBoxToken.Name = "txtBoxToken";
            this.txtBoxToken.Size = new System.Drawing.Size(515, 20);
            this.txtBoxToken.TabIndex = 3;
            // 
            // btn_autoSignIn
            // 
            this.btn_autoSignIn.BackColor = System.Drawing.Color.AliceBlue;
            this.btn_autoSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_autoSignIn.Location = new System.Drawing.Point(406, 280);
            this.btn_autoSignIn.Name = "btn_autoSignIn";
            this.btn_autoSignIn.Size = new System.Drawing.Size(117, 23);
            this.btn_autoSignIn.TabIndex = 2;
            this.btn_autoSignIn.Text = "Auto login";
            this.btn_autoSignIn.UseVisualStyleBackColor = false;
            this.btn_autoSignIn.Click += new System.EventHandler(this.btn_autoSignIn_Click);
            // 
            // pg_lista
            // 
            this.pg_lista.Controls.Add(this.groupBox4);
            this.pg_lista.Controls.Add(this.groupBox3);
            this.pg_lista.Controls.Add(this.btnClear);
            this.pg_lista.Controls.Add(this.btn_Get_List);
            this.pg_lista.Location = new System.Drawing.Point(4, 22);
            this.pg_lista.Name = "pg_lista";
            this.pg_lista.Padding = new System.Windows.Forms.Padding(3);
            this.pg_lista.Size = new System.Drawing.Size(529, 305);
            this.pg_lista.TabIndex = 1;
            this.pg_lista.Text = "Notification list";
            this.pg_lista.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstNotificationList);
            this.groupBox4.Location = new System.Drawing.Point(8, 136);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(512, 140);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Notification list";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtBox1);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 130);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Content to send";
            // 
            // pg_serialport
            // 
            this.pg_serialport.Controls.Add(this.btn_scan);
            this.pg_serialport.Controls.Add(this.label3);
            this.pg_serialport.Controls.Add(this.label2);
            this.pg_serialport.Controls.Add(this.label1);
            this.pg_serialport.Controls.Add(this.btn_close_port);
            this.pg_serialport.Controls.Add(this.btn_open_port);
            this.pg_serialport.Controls.Add(this.groupBox2);
            this.pg_serialport.Controls.Add(this.groupBox1);
            this.pg_serialport.Controls.Add(this.progressBar1);
            this.pg_serialport.Controls.Add(this.box_baud_rate);
            this.pg_serialport.Controls.Add(this.box_port_names);
            this.pg_serialport.Location = new System.Drawing.Point(4, 22);
            this.pg_serialport.Name = "pg_serialport";
            this.pg_serialport.Padding = new System.Windows.Forms.Padding(3);
            this.pg_serialport.Size = new System.Drawing.Size(529, 305);
            this.pg_serialport.TabIndex = 2;
            this.pg_serialport.Text = "Serial Port";
            this.pg_serialport.UseVisualStyleBackColor = true;
            // 
            // btn_scan
            // 
            this.btn_scan.Location = new System.Drawing.Point(22, 40);
            this.btn_scan.Name = "btn_scan";
            this.btn_scan.Size = new System.Drawing.Size(65, 21);
            this.btn_scan.TabIndex = 21;
            this.btn_scan.Text = "Scan";
            this.btn_scan.UseVisualStyleBackColor = true;
            this.btn_scan.Click += new System.EventHandler(this.btn_scan_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(370, 286);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Baud rate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Port names";
            // 
            // btn_close_port
            // 
            this.btn_close_port.Enabled = false;
            this.btn_close_port.Location = new System.Drawing.Point(357, 49);
            this.btn_close_port.Name = "btn_close_port";
            this.btn_close_port.Size = new System.Drawing.Size(82, 21);
            this.btn_close_port.TabIndex = 17;
            this.btn_close_port.Text = "Close port";
            this.btn_close_port.UseVisualStyleBackColor = true;
            this.btn_close_port.Click += new System.EventHandler(this.btn_close_port_Click);
            // 
            // btn_open_port
            // 
            this.btn_open_port.Location = new System.Drawing.Point(357, 22);
            this.btn_open_port.Name = "btn_open_port";
            this.btn_open_port.Size = new System.Drawing.Size(82, 21);
            this.btn_open_port.TabIndex = 16;
            this.btn_open_port.Text = "Open port";
            this.btn_open_port.UseVisualStyleBackColor = true;
            this.btn_open_port.Click += new System.EventHandler(this.btn_open_port_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbl4);
            this.groupBox2.Controls.Add(this.btn_auto_wysylanie);
            this.groupBox2.Controls.Add(this.btn_read);
            this.groupBox2.Controls.Add(this.box_received_data);
            this.groupBox2.Location = new System.Drawing.Point(260, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 204);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Received data";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(150, 181);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(58, 13);
            this.lbl4.TabIndex = 13;
            this.lbl4.Text = "Auto send:";
            // 
            // btn_auto_wysylanie
            // 
            this.btn_auto_wysylanie.Location = new System.Drawing.Point(214, 176);
            this.btn_auto_wysylanie.Name = "btn_auto_wysylanie";
            this.btn_auto_wysylanie.Size = new System.Drawing.Size(39, 23);
            this.btn_auto_wysylanie.TabIndex = 3;
            this.btn_auto_wysylanie.Text = "Off";
            this.btn_auto_wysylanie.UseVisualStyleBackColor = true;
            this.btn_auto_wysylanie.Click += new System.EventHandler(this.btn_auto_send);
            // 
            // btn_read
            // 
            this.btn_read.Enabled = false;
            this.btn_read.Location = new System.Drawing.Point(6, 175);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(75, 23);
            this.btn_read.TabIndex = 2;
            this.btn_read.Text = "Read";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // box_received_data
            // 
            this.box_received_data.Location = new System.Drawing.Point(6, 19);
            this.box_received_data.Multiline = true;
            this.box_received_data.Name = "box_received_data";
            this.box_received_data.ReadOnly = true;
            this.box_received_data.Size = new System.Drawing.Size(251, 150);
            this.box_received_data.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_wyslij_liste);
            this.groupBox1.Controls.Add(this.btn_send);
            this.groupBox1.Controls.Add(this.box_sended_data);
            this.groupBox1.Location = new System.Drawing.Point(6, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 204);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data to send";
            // 
            // btn_wyslij_liste
            // 
            this.btn_wyslij_liste.Enabled = false;
            this.btn_wyslij_liste.Location = new System.Drawing.Point(85, 175);
            this.btn_wyslij_liste.Name = "btn_wyslij_liste";
            this.btn_wyslij_liste.Size = new System.Drawing.Size(75, 23);
            this.btn_wyslij_liste.TabIndex = 2;
            this.btn_wyslij_liste.Text = "Send list";
            this.btn_wyslij_liste.UseVisualStyleBackColor = true;
            this.btn_wyslij_liste.Click += new System.EventHandler(this.btn_send_list_Click);
            // 
            // btn_send
            // 
            this.btn_send.Enabled = false;
            this.btn_send.Location = new System.Drawing.Point(166, 175);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // box_sended_data
            // 
            this.box_sended_data.Enabled = false;
            this.box_sended_data.Location = new System.Drawing.Point(6, 19);
            this.box_sended_data.Multiline = true;
            this.box_sended_data.Name = "box_sended_data";
            this.box_sended_data.Size = new System.Drawing.Size(235, 150);
            this.box_sended_data.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(413, 286);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 13);
            this.progressBar1.TabIndex = 13;
            // 
            // box_baud_rate
            // 
            this.box_baud_rate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_baud_rate.FormattingEnabled = true;
            this.box_baud_rate.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.box_baud_rate.Location = new System.Drawing.Point(220, 40);
            this.box_baud_rate.Name = "box_baud_rate";
            this.box_baud_rate.Size = new System.Drawing.Size(121, 21);
            this.box_baud_rate.TabIndex = 11;
            // 
            // box_port_names
            // 
            this.box_port_names.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.box_port_names.FormattingEnabled = true;
            this.box_port_names.Items.AddRange(new object[] {
            ""});
            this.box_port_names.Location = new System.Drawing.Point(93, 40);
            this.box_port_names.Name = "box_port_names";
            this.box_port_names.Size = new System.Drawing.Size(121, 21);
            this.box_port_names.TabIndex = 10;
            // 
            // Facebook_displayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(132)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(561, 348);
            this.Controls.Add(this.tabControl1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Facebook_displayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook Displayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Facebook_displayer_FormClosing);
            this.Load += new System.EventHandler(this.Facebook_Displayer_Load);
            this.tabControl1.ResumeLayout(false);
            this.pg_logowanie.ResumeLayout(false);
            this.pg_logowanie.PerformLayout();
            this.pg_lista.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pg_serialport.ResumeLayout(false);
            this.pg_serialport.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebFacebook;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.ListBox lstNotificationList;
        private System.Windows.Forms.Button btn_Get_List;
        private System.Windows.Forms.TextBox txtBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pg_logowanie;
        private System.Windows.Forms.TabPage pg_lista;
        private System.Windows.Forms.TabPage pg_serialport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox box_received_data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_close_port;
        private System.Windows.Forms.Button btn_open_port;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox box_sended_data;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox box_baud_rate;
        private System.Windows.Forms.ComboBox box_port_names;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_wyslij_liste;
        private System.Windows.Forms.Button btn_scan;
        private System.Windows.Forms.Button btn_auto_wysylanie;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Button btn_autoSignIn;
        private System.Windows.Forms.TextBox txtBoxToken;
        private System.Windows.Forms.Label lbl_token;
    }
}

