using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace rmanager
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        //Clears the Login text boxes.
        private void ResetLogin()
        {
            usernameLoginTextBox.Text = "";
            passwordLoginTextBox.Text = "";
        }
        
        //Clears the Register text boxes.
        //TODO: In the event of invalid register data make it so only the password disappears and maybe the data in the wrong field.
        private void ResetRegister()
        {
            usernameRegisterTextBox.Text = "";
            passwordRegisterTextBox.Text = "";
            emailTextBox.Text = "";
            numberTextBox.Text = "";
        }
        
        //Clears the error labels
        private void ResetErrors()
        {
            loginErrorLabel.Text = "";
            usernameRegisterErrorLabel.Text = "";
            passwordRegisterErrorLabel.Text = "";
            emailErrorLabel.Text = "";
            numberErrorLabel.Text = "";
        }
        private void registerButton_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand($"CALL sp_insertUser({usernameRegisterTextBox.Text}, " +
                                                                   $"{passwordRegisterTextBox.Text}, " +
                                                                   $"{emailTextBox.Text}, " +
                                                                   $"{numberTextBox.Text});",Connect.con);
            ResetErrors();
            if(DataValidation.ValidateRegisterData(usernameRegisterTextBox, passwordRegisterTextBox, emailTextBox, numberTextBox,
                                    usernameRegisterErrorLabel, passwordRegisterErrorLabel, emailErrorLabel, numberErrorLabel))
            {
                try
                {
                    Connect.con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You have registered successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Connect.con.Close();
                }
            }
            ResetRegister();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Calls the data validation method which assigns the id of the user profile to a variable.
            // If the method returns "-1", the login credentials are invalid.
            int user_id = DataValidation.ValidateLoginData(usernameLoginTextBox, passwordLoginTextBox);

            if (user_id == -1)
            {
                loginErrorLabel.Text = "Wrong login info!";
                ResetLogin();
            }
            else 
            {
                this.Hide();
                userProfileForm user = new userProfileForm(this, user_id);
                user.Show();
            }
        }
    }
}
