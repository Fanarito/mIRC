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
            this.rtb_message_log = new System.Windows.Forms.RichTextBox();
            this.rtb_send_message = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_message_log
            // 
            this.rtb_message_log.Location = new System.Drawing.Point(13, 13);
            this.rtb_message_log.Name = "rtb_message_log";
            this.rtb_message_log.ReadOnly = true;
            this.rtb_message_log.Size = new System.Drawing.Size(440, 314);
            this.rtb_message_log.TabIndex = 1;
            this.rtb_message_log.Text = "";
            // 
            // rtb_send_message
            // 
            this.rtb_send_message.Location = new System.Drawing.Point(13, 334);
            this.rtb_send_message.Name = "rtb_send_message";
            this.rtb_send_message.Size = new System.Drawing.Size(440, 95);
            this.rtb_send_message.TabIndex = 0;
            this.rtb_send_message.Text = "";
            this.rtb_send_message.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtb_send_message_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 441);
            this.Controls.Add(this.rtb_send_message);
            this.Controls.Add(this.rtb_message_log);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_message_log;
        private System.Windows.Forms.RichTextBox rtb_send_message;
    }
}

