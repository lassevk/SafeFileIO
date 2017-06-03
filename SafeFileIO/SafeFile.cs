using System;
using System.IO;

namespace SafeFileIO
{
    /// <summary>
    /// This static class holds static methods that deal with files in race-condition
    /// safe ways.
    /// </summary>
    public static class SafeFile
    {
        /// <summary>
        /// Attempt to delete the file, returning a boolean result indicating success.
        /// </summary>
        /// <param name="filename">
        /// The path to and name of the file to try to delete.
        /// </param>
        /// <returns>
        /// <c>true</c> if the file was successfully deleted,
        /// otherwise, <c>false</c>.
        /// </returns>
        public static bool TryDelete(string filename)
        {
            try
            {
                File.Delete(filename);
                return true;
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (IOException ex) when (ex.HResult == 0x001)
            {
                return false;
            }
        }
    }
}
