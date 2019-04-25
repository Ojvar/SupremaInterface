using System.Text;

namespace FingerPrintController.Extensions
{
    public static partial class Extensions
    {
        #region Methods
        /// <summary>
        /// Convert String to bytes array
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[]
        toBytes (this string str,
                 Encoding encoding)
        {
            return encoding.GetBytes (str);
        }


        /// <summary>
        /// Convert String to bytes array
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[]
        toBytesUTF8 (this string str)
        {
            return str.toBytes (Encoding.UTF8);
        }


        /// <summary>
        /// Convert String to bytes array
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[]
        toBytesASCII (this string str)
        {
            return str.toBytes (Encoding.ASCII);
        }


        /// <summary>
        /// Convert String to bytes array
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[]
        toBytesUnicode (this string str)
        {
            return str.toBytes (Encoding.Unicode);
        }


        /// <summary>
        /// Convert bytes array to String
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string
        toString (this byte[] data,
                  Encoding encoding)
        {
            return encoding.GetString (data);
        }


        /// <summary>
        /// Convert bytes array to String
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string
        toStringUTF8 (this byte[] data)
        {
            return data.toString (Encoding.UTF8);
        }


        /// <summary>
        /// Convert bytes array to String
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string
        toStringUnicode (this byte[] data)
        {
            return data.toString (Encoding.Unicode);
        }


        /// <summary>
        /// Convert bytes array to String
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string
        toStringASCII (this byte[] data)
        {
            return data.toString (Encoding.ASCII);
        }
        #endregion
    }
}
