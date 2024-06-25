using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql_Practice
{
    internal class Autorization
    {
        static public string? _Name, _Password, _Id;

        static public void AutorizationUser(string login, string password, MySqlCommand msCommand)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Login and password cannot be empty!");
                return;
            }
            try
            {
                msCommand.CommandText = "SELECT username FROM users WHERE username = @username AND password = @password";
                msCommand.Parameters.Clear();
                msCommand.Parameters.AddWithValue("@username", login);
                msCommand.Parameters.AddWithValue("@password", password);

                var result = msCommand.ExecuteScalar();
                if (result != null)
                {
                    _Name = result.ToString();
                    _Password = password;
                    MessageBox.Show("Authorization successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _Name = null;
                    _Password = null;
                    MessageBox.Show("Invalid username or password.", "Authorization Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Autorization Error: {ex.Message}");
            }
        }
    }
}
