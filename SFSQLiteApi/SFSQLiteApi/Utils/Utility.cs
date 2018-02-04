using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace SFSQLiteApi.Utils
{
    internal static class Utility
    {
        /// <summary>
        /// Copies the stream.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        public static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;

            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

        /// <summary>
        /// Decompresses the g zip.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public static void DecompressGZip(string gzipFileName, string fileName)
        {
            FileInfo fileInfo = new FileInfo(gzipFileName);

            if (fileInfo != null)
            {
                using (FileStream fileStream = fileInfo.OpenRead())
                {
                    fileName = Path.Combine(fileInfo.DirectoryName, fileName);

                    using (FileStream outFileStream = File.Create(fileName))
                    {
                        using (GZipStream gzipStream = new GZipStream(fileStream, CompressionMode.Decompress))
                        {
                            gzipStream.CopyTo(outFileStream);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="photoColumns">The photo columns.</param>
        /// <param name="photoList">The photo list.</param>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static object GetValue(List<string> photoColumns, List<byte[]> photoList, PropertyInfo property, object value)
        {
            if (property.PropertyType.IsByteArray())
            {
                photoColumns.Add(property.Name);
                photoList.Add((byte[])value);
                return 0;
            }
            else if (property.PropertyType.IsBool())
            {
                return (Convert.ToInt16(value));
            }
            else if ((value == null) && property.PropertyType.IsString())
            {
                return (string.Empty);
            }

            return value;
        }
    }
}