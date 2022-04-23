
namespace rmanager
{
    partial class editForm
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
            this.components = new System.ComponentModel.Container();
            this.editDataGridView = new System.Windows.Forms.DataGridView();
            this.edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editFormDataGridRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.editDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFormDataGridRecordBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // editDataGridView
            // 
            this.editDataGridView.AllowUserToAddRows = false;
            this.editDataGridView.AllowUserToResizeColumns = false;
            this.editDataGridView.AllowUserToResizeRows = false;
            this.editDataGridView.AutoGenerateColumns = false;
            this.editDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.editDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.editDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.editDataGridView.ColumnHeadersVisible = false;
            this.editDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valueDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.edit,
            this.delete});
            this.editDataGridView.DataSource = this.editFormDataGridRecordBindingSource;
            this.editDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editDataGridView.Location = new System.Drawing.Point(0, 0);
            this.editDataGridView.Name = "editDataGridView";
            this.editDataGridView.RowHeadersVisible = false;
            this.editDataGridView.RowHeadersWidth = 51;
            this.editDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.editDataGridView.RowTemplate.Height = 24;
            this.editDataGridView.Size = new System.Drawing.Size(653, 450);
            this.editDataGridView.TabIndex = 0;
            this.editDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.editDataGridView_CellClick);
            this.editDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.editDataGridView_DataBindingComplete);
            // 
            // edit
            // 
            this.edit.HeaderText = "Edit Row";
            this.edit.MinimumWidth = 6;
            this.edit.Name = "edit";
            this.edit.ReadOnly = true;
            this.edit.Text = "Edit";
            // 
            // delete
            // 
            this.delete.HeaderText = "Delete Row";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Delete";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // editFormDataGridRecordBindingSource
            // 
            this.editFormDataGridRecordBindingSource.DataSource = typeof(rmanager.editFormDataGridRecord);
            // 
            // editForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 450);
            this.Controls.Add(this.editDataGridView);
            this.Name = "editForm";
            this.Text = "Edit Form";
            ((System.ComponentModel.ISupportInitialize)(this.editDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editFormDataGridRecordBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView editDataGridView;
        private System.Windows.Forms.BindingSource editFormDataGridRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn edit;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}