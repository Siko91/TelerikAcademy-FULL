namespace NinjaFactory.NinjaCatalogue
{
    /// <summary>
    /// A catalog entity containing all ninja information
    /// </summary>
    public class NinjaCatalogueItem
    {
        /// <summary>
        /// Gets or sets the ninja id
        /// </summary>
        public int NinjaId { get; set; }

        /// <summary>
        /// Gets or sets the ninja name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the number of kills on current ninja
        /// </summary>
        public int KillCount { get; set; }

        /// <summary>
        /// Gets or sets the preferred weapon by the ninja
        /// </summary>
        public string Weapon { get; set; }

        /// <summary>
        /// Gets or sets ninja payment for a job order
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the specialty for current ninja
        /// </summary>
        public string SpecialtyName { get; set; }

        /// <summary>
        /// Gets or sets the number of jobs for current ninja
        /// </summary>
        public int JobsCount { get; set; }

        /// <summary>
        /// Gets or sets the number of successfully completed jobs
        /// </summary>
        public int SuccessfulJobsCount { get; set; }

        /// <summary>
        /// Gets or sets the success rate of current ninja
        /// </summary>
        public double SuccessRate { get; set; }
    }
}
