namespace NinjaFactory.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A Database context working with the TeamworkBlackDragon Database
    /// </summary>
    public interface ITeamworkBlackDragonDBContext
    {
        DbSet<Client> Clients { get; set; }

        DbSet<Job> Jobs { get; set; }

        DbSet<Ninja> Ninjas { get; set; }

        DbSet<Speciality> Specialities { get; set; }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        void SaveChanges();

        DbSet<T> Set<T>() where T : class;
    }
}