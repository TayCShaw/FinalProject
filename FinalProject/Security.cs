using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;

namespace FinalProject
{

    public class Security
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["UserConnectionString"].ConnectionString;


        //https://stackoverflow.com/questions/50399685/c-sharp-login-system-need-help-hashing-password-before-inserting-them-to-the-da
        public static string Sha256(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                using (var sha = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(value);
                    var hash = sha.ComputeHash(bytes);

                    return Convert.ToBase64String(hash);
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static string getConnection()
        {
            return connectionString;
        }

    }
}