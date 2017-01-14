namespace NinjaFactory.DataBase
{
    using System;
    using System.Collections.Generic;
    using NinjaFactory.DataBase.Repositories;

    /// <summary>
    /// A Data abstraction, working with the TeamworkBlackDragon Database
    /// </summary>
    public class NinjasData : INinjaFactoryData
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly TeamworkBlackDragonEntities context;

        /// <summary>
        /// The repositories
        /// </summary>
        private readonly IDictionary<Type, object> repositories;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjasData" /> class.
        /// </summary>
        public NinjasData()
            : this(new TeamworkBlackDragonEntities())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjasData" /> class.
        /// </summary>
        /// <param name="context"> The context. </param>
        public NinjasData(TeamworkBlackDragonEntities context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Gets the clients.
        /// </summary>
        /// <value> The clients. </value>
        public IGenericRepository<Client> Clients
        {
            get
            {
                return this.GetRepository<Client>();
            }
        }

        /// <summary>
        /// Gets the jobs.
        /// </summary>
        /// <value> The jobs. </value>
        public IGenericRepository<Job> Jobs
        {
            get
            {
                return this.GetRepository<Job>();
            }
        }

        /// <summary>
        /// Gets the ninjas.
        /// </summary>
        /// <value> The ninjas. </value>
        public IGenericRepository<Ninja> Ninjas
        {
            get
            {
                return this.GetRepository<Ninja>();
            }
        }

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <value> The specialities. </value>
        public IGenericRepository<Speciality> Specialities
        {
            get
            {
                return this.GetRepository<Speciality>();
            }
        }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
        
        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <returns> The repository for the specifyed type </returns>
        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}