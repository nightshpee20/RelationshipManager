
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
            ((System.ComponentModel.ISupportInitialize)(this.acquaintancesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addAcquaintanceButton
            // 
            this.addAcquaintanceButton.Location = new System.Drawing.Point(566, 433);
            this.addAcquaintanceButton.Margin = new System.Windows.Forms.Padding(6);
            this.addAcquaintanceButton.Name = "addAcquaintanceButton";
            this.addAcquaintanceButton.Size = new System.Drawing.Size(185, 68);
            this.addAcquaintanceButton.TabIndex = 0;
            this.addAcquaintanceButton.Text = "Add New";
            this.addAcquaintanceButton.UseVisualStyleBackColor = true;
            this.addAcquaintanceButton.Click += new System.EventHandler(this.addAcquaintanceButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(372, 433);
            this.returnButton.Margin = new System.Windows.Forms.Padding(6);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(185, 68);
            this.returnButton.TabIndex = 1;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // acquaintancesDataGridView
            // 
            this.acquaintancesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.acquaintancesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.acquaintancesDataGridView.Name = "acquaintancesDataGridView";
            this.acquaintancesDataGridView.RowHeadersWidth = 51;
            this.acquaintancesDataGridView.RowTemplate.Height = 24;
            this.acquaintancesDataGridView.Size = new System.Drawing.Size(742, 412);
            this.acquaintancesDataGridView.TabIndex = 2;
            // 
            // acquaintancesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 510);
            this.Controls.Add(this.acquaintancesDataGridView);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.addAcquaintanceButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "acquaintancesForm";
            this.Text = "Acquaintances";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.acquaintancesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.acquaintancesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addAcquaintanceButton;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.DataGridView acquaintancesDataGridView;
    }
}