namespace NinjaFactory.NinjaCatalogue
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Json;
    using NinjaFactory.DataBase;

    public class NinjaCatalogueCreator
    {
        /// <summary>
        /// Creates a JSON report of ninjas from a database and places it in a file
        /// </summary>
        /// <param name="db"> the database to draw infromation from </param>
        /// <param name="filePath"> the path to the output file containing json report </param>
        public void CreateJson(INinjaFactoryData db, string filePath)
        {
            var ninjaItems = this.GetNinjaCatalogueFromDb(db);

            foreach (var item in ninjaItems)
            {
                if (item.SuccessfulJobsCount > 0)
                {
                    item.SuccessRate = Math.Round((double)item.SuccessfulJobsCount / item.JobsCount, 2);
                }
            }

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(NinjaCatalogueItem[]));

            FileStream fileStream = new FileStream(filePath, FileMode.Create);

            jsonSerializer.WriteObject(fileStream, ninjaItems);
        }

        public NinjaCatalogueItem[] GetNinjaCatalogueFromDb(INinjaFactoryData db)
        {
            var ninjaItems = db.Ninjas
                               .Where(n => n.Jobs.Where(j => j.IsSuccessfull.HasValue == false).Count() == 0)
                               .Select(n => new NinjaCatalogueItem()
                                      {
                                          NinjaId = n.Id,
                                          Name = n.Name,
                                          KillCount = n.KillCount,
                                          Weapon = n.WeaponOfChoice,
                                          Price = n.MinimalPersonalPrice + n.Speciality.MinimalCompanyPrice,
                                          SpecialtyName = n.Speciality.Name,
                                          JobsCount = n.Jobs.Count(),
                                          SuccessfulJobsCount = n.Jobs.Where(j => j.IsSuccessfull.HasValue == true && j.IsSuccessfull.Value == true).Count(),
                                          SuccessRate = 0
                                      })
                               .ToArray();
            return ninjaItems;
        }
    }
}
