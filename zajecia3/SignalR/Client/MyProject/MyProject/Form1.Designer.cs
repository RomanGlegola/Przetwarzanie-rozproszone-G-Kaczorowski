namespace MyProject
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
            btnConnect = new Button();
            lblConnection = new Label();
            label1 = new Label();
            label2 = new Label();
            txtUser = new TextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            lstMessage = new ListBox();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(87, 45);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblConnection
            // 
            lblConnection.AutoSize = true;
            lblConnection.Location = new Point(88, 93);
            lblConnection.Name = "lblConnection";
            lblConnection.Size = new Size(104, 20);
            lblConnection.TabIndex = 1;
            lblConnection.Text = "not connected";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(309, 48);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 2;
            label1.Text = "User";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(311, 97);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 3;
            label2.Text = "Message";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(385, 48);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(125, 27);
            txtUser.TabIndex = 4;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(385, 97);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(125, 27);
            txtMessage.TabIndex = 5;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(416, 160);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // lstMessage
            // 
            lstMessage.FormattingEnabled = true;
            lstMessage.Location = new Point(199, 233);
            lstMessage.Name = "lstMessage";
            lstMessage.Size = new Size(361, 184);
            lstMessage.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 479);
            Controls.Add(lstMessage);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtUser);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblConnection);
            Controls.Add(btnConnect);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConnect;
        private Label lblConnection;
        private Label label1;
        private Label label2;
        private TextBox txtUser;
        private TextBox txtMessage;
        private Button btnSend;
        private ListBox lstMessage;
    }
}
