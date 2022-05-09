
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
            this.addMeetingDate = new System.Windows.Forms.MonthCalendar();
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
            this.timeLabel = new System.Windows.Forms.Label();
            this.columnLabel = new System.Windows.Forms.Label();
            this.addMeetingMinute = new System.Windows.Forms.ComboBox();
            this.addMeetingHour = new System.Windows.Forms.ComboBox();
            this.resetValues = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(16, 48);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(83, 32);
            this.dateLabel.TabIndex = 1;
            this.dateLabel.Text = "Date:";
            // 
            // addMeetingDate
            // 
            this.addMeetingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addMeetingDate.Location = new System.Drawing.Point(22, 83);
            this.addMeetingDate.MaxSelectionCount = 1;
            this.addMeetingDate.Name = "addMeetingDate";
            this.addMeetingDate.TabIndex = 2;
            // 
            // acquaintanceLabel
            // 
            this.acquaintanceLabel.AutoSize = true;
            this.acquaintanceLabel.Location = new System.Drawing.Point(269, 49);
            this.acquaintanceLabel.Name = "acquaintanceLabel";
            this.acquaintanceLabel.Size = new System.Drawing.Size(197, 32);
            this.acquaintanceLabel.TabIndex = 3;
            this.acquaintanceLabel.Text = "Acquaintance:";
            // 
            // acquaintancesDropDown
            // 
            this.acquaintancesDropDown.FormattingEnabled = true;
            this.acquaintancesDropDown.Location = new System.Drawing.Point(275, 84);
            this.acquaintancesDropDown.Name = "acquaintancesDropDown";
            this.acquaintancesDropDown.Size = new System.Drawing.Size(372, 39);
            this.acquaintancesDropDown.TabIndex = 4;
            // 
            // locationsDropDown
            // 
            this.locationsDropDown.FormattingEnabled = true;
            this.locationsDropDown.Location = new System.Drawing.Point(275, 170);
            this.locationsDropDown.Name = "locationsDropDown";
            this.locationsDropDown.Size = new System.Drawing.Size(372, 39);
            this.locationsDropDown.TabIndex = 6;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(269, 135);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(132, 32);
            this.locationLabel.TabIndex = 5;
            this.locationLabel.Text = "Location:";
            // 
            // reasonsDropDown
            // 
            this.reasonsDropDown.FormattingEnabled = true;
            this.reasonsDropDown.Location = new System.Drawing.Point(275, 258);
            this.reasonsDropDown.Name = "reasonsDropDown";
            this.reasonsDropDown.Size = new System.Drawing.Size(372, 39);
            this.reasonsDropDown.TabIndex = 8;
            // 
            // reasonLabel
            // 
            this.reasonLabel.AutoSize = true;
            this.reasonLabel.Location = new System.Drawing.Point(269, 223);
            this.reasonLabel.Name = "reasonLabel";
            this.reasonLabel.Size = new System.Drawing.Size(113, 32);
            this.reasonLabel.TabIndex = 7;
            this.reasonLabel.Text = "Reason";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(16, 301);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(159, 32);
            this.commentsLabel.TabIndex = 9;
            this.commentsLabel.Text = "Comments:";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Location = new System.Drawing.Point(22, 336);
            this.commentsTextBox.Multiline = true;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(697, 179);
            this.commentsTextBox.TabIndex = 10;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(589, 529);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(130, 48);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Cancel";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(440, 529);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(130, 48);
            this.addButton.TabIndex = 12;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // mainLabel
            // 
            this.mainLabel.AutoSize = true;
            this.mainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainLabel.Location = new System.Drawing.Point(16, 10);
            this.mainLabel.Name = "mainLabel";
            this.mainLabel.Size = new System.Drawing.Size(220, 38);
            this.mainLabel.TabIndex = 13;
            this.mainLabel.Text = "Add Meeting:";
            // 
            // acquaintancesDropDownEditButton
            // 
            this.acquaintancesDropDownEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acquaintancesDropDownEditButton.Location = new System.Drawing.Point(653, 83);
            this.acquaintancesDropDownEditButton.Name = "acquaintancesDropDownEditButton";
            this.acquaintancesDropDownEditButton.Size = new System.Drawing.Size(66, 36);
            this.acquaintancesDropDownEditButton.TabIndex = 17;
            this.acquaintancesDropDownEditButton.Text = "Edit";
            this.acquaintancesDropDownEditButton.UseVisualStyleBackColor = true;
            // 
            // locationsDropDownEditButton
            // 
            this.locationsDropDownEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationsDropDownEditButton.Location = new System.Drawing.Point(653, 169);
            this.locationsDropDownEditButton.Name = "locationsDropDownEditButton";
            this.locationsDropDownEditButton.Size = new System.Drawing.Size(66, 36);
            this.locationsDropDownEditButton.TabIndex = 18;
            this.locationsDropDownEditButton.Text = "Edit";
            this.locationsDropDownEditButton.UseVisualStyleBackColor = true;
            // 
            // reasonsDropDownEditButton
            // 
            this.reasonsDropDownEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasonsDropDownEditButton.Location = new System.Drawing.Point(653, 257);
            this.reasonsDropDownEditButton.Name = "reasonsDropDownEditButton";
            this.reasonsDropDownEditButton.Size = new System.Drawing.Size(66, 36);
            this.reasonsDropDownEditButton.TabIndex = 19;
            this.reasonsDropDownEditButton.Text = "Edit";
            this.reasonsDropDownEditButton.UseVisualStyleBackColor = true;
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(16, 261);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(86, 32);
            this.timeLabel.TabIndex = 27;
            this.timeLabel.Text = "Time:";
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Location = new System.Drawing.Point(135, 257);
            this.columnLabel.Margin = new System.Windows.Forms.Padding(0);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(23, 32);
            this.columnLabel.TabIndex = 26;
            this.columnLabel.Text = ":";
            // 
            // addMeetingMinute
            // 
            this.addMeetingMinute.FormattingEnabled = true;
            this.addMeetingMinute.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.addMeetingMinute.Location = new System.Drawing.Point(153, 257);
            this.addMeetingMinute.Name = "addMeetingMinute";
            this.addMeetingMinute.Size = new System.Drawing.Size(50, 39);
            this.addMeetingMinute.TabIndex = 25;
            // 
            // addMeetingHour
            // 
            this.addMeetingHour.FormattingEnabled = true;
            this.addMeetingHour.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.addMeetingHour.Location = new System.Drawing.Point(85, 257);
            this.addMeetingHour.Name = "addMeetingHour";
            this.addMeetingHour.Size = new System.Drawing.Size(50, 39);
            this.addMeetingHour.TabIndex = 24;
            // 
            // resetValues
            // 
            this.resetValues.AutoSize = true;
            this.resetValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetValues.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.resetValues.Location = new System.Drawing.Point(595, 21);
            this.resetValues.Name = "resetValues";
            this.resetValues.Size = new System.Drawing.Size(128, 25);
            this.resetValues.TabIndex = 28;
            this.resetValues.TabStop = true;
            this.resetValues.Text = "Reset Values";
            this.resetValues.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.resetValues_LinkClicked);
            // 
            // addMeetingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 590);
            this.Controls.Add(this.resetValues);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.columnLabel);
            this.Controls.Add(this.addMeetingMinute);
            this.Controls.Add(this.addMeetingHour);
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
            this.Controls.Add(this.addMeetingDate);
            this.Controls.Add(this.dateLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "addMeetingForm";
            this.Text = "Add Meeting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.MonthCalendar addMeetingDate;
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
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.ComboBox addMeetingMinute;
        private System.Windows.Forms.ComboBox addMeetingHour;
        private System.Windows.Forms.LinkLabel resetValues;
    }
}