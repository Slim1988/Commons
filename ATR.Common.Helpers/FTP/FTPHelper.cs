namespace ATR.Common.Helpers.FTP
{
    using System;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using ATR.Common.Logging;

    /// <summary>
    /// Helper class for FTP.
    /// </summary>
    public static class FTPHelper
    {
        /// <summary>
        /// Get a file from an FTP server
        /// </summary>
        /// <param name="sourceFileToDownload">Path of the file to download</param>
        /// <returns>file</returns>
        public static byte[] GetFTPFile(string sourceFileToDownload)
        {
            LoggingService.Application.Debug(string.Format("Start GetFTPFile to download file: '{0}'", sourceFileToDownload));

            // FileStream file = null;
            byte[] fileBytes = null;
            try
            {
                // Get FTP settings from web.config
                NameValueCollection ftpSettings = ConfigurationManager.GetSection("ftpSettings") as NameValueCollection;
                string ftpUser = ftpSettings["FTPUser"];
                string ftpPassword = ftpSettings["FTPPassword"];

                LoggingService.Application.Debug(string.Format("FTP settings - FTPUser: {0}", ftpUser));

                string fTPSourceFile = sourceFileToDownload;

                LoggingService.Application.Debug(string.Format("Start downloading ftp:{0}", sourceFileToDownload));

                // FTPWebRequest
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp:" + sourceFileToDownload);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                // Connect to FTP
                request.Credentials = new NetworkCredential(ftpUser, ftpPassword);

                // Get the response
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                // Read content file
                Stream fileStream = response.GetResponseStream();

                byte[] buffer = new byte[4096];
                MemoryStream memoryStream = new MemoryStream();
                int chunkSize = 0;
                do
                {
                    chunkSize = fileStream.Read(buffer, 0, buffer.Length);
                    memoryStream.Write(buffer, 0, chunkSize);
                }
                while (chunkSize != 0);

                fileBytes = memoryStream.ToArray();
            }
            catch (Exception ex)
            {
                LoggingService.Application.Error(string.Format("Error downloading file '{0}' on FTP: {1}", sourceFileToDownload, ex.Message));
                LoggingService.Application.Error("End GetFTPFile with error");
                throw new ApplicationException(string.Format("Error downloading file '{0}' on FTP: {1}", sourceFileToDownload, ex.Message));
            }

            LoggingService.Application.Debug("End GetFTPFile with success");
            return fileBytes;
        }
    }
}
