namespace SFSQLiteApi.Utils
{
    internal static class ObjectExtension
    {
        /// <summary>
        /// Haves the content.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool HaveContent(this object value)
        {
            if (value == null)
            {
                return false;
            }

            return (!string.IsNullOrWhiteSpace(value.ToString()));
        }
    }
}