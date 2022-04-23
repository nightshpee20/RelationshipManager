
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
            this.getUserInfoBUtton = new System.Windows.Forms.Button();
            this.meetingsDataGridView = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acquaintance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.meetingsLabel = new System.Windows.Forms.Label();
            this.browseMeetingsButton = new System.Windows.Forms.Button();
            this.browseAcquaintancesButton = new System.Windows.Forms.Button();
            this.userStatsButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.meetingsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // switchUserButton
            // 
            this.switchUserButton.Location = new System.Drawing.Point(848, 487);
            this.switchUserButton.Name = "switchUserButton";
            this.switchUserButton.Size = new System.Drawing.Size(219, 61);
            this.switchUserButton.TabIndex = 1;
            this.switchUserButton.Text = "Switch User";
            this.switchUserButton.UseVisualStyleBackColor = true;
            this.switchUserButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // getUserInfoBUtton
            // 
            this.getUserInfoBUtton.Location = new System.Drawing.Point(173, 564);
            this.getUserInfoBUtton.Name = "getUserInfoBUtton";
            this.getUserInfoBUtton.Size = new System.Drawing.Size(197, 67);
            this.getUserInfoBUtton.TabIndex = 2;
            this.getUserInfoBUtton.Text = "Get User Info";
            this.getUserInfoBUtton.UseVisualStyleBackColor = true;
            this.getUserInfoBUtton.Visible = false;
            this.getUserInfoBUtton.Click += new System.EventHandler(this.getUserInfoBUtton_Click);
            // 
            // meetingsDataGridView
            // 
            this.meetingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.meetingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.meetingsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this.acquaintance,
            this.reason,
            this.comments});
            this.meetingsDataGridView.Location = new System.Drawing.Point(53, 91);
            this.meetingsDataGridView.Name = "meetingsDataGridView";
            this.meetingsDataGridView.RowHeadersWidth = 51;
            this.meetingsDataGridView.RowTemplate.Height = 24;
            this.meetingsDataGridView.Size = new System.Drawing.Size(742, 457);
            this.meetingsDataGridView.TabIndex = 3;
            // 
            // date
            // 
            this.date.FillWeight = 78.74138F;
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 6;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // acquaintance
            // 
            this.acquaintance.FillWeight = 128.3422F;
            this.acquaintance.HeaderText = "Acquaintance";
            this.acquaintance.MinimumWidth = 6;
            this.acquaintance.Name = "acquaintance";
            this.acquaintance.ReadOnly = true;
            // 
            // reason
            // 
            this.reason.FillWeight = 96.45818F;
            this.reason.HeaderText = "Reason";
            this.reason.MinimumWidth = 6;
            this.reason.Name = "reason";
            this.reason.ReadOnly = true;
            // 
            // comments
            // 
            this.comments.FillWeight = 96.45818F;
            this.comments.HeaderText = "Comments";
            this.comments.MinimumWidth = 6;
            this.comments.Name = "comments";
            this.comments.ReadOnly = true;
            this.comments.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.browseMeetingsButton.Location = new System.Drawing.Point(848, 91);
            this.browseMeetingsButton.Name = "browseMeetingsButton";
            this.browseMeetingsButton.Size = new System.Drawing.Size(219, 61);
            this.browseMeetingsButton.TabIndex = 5;
            this.browseMeetingsButton.Text = "All Meetings";
            this.browseMeetingsButton.UseVisualStyleBackColor = true;
            // 
            // browseAcquaintancesButton
            // 
            this.browseAcquaintancesButton.Location = new System.Drawing.Point(848, 190);
            this.browseAcquaintancesButton.Name = "browseAcquaintancesButton";
            this.browseAcquaintancesButton.Size = new System.Drawing.Size(219, 61);
            this.browseAcquaintancesButton.TabIndex = 6;
            this.browseAcquaintancesButton.Text = "Acquaintances";
            this.browseAcquaintancesButton.UseVisualStyleBackColor = true;
            this.browseAcquaintancesButton.Click += new System.EventHandler(this.browseAcquaintancesButton_Click);
            // 
            // userStatsButton
            // 
            this.userStatsButton.Location = new System.Drawing.Point(848, 289);
            this.userStatsButton.Name = "userStatsButton";
            this.userStatsButton.Size = new System.Drawing.Size(219, 61);
            this.userStatsButton.TabIndex = 7;
            this.userStatsButton.Text = "User Stats";
            this.userStatsButton.UseVisualStyleBackColor = true;
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(848, 388);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(219, 61);
            this.helpButton.TabIndex = 8;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // userProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 651);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.userStatsButton);
            this.Controls.Add(this.browseAcquaintancesButton);
            this.Controls.Add(this.browseMeetingsButton);
            this.Controls.Add(this.meetingsLabel);
            this.Controls.Add(this.meetingsDataGridView);
            this.Controls.Add(this.getUserInfoBUtton);
            this.Controls.Add(this.switchUserButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "userProfile";
            this.Text = "Relationship Manager";
            ((System.ComponentModel.ISupportInitialize)(this.meetingsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button switchUserButton;
        private System.Windows.Forms.Button getUserInfoBUtton;
        private System.Windows.Forms.DataGridView meetingsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn acquaintance;
        private System.Windows.Forms.DataGridViewTextBoxColumn reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn comments;
        private System.Windows.Forms.Label meetingsLabel;
        private System.Windows.Forms.Button browseMeetingsButton;
        private System.Windows.Forms.Button browseAcquaintancesButton;
        private System.Windows.Forms.Button userStatsButton;
        private System.Windows.Forms.Button helpButton;
    }
}