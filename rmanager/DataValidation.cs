using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace rmanager
{
    public static class DataValidation
    {
        //Check if the entered username and password are a match for an account. 
        public static int ValidateLoginData(TextBox username, TextBox password)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT id, username, password FROM users;", Connect.con);
            Connect.con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (username.Text == dr[1].ToString() && password.Text == dr[2].ToString())
                {
                    int id = int.Parse(dr[0].ToString());
                    Connect.con.Close();
                    return id;
                }
            }
            Connect.con.Close();

            return -1;
        }
       
        //Validates the data from the register form.
        public static bool ValidateRegisterData(TextBox username, TextBox password, TextBox email, TextBox number,
                                 Label usernameError, Label passwordError, Label emailError, Label numberError)
        {
            //Checks if any of the fields have no value.
            if (username.Text == "")
            {
                usernameError.Text = "This field is mandatory!";
                return false;
            }
            if (password.Text == "")
            {
                passwordError.Text = "This field is mandatory!";
                return false;
            }
            if (email.Text == "")
            {
                emailError.Text = "This field is mandatory!";
                return false;
            }
            if (number.Text == "")
            {
                numberError.Text = "This field is mandatory!";
                return false;
            }

            //Checks if the username exceeds 30 characters.
            if (username.Text.Length > 30)
            {
                usernameError.Text = "Username must be less than 30 characters!";
                return false;
            }

            //Checks if the username is less than 8 characters.
            if (username.Text.Length < 8)
            {
                usernameError.Text = "Username cannot be less than 8 characters!";
                return false;
            }

            //Checks if the username begins with a number or a dot.
            switch (username.Text[0])
            {
                case '0':case '1':case '2':case '3':case '4':
                case '5':case '6':case '7':case '8':case '9':
                    usernameError.Text = "The username cannot begin with a number!";
                    return false;
                case '.':
                    usernameError.Text = "The username cannot begin with a dot '.'!";
                    return false;
            }

            //Checks if the password exceeds 30 characters.
            if (password.Text.Length > 30)
            {
                passwordError.Text = "Username must be less than 30 characters!";
                return false;
            }

            //Checks if the password is less than 8 characters.
            if (password.Text.Length < 8)
            {
                passwordError.Text = "Password cannot be less than 8 characters!";
                return false;
            }

            //Checks if the email exceeds 40 characters.
            if (email.Text.Length > 40)
            {
                emailError.Text = "Email must be less than 20 characters!";
                return false;
            }

            //Checks if the username and password are identical.
            if (username == password)
            {
                passwordError.Text = "The username and password cannot be identical!";
                return false;
            }

            //Checks if the email begins with a number.
            switch (email.Text[0])
            {
                case '0':case '1':case '2':case '3':case '4':
                case '5':case '6':case '7':case '8':case '9':
                    usernameError.Text = "The email cannot begin with a number!";
                    return false;
            }

            //Checks if the email consists of only numbers.
            if (int.TryParse(email.Text, out int num2))
            {
                emailError.Text = "Invalid email!";
                return false;
            }

            //Checks if the mobile number is not 10 characters.
            if (number.Text.Length != 10)
            {
                numberError.Text = "Invalid number! Must be 10 characters";
                return false;
            }

            //Checks if the mobile number is actually a number.
            if (!int.TryParse(number.Text, out int num1))
            {
                numberError.Text = "Invalid number!";
                return false;
            }

            //Checks if the username, email and mobile number are already taken.
            MySqlCommand cmd = new MySqlCommand("SELECT username, email, mobile_number FROM users;", Connect.con);
            Connect.con.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                if(username.Text == dr[0].ToString())
                {
                    usernameError.Text = "Username is already taken!";
                    Connect.con.Close();
                    return false;
                }

                if(email.Text == dr[1].ToString())
                {
                    emailError.Text = "Email is already taken!";
                    Connect.con.Close();
                    return false;
                }

                if (number.Text == dr[2].ToString())
                {
                    numberError.Text = "Number is already taken!";
                    Connect.con.Close();
                    return false;
                }
            }
            Connect.con.Close();

            return true;
        }
    }
}
