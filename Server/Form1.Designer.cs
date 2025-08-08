namespace Server
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
            btn_start = new Button();
            txt_recv = new TextBox();
            txt_port = new TextBox();
            label1 = new Label();
            btn_clear = new Button();
            SuspendLayout();
            // 
            // btn_start
            // 
            btn_start.Location = new Point(563, 860);
            btn_start.Margin = new Padding(4);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(131, 40);
            btn_start.TabIndex = 0;
            btn_start.Text = "启动服务";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // txt_recv
            // 
            txt_recv.Location = new Point(12, 12);
            txt_recv.Margin = new Padding(4);
            txt_recv.Multiline = true;
            txt_recv.Name = "txt_recv";
            txt_recv.Size = new Size(682, 819);
            txt_recv.TabIndex = 1;
            // 
            // txt_port
            // 
            txt_port.Location = new Point(441, 863);
            txt_port.Margin = new Padding(4);
            txt_port.Name = "txt_port";
            txt_port.Size = new Size(99, 34);
            txt_port.TabIndex = 2;
            txt_port.Text = "9527";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(295, 866);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 28);
            label1.TabIndex = 3;
            label1.Text = "服务器端口：";
            // 
            // btn_clear
            // 
            btn_clear.Location = new Point(12, 860);
            btn_clear.Name = "btn_clear";
            btn_clear.Size = new Size(131, 40);
            btn_clear.TabIndex = 4;
            btn_clear.Text = "清空日志";
            btn_clear.UseVisualStyleBackColor = true;
            btn_clear.Click += btn_clear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 928);
            Controls.Add(btn_clear);
            Controls.Add(label1);
            Controls.Add(txt_port);
            Controls.Add(txt_recv);
            Controls.Add(btn_start);
            Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "服务端";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_start;
        private TextBox txt_recv;
        private TextBox txt_port;
        private Label label1;
        private Button btn_clear;
    }
}
