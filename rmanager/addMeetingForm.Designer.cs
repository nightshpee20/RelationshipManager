
namespace rmanager
{
    partial class addMeetingForm
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
            this.dateLabel = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.acquaintanceLabel = new System.Windows.Forms.Label();
            this.acquaintancesDropDown = new System.Windows.Forms.ComboBox();
            this.locationsDropDown = new System.Windows.Forms.ComboBox();
            this.locationLabel = new System.Windows.Forms.Label();
            this.reasonsDropDown = new System.Windows.Forms.ComboBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.commentsTextBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.mainLabel = new System.Windows.Forms.Label();
            this.acquaintancesDropDownEditButton = new System.Windows.Forms.Button();
            this.locationsDropDownEditButton = new System.Windows.Forms.Button();
            this.reasonsDropDownEditButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(16, 72);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(83, 32);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Date:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(22, 107);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 2;
            // 
            // acquaintanceLabel
            // 
            this.acquaintanceLabel.AutoSize = true;
            this.acquaintanceLabel.Location = new System.Drawing.Point(269, 72);
            this.acquaintanceLabel.Name = "acquaintanceLabel";
            this.acquaintanceLabel.Size = new System.Drawing.Size(197, 32);
            this.acquaintanceLabel.TabIndex = 3;
            this.acquaintanceLabel.Text = "Acquaintance:";
            // 
            // acquaintancesDropDown
            // 
            this.acquaintancesDropDown.FormattingEnabled = true;
            this.acquaintancesDropDown.Location = new System.Drawing.Point(275, 107);
            this.acquaintancesDropDown.Name = "acquaintancesDropDown";
            this.acquaintancesDropDown.Size = new System.Drawing.Size(372, 39);
            this.acquaintancesDropDown.TabIndex = 4;
            // 
            // locationsDropDown
            // 
            this.locationsDropDown.FormattingEnabled = true;
            this.locationsDropDown.Location = new System.Drawing.Point(275, 190);
            this.locationsDropDown.Name = "locationsDropDown";
            this.locationsDropDown.Size = new System.Drawing.Size(372, 39);
            this.locationsDropDown.TabIndex = 6;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(269, 155);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(132, 32);
            this.locationLabel.TabIndex = 5;
            this.locationLabel.Text = "Location:";
            // 
            // reasonsDropDown
            // 
            this.reasonsDropDown.FormattingEnabled = true;
            this.reasonsDropDown.Location = new System.Drawing.Point(275, 275);
            this.reasonsDropDown.Name = "reasonsDropDown";
            this.reasonsDropDown.Size = new System.Drawing.Size(372, 39);
            this.reasonsDropDown.TabIndex = 8;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(269, 240);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(113, 32);
            this.reasonLabel.TabIndex = 7;
            this.reasonLabel.Text = "Reason";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(16, 304);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(159, 32);
            this.commentsLabel.TabIndex = 9;
            this.commentsLabel.Text = "Comments:";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Location = new System.Drawing.Point(22, 339);
            this.commentsTextBox.Multiline = true;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(697, 179);
            this.commentsTextBox.TabIndex = 10;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(589, 533);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(130, 48);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Cancel";
            this.exitButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(440, 533);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(130, 48);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(16, 16);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(220, 38);
            this.mainLabel.TabIndex = 13;
            this.mainLabel.Text = "Add Meeting:";
            // 
            // acquaintancesDropDownEditButton
            // 
            this.acquaintancesDropDownEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acquaintancesDropDownEditButton.Location = new System.Drawing.Point(653, 106);
            this.acquaintancesDropDownEditButton.Name = "acquaintancesDropDownEditButton";
            this.acquaintancesDropDownEditButton.Size = new System.Drawing.Size(66, 36);
            this.acquaintancesDropDownEditButton.TabIndex = 17;
            this.acquaintancesDropDownEditButton.Text = "Edit";
            this.acquaintancesDropDownEditButton.UseVisualStyleBackColor = true;
            // 
            // locationsDropDownEditButton
            // 
            this.locationsDropDownEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationsDropDownEditButton.Location = new System.Drawing.Point(653, 189);
            this.locationsDropDownEditButton.Name = "locationsDropDownEditButton";
            this.locationsDropDownEditButton.Size = new System.Drawing.Size(66, 36);
            this.locationsDropDownEditButton.TabIndex = 18;
            this.locationsDropDownEditButton.Text = "Edit";
            this.locationsDropDownEditButton.UseVisualStyleBackColor = true;
            // 
            // reasonsDropDownEditButton
            // 
            this.reasonsDropDownEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasonsDropDownEditButton.Location = new System.Drawing.Point(653, 274);
            this.reasonsDropDownEditButton.Name = "reasonsDropDownEditButton";
            this.reasonsDropDownEditButton.Size = new System.Drawing.Size(66, 36);
            this.reasonsDropDownEditButton.TabIndex = 19;
            this.reasonsDropDownEditButton.Text = "Edit";
            this.reasonsDropDownEditButton.UseVisualStyleBackColor = true;
            // 
            // addMeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 598);
            this.Controls.Add(this.reasonsDropDownEditButton);
            this.Controls.Add(this.locationsDropDownEditButton);
            this.Controls.Add(this.acquaintancesDropDownEditButton);
            this.Controls.Add(this.mainLabel);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.commentsTextBox);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.reasonsDropDown);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.locationsDropDown);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.acquaintancesDropDown);
            this.Controls.Add(this.acquaintanceLabel);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.dateLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "addMeetingForm";
            this.Text = "Add Meeting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label acquaintanceLabel;
        private System.Windows.Forms.ComboBox acquaintancesDropDown;
        private System.Windows.Forms.ComboBox locationsDropDown;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.ComboBox reasonsDropDown;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox commentsTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label mainLabel;
        private System.Windows.Forms.Button acquaintancesDropDownEditButton;
        private System.Windows.Forms.Button locationsDropDownEditButton;
        private System.Windows.Forms.Button reasonsDropDownEditButton;
    }
}