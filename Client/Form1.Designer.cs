namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txt_ip = new TextBox();
            label2 = new Label();
            txt_port = new TextBox();
            btn_connect = new Button();
            txt_recv = new TextBox();
            label3 = new Label();
            txt_msg = new TextBox();
            btn_send = new Button();
            btn_clear = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 27);
            label1.Name = "label1";
            label1.Size = new Size(115, 28);
            label1.TabIndex = 0;
            label1.Text = "服务器IP：";
            // 
            // txt_ip
            // 
            txt_ip.Location = new Point(144, 24);
            txt_ip.Name = "txt_ip";
            txt_ip.Size = new Size(291, 34);
            txt_ip.TabIndex = 1;
            txt_ip.Text = "127.0.0.1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(466, 27);
            label2.Name = "label2";
            label2.Size = new Size(75, 28);
            label2.TabIndex = 2;
            label2.Text = "端口：";
            // 
            // txt_port
            // 
            txt_port.Location = new Point(547, 24);
            txt_port.Name = "txt_port";
            txt_port.Size = new Size(99, 34);
            txt_port.TabIndex = 2;
            txt_port.Text = "9527";
            // 
            // btn_connect
            // 
            btn_connect.Location = new Point(665, 21);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new Size(131, 40);
            btn_connect.TabIndex = 3;
            btn_connect.Text = "连接";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // txt_recv
            // 
            txt_recv.Location = new Point(12, 85);
            txt_recv.Multiline = true;
            txt_recv.Name = "txt_recv";
            txt_recv.Size = new Size(1136, 553);
            txt_recv.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 687);
            label3.Name = "label3";
            label3.Size = new Size(75, 28);
            label3.TabIndex = 6;
            label3.Text = "消息：";
            // 
            // txt_msg
            // 
            txt_msg.Location = new Point(108, 653);
            txt_msg.Multiline = true;
            txt_msg.Name = "txt_msg";
            txt_msg.Size = new Size(853, 97);
            txt_msg.TabIndex = 5;
            // 
            // btn_send
            // 
            btn_send.Location = new Point(999, 667);
            btn_send.Name = "btn_send";
            btn_send.Size = new Size(131, 68);
            btn_send.TabIndex = 0;
            btn_send.Text = "发送";
            btn_send.UseVisualStyleBackColor = true;
            btn_send.Click += btn_send_Click;
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(1017, 21);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(131, 40);
            btn_clear.TabIndex = 7;
            btn_clear.Text = "清空日志";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 762);
            Controls.Add(btn_clear);
            Controls.Add(btn_send);
            Controls.Add(txt_msg);
            Controls.Add(label3);
            Controls.Add(txt_recv);
            Controls.Add(btn_connect);
            Controls.Add(txt_port);
            Controls.Add(label2);
            Controls.Add(txt_ip);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "客户端";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_ip;
        private Label label2;
        private TextBox txt_port;
        private Button btn_connect;
        private TextBox txt_recv;
        private Label label3;
        private TextBox txt_msg;
        private Button btn_send;
        private Button btn_clear;
    }
}
