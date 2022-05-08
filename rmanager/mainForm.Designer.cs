
namespace rmanager
{
    partial class mainForm
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
            this.usernameLoginLabel = new System.Windows.Forms.Label();
            this.passwordLoginLabel = new System.Windows.Forms.Label();
            this.usernameRegisterLabel = new System.Windows.Forms.Label();
            this.passwordRegisterLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.usernameLoginTextBox = new System.Windows.Forms.TextBox();
            this.passwordLoginTextBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.usernameRegisterTextBox = new System.Windows.Forms.TextBox();
            this.passwordRegisterTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.emailErrorLabel = new System.Windows.Forms.Label();
            this.passwordRegisterErrorLabel = new System.Windows.Forms.Label();
            this.numberErrorLabel = new System.Windows.Forms.Label();
            this.loginOrRegisterLabel = new System.Windows.Forms.Label();
            this.usernameRegisterErrorLabel = new System.Windows.Forms.Label();
            this.loginErrorLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameLoginLabel
            // 
            this.usernameLoginLabel.AutoSize = true;
            this.usernameLoginLabel.Location = new System.Drawing.Point(33, 149);
            this.usernameLoginLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.usernameLoginLabel.Name = "usernameLoginLabel";
            this.usernameLoginLabel.Size = new System.Drawing.Size(153, 32);
            this.usernameLoginLabel.TabIndex = 1;
            this.usernameLoginLabel.Text = "Username:";
            // 
            // passwordLoginLabel
            // 
            this.passwordLoginLabel.AutoSize = true;
            this.passwordLoginLabel.Location = new System.Drawing.Point(33, 263);
            this.passwordLoginLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.passwordLoginLabel.Name = "passwordLoginLabel";
            this.passwordLoginLabel.Size = new System.Drawing.Size(147, 32);
            this.passwordLoginLabel.TabIndex = 2;
            this.passwordLoginLabel.Text = "Password:";
            // 
            // usernameRegisterLabel
            // 
            this.usernameRegisterLabel.AutoSize = true;
            this.usernameRegisterLabel.Location = new System.Drawing.Point(348, 35);
            this.usernameRegisterLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.usernameRegisterLabel.Name = "usernameRegisterLabel";
            this.usernameRegisterLabel.Size = new System.Drawing.Size(153, 32);
            this.usernameRegisterLabel.TabIndex = 3;
            this.usernameRegisterLabel.Text = "Username:";
            // 
            // passwordRegisterLabel
            // 
            this.passwordRegisterLabel.AutoSize = true;
            this.passwordRegisterLabel.Location = new System.Drawing.Point(348, 149);
            this.passwordRegisterLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.passwordRegisterLabel.Name = "passwordRegisterLabel";
            this.passwordRegisterLabel.Size = new System.Drawing.Size(147, 32);
            this.passwordRegisterLabel.TabIndex = 4;
            this.passwordRegisterLabel.Text = "Password:";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(348, 263);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(104, 32);
            this.emailLabel.TabIndex = 5;
            this.emailLabel.Text = "E-mail:";
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(348, 377);
            this.numberLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(215, 32);
            this.numberLabel.TabIndex = 6;
            this.numberLabel.Text = "Mobile Number:";
            // 
            // usernameLoginTextBox
            // 
            this.usernameLoginTextBox.Location = new System.Drawing.Point(39, 184);
            this.usernameLoginTextBox.Name = "usernameLoginTextBox";
            this.usernameLoginTextBox.Size = new System.Drawing.Size(202, 38);
            this.usernameLoginTextBox.TabIndex = 7;
            this.usernameLoginTextBox.Text = "nikolamarin";
            // 
            // passwordLoginTextBox
            // 
            this.passwordLoginTextBox.Location = new System.Drawing.Point(39, 298);
            this.passwordLoginTextBox.Name = "passwordLoginTextBox";
            this.passwordLoginTextBox.PasswordChar = '*';
            this.passwordLoginTextBox.Size = new System.Drawing.Size(202, 38);
            this.passwordLoginTextBox.TabIndex = 8;
            this.passwordLoginTextBox.Text = "nikolamarin1";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(64, 342);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(151, 62);
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usernameRegisterTextBox
            // 
            this.usernameRegisterTextBox.Location = new System.Drawing.Point(354, 70);
            this.usernameRegisterTextBox.Name = "usernameRegisterTextBox";
            this.usernameRegisterTextBox.Size = new System.Drawing.Size(202, 38);
            this.usernameRegisterTextBox.TabIndex = 10;
            // 
            // passwordRegisterTextBox
            // 
            this.passwordRegisterTextBox.Location = new System.Drawing.Point(354, 184);
            this.passwordRegisterTextBox.Name = "passwordRegisterTextBox";
            this.passwordRegisterTextBox.PasswordChar = '*';
            this.passwordRegisterTextBox.Size = new System.Drawing.Size(202, 38);
            this.passwordRegisterTextBox.TabIndex = 11;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(354, 298);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(202, 38);
            this.emailTextBox.TabIndex = 12;
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(354, 412);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.Size = new System.Drawing.Size(202, 38);
            this.numberTextBox.TabIndex = 13;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(381, 456);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(151, 62);
            this.registerButton.TabIndex = 14;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // emailErrorLabel
            // 
            this.emailErrorLabel.AutoSize = true;
            this.emailErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.emailErrorLabel.Location = new System.Drawing.Point(350, 239);
            this.emailErrorLabel.Name = "emailErrorLabel";
            this.emailErrorLabel.Size = new System.Drawing.Size(0, 24);
            this.emailErrorLabel.TabIndex = 17;
            // 
            // passwordRegisterErrorLabel
            // 
            this.passwordRegisterErrorLabel.AutoSize = true;
            this.passwordRegisterErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordRegisterErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.passwordRegisterErrorLabel.Location = new System.Drawing.Point(350, 125);
            this.passwordRegisterErrorLabel.Name = "passwordRegisterErrorLabel";
            this.passwordRegisterErrorLabel.Size = new System.Drawing.Size(0, 24);
            this.passwordRegisterErrorLabel.TabIndex = 18;
            // 
            // numberErrorLabel
            // 
            this.numberErrorLabel.AutoSize = true;
            this.numberErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.numberErrorLabel.Location = new System.Drawing.Point(350, 353);
            this.numberErrorLabel.Name = "numberErrorLabel";
            this.numberErrorLabel.Size = new System.Drawing.Size(0, 24);
            this.numberErrorLabel.TabIndex = 19;
            // 
            // loginOrRegisterLabel
            // 
            this.loginOrRegisterLabel.AutoSize = true;
            this.loginOrRegisterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginOrRegisterLabel.Location = new System.Drawing.Point(15, 68);
            this.loginOrRegisterLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.loginOrRegisterLabel.Name = "loginOrRegisterLabel";
            this.loginOrRegisterLabel.Size = new System.Drawing.Size(310, 39);
            this.loginOrRegisterLabel.TabIndex = 0;
            this.loginOrRegisterLabel.Text = "Login Or Register:";
            // 
            // usernameRegisterErrorLabel
            // 
            this.usernameRegisterErrorLabel.AutoSize = true;
            this.usernameRegisterErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameRegisterErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.usernameRegisterErrorLabel.Location = new System.Drawing.Point(350, 11);
            this.usernameRegisterErrorLabel.Name = "usernameRegisterErrorLabel";
            this.usernameRegisterErrorLabel.Size = new System.Drawing.Size(0, 24);
            this.usernameRegisterErrorLabel.TabIndex = 20;
            // 
            // loginErrorLabel
            // 
            this.loginErrorLabel.AutoSize = true;
            this.loginErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.loginErrorLabel.Location = new System.Drawing.Point(35, 125);
            this.loginErrorLabel.Name = "loginErrorLabel";
            this.loginErrorLabel.Size = new System.Drawing.Size(0, 24);
            this.loginErrorLabel.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 64);
            this.label1.TabIndex = 21;
            this.label1.Text = "Forgot password \r\n(optional feature)";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 543);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameRegisterErrorLabel);
            this.Controls.Add(this.loginOrRegisterLabel);
            this.Controls.Add(this.numberErrorLabel);
            this.Controls.Add(this.usernameRegisterLabel);
            this.Controls.Add(this.passwordRegisterErrorLabel);
            this.Controls.Add(this.usernameLoginLabel);
            this.Controls.Add(this.emailErrorLabel);
            this.Controls.Add(this.passwordLoginLabel);
            this.Controls.Add(this.loginErrorLabel);
            this.Controls.Add(this.passwordRegisterLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.usernameLoginTextBox);
            this.Controls.Add(this.passwordRegisterTextBox);
            this.Controls.Add(this.passwordLoginTextBox);
            this.Controls.Add(this.usernameRegisterTextBox);
            this.Controls.Add(this.loginButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "mainForm";
            this.Text = "Relationship Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label usernameLoginLabel;
        private System.Windows.Forms.Label passwordLoginLabel;
        private System.Windows.Forms.Label usernameRegisterLabel;
        private System.Windows.Forms.Label passwordRegisterLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.TextBox usernameLoginTextBox;
        private System.Windows.Forms.TextBox passwordLoginTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox usernameRegisterTextBox;
        private System.Windows.Forms.TextBox passwordRegisterTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label emailErrorLabel;
        private System.Windows.Forms.Label passwordRegisterErrorLabel;
        private System.Windows.Forms.Label numberErrorLabel;
        private System.Windows.Forms.Label loginOrRegisterLabel;
        private System.Windows.Forms.Label usernameRegisterErrorLabel;
        private System.Windows.Forms.Label loginErrorLabel;
        private System.Windows.Forms.Label label1;
    }
}

