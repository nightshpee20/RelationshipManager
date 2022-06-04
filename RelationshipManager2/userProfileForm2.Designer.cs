
namespace rmanager
{
    partial class userProfileForm2
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
            this.switchUserButton = new System.Windows.Forms.Button();
            this.meetingsDataGridView = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acquaintance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.meetingsLabel = new System.Windows.Forms.Label();
            this.addMeetingButton = new System.Windows.Forms.Button();
            this.browseAcquaintancesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.meetingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // switchUserButton
            // 
            this.switchUserButton.Location = new System.Drawing.Point(521, 726);
            this.switchUserButton.Name = "switchUserButton";
            this.switchUserButton.Size = new System.Drawing.Size(218, 61);
            this.switchUserButton.TabIndex = 1;
            this.switchUserButton.Text = "Switch User";
            this.switchUserButton.UseVisualStyleBackColor = true;
            this.switchUserButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // meetingsDataGridView
            // 
            this.meetingsDataGridView.AllowUserToAddRows = false;
            this.meetingsDataGridView.AllowUserToDeleteRows = false;
            this.meetingsDataGridView.AllowUserToResizeRows = false;
            this.meetingsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.meetingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.meetingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.meetingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.time,
            this.acquaintance,
            this.location,
            this.reason,
            this.comments,
            this.edit,
            this.delete});
            this.meetingsDataGridView.Location = new System.Drawing.Point(12, 70);
            this.meetingsDataGridView.Name = "meetingsDataGridView";
            this.meetingsDataGridView.ReadOnly = true;
            this.meetingsDataGridView.RowHeadersVisible = false;
            this.meetingsDataGridView.RowHeadersWidth = 51;
            this.meetingsDataGridView.RowTemplate.Height = 30;
            this.meetingsDataGridView.Size = new System.Drawing.Size(1745, 636);
            this.meetingsDataGridView.TabIndex = 3;
            this.meetingsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.meetingsDataGridView_CellClick);
            this.meetingsDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.meetingsDataGridView_DataBindingComplete);
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.date.DataPropertyName = "date";
            this.date.FillWeight = 78.74138F;
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 155;
            // 
            // time
            // 
            this.time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.time.DataPropertyName = "time";
            this.time.HeaderText = "Time";
            this.time.MinimumWidth = 6;
            this.time.Name = "time";
            this.time.ReadOnly = true;
            this.time.Width = 125;
            // 
            // acquaintance
            // 
            this.acquaintance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.acquaintance.DataPropertyName = "acquaintance";
            this.acquaintance.FillWeight = 215F;
            this.acquaintance.HeaderText = "Acquaintance";
            this.acquaintance.MinimumWidth = 6;
            this.acquaintance.Name = "acquaintance";
            this.acquaintance.ReadOnly = true;
            this.acquaintance.Width = 300;
            // 
            // location
            // 
            this.location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.location.DataPropertyName = "location";
            this.location.HeaderText = "Location";
            this.location.MinimumWidth = 6;
            this.location.Name = "location";
            this.location.ReadOnly = true;
            this.location.Width = 240;
            // 
            // reason
            // 
            this.reason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.reason.DataPropertyName = "reason";
            this.reason.FillWeight = 96.45818F;
            this.reason.HeaderText = "Reason";
            this.reason.MinimumWidth = 6;
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            this.reason.Width = 240;
            // 
            // comments
            // 
            this.comments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.comments.DataPropertyName = "comments";
            this.comments.FillWeight = 96.45818F;
            this.comments.HeaderText = "Comments";
            this.comments.MinimumWidth = 6;
            this.comments.Name = "comments";
            this.comments.ReadOnly = true;
            this.comments.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.comments.Width = 198;
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.edit.HeaderText = "";
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "Edit";
            this.edit.UseColumnTextForButtonValue = true;
            this.edit.Width = 125;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.delete.HeaderText = "";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Delete";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // meetingsLabel
            // 
            this.meetingsLabel.AutoSize = true;
            this.meetingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingsLabel.Location = new System.Drawing.Point(14, 16);
            this.meetingsLabel.Name = "meetingsLabel";
            this.meetingsLabel.Size = new System.Drawing.Size(334, 46);
            this.meetingsLabel.TabIndex = 4;
            this.meetingsLabel.Text = "Recent Meetings";
            // 
            // addMeetingButton
            // 
            this.addMeetingButton.Location = new System.Drawing.Point(22, 726);
            this.addMeetingButton.Name = "addMeetingButton";
            this.addMeetingButton.Size = new System.Drawing.Size(218, 61);
            this.addMeetingButton.TabIndex = 5;
            this.addMeetingButton.Text = "Add Meeting";
            this.addMeetingButton.UseVisualStyleBackColor = true;
            this.addMeetingButton.Click += new System.EventHandler(this.addMeetingButton_Click);
            // 
            // browseAcquaintancesButton
            // 
            this.browseAcquaintancesButton.Location = new System.Drawing.Point(273, 726);
            this.browseAcquaintancesButton.Name = "browseAcquaintancesButton";
            this.browseAcquaintancesButton.Size = new System.Drawing.Size(218, 61);
            this.browseAcquaintancesButton.TabIndex = 6;
            this.browseAcquaintancesButton.Text = "Acquaintances";
            this.browseAcquaintancesButton.UseVisualStyleBackColor = true;
            this.browseAcquaintancesButton.Click += new System.EventHandler(this.browseAcquaintancesButton_Click);
            // 
            // userProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1769, 806);
            this.Controls.Add(this.browseAcquaintancesButton);
            this.Controls.Add(this.addMeetingButton);
            this.Controls.Add(this.meetingsLabel);
            this.Controls.Add(this.meetingsDataGridView);
            this.Controls.Add(this.switchUserButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "userProfileForm";
            this.Text = "Relationship Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.meetingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button switchUserButton;
        private System.Windows.Forms.DataGridView meetingsDataGridView;
        private System.Windows.Forms.Label meetingsLabel;
        private System.Windows.Forms.Button addMeetingButton;
        private System.Windows.Forms.Button browseAcquaintancesButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn acquaintance;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}