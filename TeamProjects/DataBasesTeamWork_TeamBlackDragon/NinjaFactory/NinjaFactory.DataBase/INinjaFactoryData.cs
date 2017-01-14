namespace NinjaFactory.DataBase
{
    using NinjaFactory.DataBase.Repositories;

    /// <summary>
    /// Gets certain instances of IGenericRepository, that has a SaveChanges method
    /// </summary>
    public interface INinjaFactoryData
    {
        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <value> The clients. </value>
        IGenericRepository<Client> Clients { get; }

        /// <summary>
        /// Gets the jobs.
        /// </summary>
        /// <value> The jobs. </value>
        IGenericRepository<Job> Jobs { get; }

        /// <summary>
        /// Gets the ninjas.
        /// </summary>
        /// <value> The ninjas. </value>
        IGenericRepository<Ninja> Ninjas { get; }

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <value> The specialities. </value>
        IGenericRepository<Speciality> Specialities { get; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        void SaveChanges();
    }
}