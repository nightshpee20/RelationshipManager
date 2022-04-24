using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rmanager
{
    public partial class editForm : Form
    {
        private int user_id;
        private string name;
        private string column_name;
        public editForm(string name, int user_id)
        {
            InitializeComponent();
            this.Text = Utilities.CapitalizeFirstLetters($"{name} Edit Form");
            this.user_id = user_id;
            this.name = name;
            switch(name)
            {
                case "cities":
                    column_name = "city";
                    break;
                case "occupations":
                    column_name = "occupation";
                    break;
                case "relationships":
                    column_name = "relationship";
                    break;
            }
            setDataGridValues(name);
            editDataGridView.Height = 179;
            this.Height = 218;
        }
        
        private void setDataGridValues(string name)
        {
            MySqlDataAdapter da = new MySqlDataAdapter();
            switch(name)
            {
                case "cities":
                    da = new MySqlDataAdapter($"SELECT c.city, c.id, uc.user_id " +
                                              $"FROM user_cities uc " +
                                              $"JOIN cities c ON uc.city_id = c.id " +
                                              $"WHERE user_id = {user_id} " +
                                              $"ORDER BY c.city ASC;", Connect.con);
                    break;

                case "occupations":
                    da = new MySqlDataAdapter($"SELECT o.occupation, o.id, uo.user_id " +
                                              $"FROM user_occupations uo " +
                                              $"JOIN occupations o ON uo.occupation_id = o.id " +
                                              $"WHERE user_id = {user_id} " +
                                              $"ORDER BY o.occupation ASC;", Connect.con);
                    break;

                case "relationships":
                    da = new MySqlDataAdapter($"SELECT r.relationship, r.id, ur.user_id " +
                                              $"FROM user_relationships ur " +
                                              $"JOIN relationships r ON ur.relationship_id = r.id " +
                                              $"WHERE user_id = {user_id} " +
                                              $"ORDER BY r.relationship ASC;", Connect.con);
                    break;

            }
            
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
       
            da.Fill(ds, name);
            dt = ds.Tables[name];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                editFormDataGridRecordBindingSource.Add(new editFormDataGridRecord()
                {
                    Id = (int)dt.Rows[i]["id"],
                    Value = Utilities.CapitalizeFirstLetters((string)dt.Rows[i][column_name])
                });
            }

            editFormDataGridRecordBindingSource.Add(new editFormDataGridRecord()
            {
                Id = dt.Rows.Count,
                Value = ""
            });  
        }
        //editDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()
        private void editDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string message = string.Empty;
            switch(name)
            {
                case "cities":
                    message = "Everything referencing this city (Acquaintances, Meetings, Locations) will be deleted as well! Are you sure you wish to continue?";
                    break;
                case "occupations":
                    message = "Everything referencing this occupation (Acquaintances, Meetings(indirectly through acquaintances)) will be deleted as well! Are you sure you wish to continue?";
                    break;
                case "relationships":
                    message = "Everything referencing this relationship (Acquaintances) will be deleted as well! Are you sure you wish to continue?";
                    break;
            }

            int city_id = (int) editDataGridView.Rows[e.RowIndex].Cells[1].Value;
            if (e.ColumnIndex == 3)
            {
                if(editDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Delete")
                { 
                    if (MessageBox.Show(message,
                                       "WARNING!",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Utilities.MySqlCommandImproved($"DELETE FROM user_{name} WHERE user_id = {user_id} AND {column_name}_id = {city_id}");
                        editDataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }else
                {
                    this.Close();
                }
                
            }
            Point pt = Cursor.Position;
            MessageBox.Show(pt.X + " " + pt.Y);
        }

        private void editDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < editDataGridView.Rows.Count - 1; i++)
            {
                editDataGridView.Rows[i].Cells[2].Value = "Edit";
                editDataGridView.Rows[i].Cells[3].Value = "Delete";
            }
            editDataGridView.Rows[editDataGridView.Rows.Count - 1].Cells[0].ReadOnly = false;
            editDataGridView.Rows[editDataGridView.Rows.Count - 1].Cells[2].Value = "Add New";
            editDataGridView.Rows[editDataGridView.Rows.Count - 1].Cells[3].Value = "Exit";
        }

        private void editDataGridView_MouseHover(object sender, EventArgs e)
        {
            
            //MessageBox.Show(GetChildAtPoint(Cursor.Position).ToString());
        }
    }
}
