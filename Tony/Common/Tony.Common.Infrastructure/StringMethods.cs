using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Tony.Common.Infrastructure
{
    public static class StringMethods
    {
        public static string RoundOff(string str, int digit)
        {
            string output = "";
            if (str.Length == digit)
                output = str;
            else if (str.Length > digit)
                output = str.Substring(0, digit);
            else
            {
                int diff = digit - str.Length;
                for (int i = 1; i <= diff; i++)
                    output += "0";
                output += str;
            }
            return output;
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  // SHA1.Create()
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static string ToShort(this string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return input.Length <= maxLength ? input : input.Substring(0, maxLength) + "...";
        }

        public static string GetNthLast(this string input, int position, object _default = null)
        {
            if (position <= 0) throw new IndexOutOfRangeException("position cannot be less than or equal to 0");
            var length = input.Length;
            var defaultString = _default == null ? "" : _default.ToString();
            return length < position ? defaultString : input.Substring(length - position, 1);
        }

        public static string GetNthLast(this long input, int position, object _default = null)
        {
            return input.ToString().GetNthLast(position, _default);
        }

        public static string GetNthLast(this int input, int position, object _default = null)
        {
            return input.ToString().GetNthLast(position, _default);
        }


        public static string GetNthFirst(this string input, int position, object _default = null)
        {
            var defaultString = _default == null ?"": _default.ToString();
            if (position <= 0) throw new IndexOutOfRangeException("position cannot be less than or equal to 0");
            return input.Length < position ? defaultString : input.Substring(position - 1, 1);
        }

        public static string GetNthFirst(this long input, int position, object _default = null)
        {
            return input.ToString().GetNthFirst(position, _default);
        }
        public static string GetNthFirst(this int input, int position, string _default = null)
        {
            return input.ToString().GetNthFirst(position, _default);
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
         
        /// <summary>
        /// Generates a random string with the given length
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="lowerCase">If true, generate lowercase string</param>
        /// <returns>Random string</returns>
        public static string RandomString(int size, bool lowerCase = false)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }


        public static string UrlEncode(this string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        public static string DecodeUrl(this string url)
        {
            return HttpUtility.UrlDecode(url);
        }
    }
}
