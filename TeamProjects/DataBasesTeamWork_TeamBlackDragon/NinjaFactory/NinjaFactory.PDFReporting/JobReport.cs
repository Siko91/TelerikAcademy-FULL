namespace NinjaFactory.PDFReporting
{
    using NinjaFactory.DataBase;

    public class JobReport
    {
        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value> The client. </value>
        public Client Client { get; set; }

        /// <summary>
        /// Gets or sets the job.
        /// </summary>
        /// <value> The job. </value>
        public Job Job { get; set; }

        /// <summary>
        /// Gets or sets the ninja.
        /// </summary>
        /// <value> The ninja. </value>
        public Ninja Ninja { get; set; }
    }
}
