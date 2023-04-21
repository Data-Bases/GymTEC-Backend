using System.Text;
using Tweetinvi.Security;

namespace GymTEC_Backend.Helpers
{
    public class PassowordHelper
    {

        public static string EncodePassword(string originalPassword)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
            byte[] hash = sha1.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }
        
    }
}
