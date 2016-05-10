namespace Client
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.t_settings = new System.Windows.Forms.TabPage();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_port = new System.Windows.Forms.NumericUpDown();
            this.txt_ipaddress = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.lb_username = new System.Windows.Forms.Label();
            this.t_messages = new System.Windows.Forms.TabPage();
            this.LBL_channel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TREE_channels = new System.Windows.Forms.TreeView();
            this.rtb_send_message = new System.Windows.Forms.RichTextBox();
            this.rtb_message_log = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.t_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).BeginInit();
            this.t_messages.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.t_settings);
            this.tabControl1.Controls.Add(this.t_messages);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(648, 562);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // t_settings
            // 
            this.t_settings.Controls.Add(this.btn_connect);
            this.t_settings.Controls.Add(this.label2);
            this.t_settings.Controls.Add(this.label1);
            this.t_settings.Controls.Add(this.nud_port);
            this.t_settings.Controls.Add(this.txt_ipaddress);
            this.t_settings.Controls.Add(this.txt_username);
            this.t_settings.Controls.Add(this.lb_username);
            this.t_settings.Location = new System.Drawing.Point(4, 22);
            this.t_settings.Name = "t_settings";
            this.t_settings.Padding = new System.Windows.Forms.Padding(3);
            this.t_settings.Size = new System.Drawing.Size(589, 515);
            this.t_settings.TabIndex = 0;
            this.t_settings.Text = "Settings";
            this.t_settings.UseVisualStyleBackColor = true;
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(14, 57);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(316, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(116, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address";
            // 
            // nud_port
            // 
            this.nud_port.Location = new System.Drawing.Point(320, 31);
            this.nud_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nud_port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_port.Name = "nud_port";
            this.nud_port.Size = new System.Drawing.Size(120, 20);
            this.nud_port.TabIndex = 2;
            this.nud_port.Value = new decimal(new int[] {
            3679,
            0,
            0,
            0});
            // 
            // txt_ipaddress
            // 
            this.txt_ipaddress.Location = new System.Drawing.Point(120, 30);
            this.txt_ipaddress.Name = "txt_ipaddress";
            this.txt_ipaddress.Size = new System.Drawing.Size(194, 20);
            this.txt_ipaddress.TabIndex = 1;
            this.txt_ipaddress.Text = "127.0.0.1";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(14, 31);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(100, 20);
            this.txt_username.TabIndex = 0;
            this.txt_username.Text = "jolli";
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.Location = new System.Drawing.Point(10, 7);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(83, 20);
            this.lb_username.TabIndex = 0;
            this.lb_username.Text = "Username";
            // 
            // t_messages
            // 
            this.t_messages.Controls.Add(this.LBL_channel);
            this.t_messages.Controls.Add(this.label3);
            this.t_messages.Controls.Add(this.TREE_channels);
            this.t_messages.Controls.Add(this.rtb_send_message);
            this.t_messages.Controls.Add(this.rtb_message_log);
            this.t_messages.Location = new System.Drawing.Point(4, 22);
            this.t_messages.Name = "t_messages";
            this.t_messages.Padding = new System.Windows.Forms.Padding(3);
            this.t_messages.Size = new System.Drawing.Size(640, 536);
            this.t_messages.TabIndex = 1;
            this.t_messages.Text = "Messages";
            this.t_messages.UseVisualStyleBackColor = true;
            // 
            // LBL_channel
            // 
            this.LBL_channel.AutoSize = true;
            this.LBL_channel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_channel.Location = new System.Drawing.Point(99, 490);
            this.LBL_channel.Name = "LBL_channel";
            this.LBL_channel.Size = new System.Drawing.Size(128, 16);
            this.LBL_channel.TabIndex = 6;
            this.LBL_channel.Text = "@root#DANKMEMES";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 491);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "You are in:";
            // 
            // TREE_channels
            // 
            this.TREE_channels.Location = new System.Drawing.Point(448, 6);
            this.TREE_channels.Name = "TREE_channels";
            this.TREE_channels.Size = new System.Drawing.Size(186, 354);
            this.TREE_channels.TabIndex = 4;
            // 
            // rtb_send_message
            // 
            this.rtb_send_message.Location = new System.Drawing.Point(6, 366);
            this.rtb_send_message.Name = "rtb_send_message";
            this.rtb_send_message.Size = new System.Drawing.Size(436, 117);
            this.rtb_send_message.TabIndex = 3;
            this.rtb_send_message.Text = "";
            this.rtb_send_message.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtb_send_message_KeyUp_1);
            // 
            // rtb_message_log
            // 
            this.rtb_message_log.Location = new System.Drawing.Point(6, 6);
            this.rtb_message_log.Name = "rtb_message_log";
            this.rtb_message_log.ReadOnly = true;
            this.rtb_message_log.Size = new System.Drawing.Size(436, 354);
            this.rtb_message_log.TabIndex = 2;
            this.rtb_message_log.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 561);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.t_settings.ResumeLayout(false);
            this.t_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).EndInit();
            this.t_messages.ResumeLayout(false);
            this.t_messages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage t_settings;
        private System.Windows.Forms.TabPage t_messages;
        private System.Windows.Forms.RichTextBox rtb_send_message;
        private System.Windows.Forms.RichTextBox rtb_message_log;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.NumericUpDown nud_port;
        private System.Windows.Forms.TextBox txt_ipaddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TreeView TREE_channels;
        private System.Windows.Forms.Label LBL_channel;
        private System.Windows.Forms.Label label3;
    }
}

