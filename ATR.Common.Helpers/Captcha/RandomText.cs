namespace CaptchaDotNet2.Security.Cryptography
{
    /// <summary>
    /// Provides methods for generating random texts.
    /// </summary>
    public static class RandomText
    {
        /// <summary>
        /// Generates an 4 letter random text.
        /// </summary>
        /// <returns>Random text</returns>
        public static string Generate()
        {
            string s = string.Empty;
            char[] chars = "abcdefghijklmnpqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ0123456789".ToCharArray();
            int index;
            int lenght = RNG.Next(4, 4);
            for (int i = 0; i < lenght; i++)
            {
                index = RNG.Next(chars.Length - 1);
                s += chars[index].ToString();
            }

            return s;
        }
    }
}