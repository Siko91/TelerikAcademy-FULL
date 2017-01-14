namespace NinjaFactory.DataBase.Repositories
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using NinjaFactory.DataBase;

    /// <summary>
    /// Abstraction about a DBSet, working with the TeamworkBlackDragon database
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ITeamworkBlackDragonDBContext context;

        /// <summary>
        /// The set
        /// </summary>
        private readonly IDbSet<T> set;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}" /> class.
        /// </summary>
        /// <param name="context"> The context. </param>
        public GenericRepository(ITeamworkBlackDragonDBContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public void Add(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns> All of the items in the specifyed Repository </returns>
        public IQueryable<T> All()
        {
            return this.set.AsQueryable();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public void Delete(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        /// <summary>
        /// Detaches the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public void Detach(T entity)
        {
            var entry = this.context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        /// <summary>
        /// Searches for.
        /// </summary>
        /// <param name="conditions"> The conditions. </param>
        /// <returns> Tfe filtered results </returns>
        public IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions)
        {
            return this.All().Where(conditions);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        public void Update(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        /// <summary>
        /// Wheres the specified conditions.
        /// </summary>
        /// <param name="conditions"> The conditions. </param>
        /// <returns> Tfe filtered results </returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> conditions)
        {
            return this.SearchFor(conditions);
        }
        
        /// <summary>
        /// Attaches if detached.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        /// <returns> The entity. </returns>
        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            return entry;
        }
    }
}