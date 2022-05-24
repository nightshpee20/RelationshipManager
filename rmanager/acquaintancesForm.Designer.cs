
namespace rmanager
{
    partial class acquaintancesForm
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
            this.addAcquaintanceButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.acquaintancesDataGridView = new System.Windows.Forms.DataGridView();
            this.firstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.deleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.acquaintancesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.acquaintancesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addAcquaintanceButton
            // 
            this.addAcquaintanceButton.Location = new System.Drawing.Point(1128, 645);
            this.addAcquaintanceButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.addAcquaintanceButton.Name = "addAcquaintanceButton";
            this.addAcquaintanceButton.Size = new System.Drawing.Size(185, 68);
            this.addAcquaintanceButton.TabIndex = 0;
            this.addAcquaintanceButton.Text = "Add New";
            this.addAcquaintanceButton.UseVisualStyleBackColor = true;
            this.addAcquaintanceButton.Click += new System.EventHandler(this.addAcquaintanceButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(12, 645);
            this.returnButton.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(185, 68);
            this.returnButton.TabIndex = 1;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // acquaintancesDataGridView
            // 
            this.acquaintancesDataGridView.AllowUserToAddRows = false;
            this.acquaintancesDataGridView.AllowUserToDeleteRows = false;
            this.acquaintancesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acquaintancesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.acquaintancesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.acquaintancesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.acquaintancesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.acquaintancesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.firstName,
            this.lastName,
            this.gender,
            this.occupation,
            this.city,
            this.address,
            this.id,
            this.editButton,
            this.deleteButton});
            this.acquaintancesDataGridView.Location = new System.Drawing.Point(12, 76);
            this.acquaintancesDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.acquaintancesDataGridView.Name = "acquaintancesDataGridView";
            this.acquaintancesDataGridView.ReadOnly = true;
            this.acquaintancesDataGridView.RowHeadersVisible = false;
            this.acquaintancesDataGridView.RowHeadersWidth = 51;
            this.acquaintancesDataGridView.RowTemplate.Height = 30;
            this.acquaintancesDataGridView.Size = new System.Drawing.Size(1301, 561);
            this.acquaintancesDataGridView.TabIndex = 2;
            this.acquaintancesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.acquaintancesDataGridView_CellClick);
            this.acquaintancesDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.acquaintancesDataGridView_DataBindingComplete);
            // 
            // firstName
            // 
            this.firstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.firstName.DataPropertyName = "first_name";
            this.firstName.Frozen = true;
            this.firstName.HeaderText = "First Name";
            this.firstName.MinimumWidth = 6;
            this.firstName.Name = "firstName";
            this.firstName.ReadOnly = true;
            this.firstName.Width = 144;
            // 
            // lastName
            // 
            this.lastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lastName.DataPropertyName = "last_name";
            this.lastName.Frozen = true;
            this.lastName.HeaderText = "Last Name";
            this.lastName.MinimumWidth = 6;
            this.lastName.Name = "lastName";
            this.lastName.ReadOnly = true;
            this.lastName.Width = 144;
            // 
            // gender
            // 
            this.gender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.gender.DataPropertyName = "gender";
            this.gender.Frozen = true;
            this.gender.HeaderText = "Gender";
            this.gender.MinimumWidth = 6;
            this.gender.Name = "gender";
            this.gender.ReadOnly = true;
            this.gender.Width = 125;
            // 
            // occupation
            // 
            this.occupation.DataPropertyName = "occupation";
            this.occupation.HeaderText = "Occupation";
            this.occupation.MinimumWidth = 6;
            this.occupation.Name = "occupation";
            this.occupation.ReadOnly = true;
            // 
            // city
            // 
            this.city.DataPropertyName = "city";
            this.city.HeaderText = "City";
            this.city.MinimumWidth = 6;
            this.city.Name = "city";
            this.city.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "Address";
            this.address.MinimumWidth = 6;
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "relationship";
            this.id.HeaderText = "Relationship";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // editButton
            // 
            this.editButton.HeaderText = "";
            this.editButton.MinimumWidth = 6;
            this.editButton.Name = "editButton";
            this.editButton.ReadOnly = true;
            this.editButton.Text = "Edit";
            this.editButton.UseColumnTextForButtonValue = true;
            // 
            // deleteButton
            // 
            this.deleteButton.HeaderText = "";
            this.deleteButton.MinimumWidth = 6;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.ReadOnly = true;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseColumnTextForButtonValue = true;
            // 
            // acquaintancesLabel
            // 
            this.acquaintancesLabel.AutoSize = true;
            this.acquaintancesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acquaintancesLabel.Location = new System.Drawing.Point(12, 18);
            this.acquaintancesLabel.Name = "acquaintancesLabel";
            this.acquaintancesLabel.Size = new System.Drawing.Size(396, 46);
            this.acquaintancesLabel.TabIndex = 5;
            this.acquaintancesLabel.Text = "Your Acquaintances";
            // 
            // acquaintancesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 728);
            this.Controls.Add(this.acquaintancesLabel);
            this.Controls.Add(this.acquaintancesDataGridView);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.addAcquaintanceButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.Name = "acquaintancesForm";
            this.Text = "Acquaintances";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquaintancesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.acquaintancesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addAcquaintanceButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.DataGridView acquaintancesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn occupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewButtonColumn editButton;
        private System.Windows.Forms.DataGridViewButtonColumn deleteButton;
        private System.Windows.Forms.Label acquaintancesLabel;
    }
}