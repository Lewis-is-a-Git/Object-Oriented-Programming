// FileName: User.cs
// Author: Lewis Brockman-Horsley
// Email: 101533222@students.swinburne.edu.au
// Date: 5/10/2019
using System;
namespace PT13.src
{
    /// <summary>
    /// User.
    /// </summary>
    public abstract class User
    {
        protected String _userName;
        protected String _password;

        protected User(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }

        public string UserName { get => _userName; }
        public string Password { get => _password; }

        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="oldPassword">Old password.</param>
        /// <param name="newPassword">New password.</param>
        internal void ResetPassword(string oldPassword, string newPassword)
        {
            if (_password == oldPassword)
            {
                _password = newPassword;
                Console.WriteLine("Password updated.");
            }
            else
            {
                Console.WriteLine("Cannot update password.");
            }
        }

        /// <summary>
        /// Edits the user.
        /// </summary>
        /// <param name="password">Password.</param>
        /// <param name="newUsername">New username.</param>
        internal void EditUser(string password, string newUsername)
        {
            if (_password == password)
            {
                _userName = newUsername;
                Console.WriteLine("Username updated.");
            }
            else
            {
                Console.WriteLine("Cannot update username.");
            }
        }
    }
}
