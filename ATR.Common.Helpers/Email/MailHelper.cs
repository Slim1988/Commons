namespace ATR.Common.Helper.Email
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text.RegularExpressions;
    using ATR.Common.Logging;

    /// <summary>
    /// Helper class for Email
    /// </summary>
    public class MailHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailHelper"/> class.
        /// </summary>
        /// <param name="smtpServer">smtpServer that will be used to send the email</param>
        /// <param name="smtpPort">smtpPort that will be used to send the email</param>
        /// <param name="smtpUser">user that will be used to authenticate to the smtp server and send email</param>
        /// <param name="smtpUserPassword">password of the smtpUser</param>
        /// <param name="smtpSender">the email address used for sender email</param>
        /// <param name="recipientEmail">the email address of the receiver</param>
        /// <param name="recipientfield">field that define where to put the receiver email address</param>
        public MailHelper(string smtpServer, string smtpPort, string smtpUser, string smtpUserPassword, string smtpSender, string recipientEmail, string recipientfield)
        {
            this.SmtpServer = smtpServer;
            this.SmtpPort = smtpPort;
            this.SmtpUser = smtpUser;
            this.SmtpUserPassword = smtpUserPassword;
            this.SmtpSender = smtpSender;
            this.RecipientEmail = recipientEmail;
            this.RecipientField = recipientfield;
        }

        #region Properties

        /// <summary>
        /// Gets or sets smtpServer that will be used to send the email
        /// </summary>
        public string SmtpServer { get; set; }

        /// <summary>
        /// Gets or sets smtpPort that will be used to send the email
        /// </summary>
        public string SmtpPort { get; set; }

        /// <summary>
        /// Gets or sets SmtpUser that will be used to authenticate to SMTP server
        /// </summary>
        public string SmtpUser { get; set; }

        /// <summary>
        /// Gets or sets the password of the user used to authenticate to SMTP server
        /// </summary>
        public string SmtpUserPassword { get; set; }

        /// <summary>
        /// Gets or sets the email adress used to send the email
        /// </summary>
        public string SmtpSender { get; set; }

        /// <summary>
        /// Gets or sets the email address of the receiver
        /// </summary>
        public string RecipientEmail { get; set; }

        /// <summary>
        /// Gets or sets if the receiver must be either in "TO", "BCC" or "CC" field
        /// </summary>
        public string RecipientField { get; set; }

        #endregion Properties

        /// <summary>
        /// The method of send mail using SMTP protocol.
        /// </summary>
        /// <param name="subject">The email subject</param>
        /// <param name="body"> The email body</param>
        /// <param name="attachments">List of attachments to send</param>
        /// <param name="listTO">List of recipient emails that will be sent with recipient Field TO</param>
        /// <param name="listBCC">List of recipient emails that will be sent with recipient Field BCC</param>
        /// <param name="listCC">List of recipient emails that will be sent with recipient Field CC</param>
        public void SendMail(string subject, string body, List<Attachment> attachments, List<string> listTO = null, List<string> listBCC = null, List<string> listCC = null)
        {
            SmtpClient client = new SmtpClient();
            MailMessage email = new MailMessage();
            try
            {
                NetworkCredential credentials = new NetworkCredential(this.SmtpUser, this.SmtpUserPassword);
                client.Host = this.SmtpServer;
                client.Port = Convert.ToInt32(this.SmtpPort);
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;

                if (string.IsNullOrEmpty(this.RecipientEmail))
                {
                    if (listTO != null)
                    {
                        foreach (string address in listTO)
                        {
                            if (!string.IsNullOrEmpty(address))
                            {
                                email.To.Add(address);
                            }
                        }
                    }

                    if (listBCC != null)
                    {
                        foreach (string address in listBCC)
                        {
                            if (!string.IsNullOrEmpty(address))
                            {
                                email.Bcc.Add(address);
                            }
                        }
                    }

                    if (listCC != null)
                    {
                        foreach (string address in listCC)
                        {
                            if (!string.IsNullOrEmpty(address))
                            {
                                email.CC.Add(address);
                            }
                        }
                    }
                }
                else
                {
                    email.To.Add(this.RecipientEmail);
                }

                // Get environment
                string environment = ConfigurationManager.AppSettings["environment"];
                if (string.IsNullOrEmpty(environment) || "PROD".Equals(environment.ToUpper()) || "PRD".Equals(environment.ToUpper()))
                {
                    environment = string.Empty;
                }

                email.IsBodyHtml = true;
                email.From = new MailAddress(this.SmtpSender);
                email.Subject = string.IsNullOrEmpty(environment) ? subject : string.Format("[{0}] {1}", environment, subject);

                // Replace images src url by embed image
                // body = this.ReplaceImagesSrcUrl(body);

                // Replace ATRactive logo by embed image if exists, else by link to ATRactive portal
                var cdnPath = ConfigurationManager.AppSettings["CDNPath"];
                var pathLogo = string.IsNullOrEmpty(cdnPath) ? string.Empty : cdnPath + "logo_ATR_Active.png";
                if (File.Exists(pathLogo))
                {
                    var imgTag = string.Format("<img src='{0}' />", this.GetImageByPath(pathLogo));
                    body = body.Replace("{IMG_LOGO_ATRACTIVE}", imgTag);
                }
                else
                {
                    body = body.Replace("{IMG_LOGO_ATRACTIVE}", "www.atractive.com");
                }

                // Set body
                email.Body = body;

                // AlternateView image = EmbedImageInMailBody(body, resources);
                // email.AlternateViews.Add(image);

                // Add attachments
                if (attachments != null && attachments.Count > 0)
                {
                    AttachmentCollection mailAttachments = email.Attachments;
                    foreach (var attachment in attachments)
                    {
                        mailAttachments.Add(attachment);
                    }
                }

                // Send mail
                client.Send(email);

                LoggingService.Application.Info("Mail Sent Successfully...");
            }
            catch (Exception ex)
            {
                LoggingService.Application.Error("Sending Mail Failed...", ex);
                throw;
            }
            finally
            {
                email.Dispose();
                client.Dispose();
            }
        }

        /// <summary>
        /// The method Embed images in mail body
        /// </summary>
        /// <param name="body">Email body</param>
        /// <param name="resources">list of resources to add as alternate view in the body of the email</param>
        /// <returns>AlternateView object contains HTML body with embedded images</returns>
        private static AlternateView EmbedImageInMailBody(string body, List<LinkedResource> resources)
        {
            AlternateView images = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
            if (resources != null)
            {
                resources.ForEach(x => images.LinkedResources.Add(x));
            }

            return images;
        }

        private string ReplaceImagesSrcUrl(string body)
        {
            var imgSrcMatches = Regex.Matches(body.ToString(), "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase);
            string imgSrc = string.Empty;
            foreach (Match match in imgSrcMatches)
            {
                imgSrc = match.Groups[1].Value;
                if (imgSrc.StartsWith("http"))
                {
                    body = body.Replace(imgSrc, this.GetImageByUrl(imgSrc));
                }
            }

            return body;
        }

        private string GetImageByUrl(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            Stream imgStream = WebRequest.Create(url).GetResponse().GetResponseStream();
            System.Drawing.Image image = System.Drawing.Image.FromStream(imgStream);
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Png);
            byte[] bytes = new byte[memoryStream.Length];
            memoryStream.Position = 0;
            memoryStream.Read(bytes, 0, bytes.Length);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            string imageSrc = "data:image/png;base64," + base64String;
            return imageSrc;
        }

        private string GetImageByPath(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
            string imageSrc = "data:image/png;base64," + base64String;
            return imageSrc;
        }
    }
}