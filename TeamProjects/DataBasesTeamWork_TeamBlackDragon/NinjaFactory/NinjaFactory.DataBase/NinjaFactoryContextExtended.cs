namespace NinjaFactory.DataBase
{
    using System;
    using System.Data.Entity;

    public partial class TeamworkBlackDragonEntities : DbContext, ITeamworkBlackDragonDBContext
    {
        /// <summary>
        /// Saves the changes without returning anything.
        /// </summary>
        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        /// <summary>
        /// Gets a set by the type of its elements
        /// </summary>
        /// <typeparam name="T"> </typeparam>
        /// <returns> </returns>
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}