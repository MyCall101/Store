namespace Store.Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            storeTitle = new Label();
            panel2 = new Panel();
            linkLabel1 = new LinkLabel();
            lblfooter1 = new Label();
            panel3 = new Panel();
            panel4 = new Panel();
            btnLogin = new Button();
            pictureBox1 = new PictureBox();
            txbPassword = new TextBox();
            label1 = new Label();
            picUser = new PictureBox();
            txbUser = new TextBox();
            lbluser = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picUser).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(storeTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(452, 49);
            panel1.TabIndex = 0;
            // 
            // storeTitle
            // 
            storeTitle.Cursor = Cursors.No;
            storeTitle.Dock = DockStyle.Fill;
            storeTitle.FlatStyle = FlatStyle.Flat;
            storeTitle.Font = new Font("Arial", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            storeTitle.Location = new Point(0, 0);
            storeTitle.Name = "storeTitle";
            storeTitle.Size = new Size(450, 47);
            storeTitle.TabIndex = 0;
            storeTitle.Text = "Arneil && Fam. Store";
            storeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(lblfooter1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 191);
            panel2.Name = "panel2";
            panel2.Size = new Size(452, 25);
            panel2.TabIndex = 1;
            // 
            // linkLabel1
            // 
            linkLabel1.Dock = DockStyle.Right;
            linkLabel1.Font = new Font("Arial", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            linkLabel1.Location = new Point(239, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(213, 25);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Icons8";
            linkLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblfooter1
            // 
            lblfooter1.Cursor = Cursors.No;
            lblfooter1.Dock = DockStyle.Left;
            lblfooter1.FlatStyle = FlatStyle.Flat;
            lblfooter1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblfooter1.Location = new Point(0, 0);
            lblfooter1.Name = "lblfooter1";
            lblfooter1.Size = new Size(241, 25);
            lblfooter1.TabIndex = 0;
            lblfooter1.Text = "Icons by :";
            lblfooter1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel4);
            panel3.Cursor = Cursors.No;
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 49);
            panel3.Name = "panel3";
            panel3.Size = new Size(452, 142);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnLogin);
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(txbPassword);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(picUser);
            panel4.Controls.Add(txbUser);
            panel4.Controls.Add(lbluser);
            panel4.Location = new Point(88, 20);
            panel4.Name = "panel4";
            panel4.Size = new Size(283, 103);
            panel4.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(95, 74);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(128, 27);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.No;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(227, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(16, 18);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // txbPassword
            // 
            txbPassword.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txbPassword.Location = new Point(96, 41);
            txbPassword.Name = "txbPassword";
            txbPassword.PasswordChar = '*';
            txbPassword.Size = new Size(128, 25);
            txbPassword.TabIndex = 1;
            txbPassword.KeyDown += txbPassword_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.No;
            label1.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(9, 48);
            label1.Name = "label1";
            label1.Size = new Size(85, 16);
            label1.TabIndex = 3;
            label1.Text = "Password : *";
            // 
            // picUser
            // 
            picUser.Cursor = Cursors.No;
            picUser.Image = (Image)resources.GetObject("picUser.Image");
            picUser.Location = new Point(227, 13);
            picUser.Name = "picUser";
            picUser.Size = new Size(16, 18);
            picUser.SizeMode = PictureBoxSizeMode.StretchImage;
            picUser.TabIndex = 2;
            picUser.TabStop = false;
            // 
            // txbUser
            // 
            txbUser.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txbUser.Location = new Point(96, 6);
            txbUser.Name = "txbUser";
            txbUser.Size = new Size(128, 25);
            txbUser.TabIndex = 0;
            txbUser.KeyDown += txbUser_KeyDown;
            // 
            // lbluser
            // 
            lbluser.AutoSize = true;
            lbluser.Cursor = Cursors.No;
            lbluser.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbluser.Location = new Point(7, 10);
            lbluser.Name = "lbluser";
            lbluser.Size = new Size(88, 16);
            lbluser.TabIndex = 0;
            lbluser.Text = "Username : *";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(452, 216);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            FormClosed += Login_FormClosed;
            Load += Login_Load;
            Shown += Login_Shown;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picUser).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label storeTitle;
        private Panel panel2;
        private Label lblfooter1;
        private LinkLabel linkLabel1;
        private Panel panel3;
        private Panel panel4;
        private TextBox txbUser;
        private Label lbluser;
        private PictureBox picUser;
        private Button btnLogin;
        private PictureBox pictureBox1;
        private TextBox txbPassword;
        private Label label1;
    }
}