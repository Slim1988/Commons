namespace ATR.Common.Helper.Email
{
    using System.Collections.Generic;

    /// <summary>
    /// model use for Mail parameters
    /// </summary>
    public class MailParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MailParameters"/> class.
        /// Constructor of the class MailParameters
        /// </summary>
        /// <param name="subject">subject of the Email</param>
        /// <param name="body">body of the Email</param>
        /// <param name="mainRecipients">mainRecipients of the Email (TO list)</param>
        /// <param name="secondaryRecipients">(Optional) secondaryRecipients of the Email (BCC list)</param>
        public MailParameters(string subject, string body, List<string> mainRecipients, List<string> secondaryRecipients = null)
        {
            this.Subject = subject;
            this.Body = body;
            this.MainRecipients = mainRecipients;
            this.SecondaryRecipients = secondaryRecipients;
        }

        /// <summary>
        /// Gets or sets Subject of the Email
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets Body of the Email
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets MainRecipients of the Email (TO list)
        /// </summary>
        public List<string> MainRecipients { get; set; }

        /// <summary>
        /// Gets or sets SecondaryRecipients of the Email (BCC list)
        /// </summary>
        public List<string> SecondaryRecipients { get; set; }
    }
}