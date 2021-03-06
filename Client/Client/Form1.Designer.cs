﻿namespace Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.t_settings = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.LBL_front = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nud_port = new System.Windows.Forms.NumericUpDown();
            this.txt_ipaddress = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.lb_username = new System.Windows.Forms.Label();
            this.t_messages = new System.Windows.Forms.TabPage();
            this.pb_memes = new System.Windows.Forms.PictureBox();
            this.LBL_channel = new System.Windows.Forms.Label();
            this.TREE_channels = new System.Windows.Forms.TreeView();
            this.rtb_send_message = new System.Windows.Forms.RichTextBox();
            this.rtb_message_log = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.t_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).BeginInit();
            this.t_messages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_memes)).BeginInit();
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
            this.t_settings.Controls.Add(this.richTextBox1);
            this.t_settings.Controls.Add(this.LBL_front);
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
            this.t_settings.Size = new System.Drawing.Size(640, 536);
            this.t_settings.TabIndex = 0;
            this.t_settings.Text = "Settings";
            this.t_settings.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBox1.Location = new System.Drawing.Point(120, 147);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(463, 253);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // LBL_front
            // 
            this.LBL_front.AutoSize = true;
            this.LBL_front.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_front.Location = new System.Drawing.Point(226, 107);
            this.LBL_front.Name = "LBL_front";
            this.LBL_front.Size = new System.Drawing.Size(183, 25);
            this.LBL_front.TabIndex = 6;
            this.LBL_front.Text = "Welcome to mIRC";
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
            this.nud_port.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nud_port_KeyUp);
            // 
            // txt_ipaddress
            // 
            this.txt_ipaddress.Location = new System.Drawing.Point(120, 30);
            this.txt_ipaddress.Name = "txt_ipaddress";
            this.txt_ipaddress.Size = new System.Drawing.Size(194, 20);
            this.txt_ipaddress.TabIndex = 1;
            this.txt_ipaddress.Text = "127.0.0.1";
            this.txt_ipaddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_ipaddress_KeyUp);
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(14, 31);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(100, 20);
            this.txt_username.TabIndex = 0;
            this.txt_username.Text = "jolli";
            this.txt_username.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_username_KeyUp);
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
            this.t_messages.Controls.Add(this.pb_memes);
            this.t_messages.Controls.Add(this.LBL_channel);
            this.t_messages.Controls.Add(this.TREE_channels);
            this.t_messages.Controls.Add(this.rtb_send_message);
            this.t_messages.Controls.Add(this.rtb_message_log);
            this.t_messages.Location = new System.Drawing.Point(4, 22);
            this.t_messages.Name = "t_messages";
            this.t_messages.Padding = new System.Windows.Forms.Padding(3);
            this.t_messages.Size = new System.Drawing.Size(640, 536);
            this.t_messages.TabIndex = 1;
            this.t_messages.Text = "Memeges";
            this.t_messages.UseVisualStyleBackColor = true;
            // 
            // pb_memes
            // 
            this.pb_memes.Location = new System.Drawing.Point(448, 366);
            this.pb_memes.Name = "pb_memes";
            this.pb_memes.Size = new System.Drawing.Size(186, 161);
            this.pb_memes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_memes.TabIndex = 7;
            this.pb_memes.TabStop = false;
            // 
            // LBL_channel
            // 
            this.LBL_channel.AutoSize = true;
            this.LBL_channel.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_channel.Location = new System.Drawing.Point(9, 511);
            this.LBL_channel.Name = "LBL_channel";
            this.LBL_channel.Size = new System.Drawing.Size(128, 16);
            this.LBL_channel.TabIndex = 6;
            this.LBL_channel.Text = "@root#DANKMEMES";
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
            this.rtb_send_message.Size = new System.Drawing.Size(436, 142);
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
            this.Text = "m(eme)IRC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.t_settings.ResumeLayout(false);
            this.t_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).EndInit();
            this.t_messages.ResumeLayout(false);
            this.t_messages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_memes)).EndInit();
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
        private System.Windows.Forms.PictureBox pb_memes;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label LBL_front;
    }
}

