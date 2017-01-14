namespace NinjaFactory.DataBase.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Abstraction about some kind of data.
    /// </summary>
    /// <typeparam name="T"> </typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        void Add(T entity);

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns> </returns>
        IQueryable<T> All();

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        void Delete(T entity);

        /// <summary>
        /// Detaches the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        void Detach(T entity);

        /// <summary>
        /// Searches for.
        /// </summary>
        /// <param name="conditions"> The conditions. </param>
        /// <returns> </returns>
        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity"> The entity. </param>
        void Update(T entity);

        /// <summary>
        /// Wheres the specified conditions.
        /// </summary>
        /// <param name="conditions"> The conditions. </param>
        /// <returns> </returns>
        IQueryable<T> Where(Expression<Func<T, bool>> conditions);
    }
}