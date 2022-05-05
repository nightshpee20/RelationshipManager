
namespace rmanager
{
    partial class userProfileForm
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
            this.meetingsLabel = new System.Windows.Forms.Label();
            this.browseMeetingsButton = new System.Windows.Forms.Button();
            this.browseAcquaintancesButton = new System.Windows.Forms.Button();
            this.userStatsButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acquaintance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.meetingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // switchUserButton
            // 
            this.switchUserButton.Location = new System.Drawing.Point(1265, 487);
            this.switchUserButton.Name = "switchUserButton";
            this.switchUserButton.Size = new System.Drawing.Size(219, 61);
            this.switchUserButton.TabIndex = 1;
            this.switchUserButton.Text = "Switch User";
            this.switchUserButton.UseVisualStyleBackColor = true;
            this.switchUserButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // meetingsDataGridView
            // 
            this.meetingsDataGridView.AllowUserToAddRows = false;
            this.meetingsDataGridView.AllowUserToDeleteRows = false;
            this.meetingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.meetingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.meetingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.acquaintance,
            this.location,
            this.reason,
            this.comments,
            this.edit,
            this.delete});
            this.meetingsDataGridView.Location = new System.Drawing.Point(53, 91);
            this.meetingsDataGridView.Name = "meetingsDataGridView";
            this.meetingsDataGridView.ReadOnly = true;
            this.meetingsDataGridView.RowHeadersVisible = false;
            this.meetingsDataGridView.RowHeadersWidth = 51;
            this.meetingsDataGridView.RowTemplate.Height = 30;
            this.meetingsDataGridView.Size = new System.Drawing.Size(1193, 457);
            this.meetingsDataGridView.TabIndex = 3;
            this.meetingsDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.meetingsDataGridView_DataBindingComplete);
            // 
            // meetingsLabel
            // 
            this.meetingsLabel.AutoSize = true;
            this.meetingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingsLabel.Location = new System.Drawing.Point(45, 22);
            this.meetingsLabel.Name = "meetingsLabel";
            this.meetingsLabel.Size = new System.Drawing.Size(334, 46);
            this.meetingsLabel.TabIndex = 4;
            this.meetingsLabel.Text = "Recent Meetings";
            // 
            // browseMeetingsButton
            // 
            this.browseMeetingsButton.Location = new System.Drawing.Point(1265, 91);
            this.browseMeetingsButton.Name = "browseMeetingsButton";
            this.browseMeetingsButton.Size = new System.Drawing.Size(219, 61);
            this.browseMeetingsButton.TabIndex = 5;
            this.browseMeetingsButton.Text = "All Meetings";
            this.browseMeetingsButton.UseVisualStyleBackColor = true;
            // 
            // browseAcquaintancesButton
            // 
            this.browseAcquaintancesButton.Location = new System.Drawing.Point(1265, 190);
            this.browseAcquaintancesButton.Name = "browseAcquaintancesButton";
            this.browseAcquaintancesButton.Size = new System.Drawing.Size(219, 61);
            this.browseAcquaintancesButton.TabIndex = 6;
            this.browseAcquaintancesButton.Text = "Acquaintances";
            this.browseAcquaintancesButton.UseVisualStyleBackColor = true;
            this.browseAcquaintancesButton.Click += new System.EventHandler(this.browseAcquaintancesButton_Click);
            // 
            // userStatsButton
            // 
            this.userStatsButton.Location = new System.Drawing.Point(1265, 289);
            this.userStatsButton.Name = "userStatsButton";
            this.userStatsButton.Size = new System.Drawing.Size(219, 61);
            this.userStatsButton.TabIndex = 7;
            this.userStatsButton.Text = "User Stats";
            this.userStatsButton.UseVisualStyleBackColor = true;
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(1265, 388);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(219, 61);
            this.helpButton.TabIndex = 8;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.date.DataPropertyName = "date";
            this.date.FillWeight = 78.74138F;
            this.date.Frozen = true;
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 155;
            // 
            // acquaintance
            // 
            this.acquaintance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.acquaintance.DataPropertyName = "acquaintance";
            this.acquaintance.FillWeight = 128.3422F;
            this.acquaintance.Frozen = true;
            this.acquaintance.HeaderText = "Acquaintance";
            this.acquaintance.MinimumWidth = 6;
            this.acquaintance.Name = "acquaintance";
            this.acquaintance.ReadOnly = true;
            this.acquaintance.Width = 215;
            // 
            // location
            // 
            this.location.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.location.DataPropertyName = "location";
            this.location.Frozen = true;
            this.location.HeaderText = "Location";
            this.location.MinimumWidth = 6;
            this.location.Name = "location";
            this.location.ReadOnly = true;
            this.location.Width = 190;
            // 
            // reason
            // 
            this.reason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.reason.DataPropertyName = "reason";
            this.reason.FillWeight = 96.45818F;
            this.reason.Frozen = true;
            this.reason.HeaderText = "Reason";
            this.reason.MinimumWidth = 6;
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            this.reason.Width = 185;
            // 
            // comments
            // 
            this.comments.DataPropertyName = "comments";
            this.comments.FillWeight = 96.45818F;
            this.comments.HeaderText = "Comments";
            this.comments.MinimumWidth = 6;
            this.comments.Name = "comments";
            this.comments.ReadOnly = true;
            this.comments.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // edit
            // 
            this.edit.HeaderText = "";
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "Edit";
            this.edit.UseColumnTextForButtonValue = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Delete";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // userProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1496, 651);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.userStatsButton);
            this.Controls.Add(this.browseAcquaintancesButton);
            this.Controls.Add(this.browseMeetingsButton);
            this.Controls.Add(this.meetingsLabel);
            this.Controls.Add(this.meetingsDataGridView);
            this.Controls.Add(this.switchUserButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "userProfileForm";
            this.Text = "Relationship Manager";
            ((System.ComponentModel.ISupportInitialize)(this.meetingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button switchUserButton;
        private System.Windows.Forms.DataGridView meetingsDataGridView;
        private System.Windows.Forms.Label meetingsLabel;
        private System.Windows.Forms.Button browseMeetingsButton;
        private System.Windows.Forms.Button browseAcquaintancesButton;
        private System.Windows.Forms.Button userStatsButton;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn acquaintance;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}