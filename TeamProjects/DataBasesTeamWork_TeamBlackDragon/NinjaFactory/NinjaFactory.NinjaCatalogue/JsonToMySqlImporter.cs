namespace NinjaFactory.NinjaCatalogue
{
    using System.Linq;

    using NinjaFactory.DataBase.MySql;

    public class JsonToMySqlImporter
    {
        private readonly NinjaCatalogueModel mySqlContext;
        private Ninja_catalogue_item[] catalogue;
        private NinjaCatalogueJsonParser parser;

        public JsonToMySqlImporter(NinjaCatalogueModel mySqlContext)
        {
            this.mySqlContext = mySqlContext;
        }

        private NinjaCatalogueItem[] Catalogue
        {
            set
            {
                this.catalogue = value.Select(nin => new Ninja_catalogue_item()
                {
                    IsDeleted = false,
                    CentralID = nin.NinjaId,
                    Name = nin.Name,
                    KillCount = nin.KillCount,
                    Weapon = nin.Weapon,
                    Price = (float)nin.Price,
                    Speciality = nin.SpecialtyName,
                    JobsCount = nin.JobsCount,
                    SuccessfulJobsCount = nin.SuccessfulJobsCount,
                    SuccessRate = nin.SuccessRate
                }).ToArray();
            }
        }

        public int Run(NinjaCatalogueItem[] catalogue)
        {
            this.Catalogue = catalogue;
            this.SetAllNinjasToDeleted();
            this.LoadToMySql();
            return this.catalogue.Length;
        }

        public int Run(string filePath, NinjaCatalogueJsonParser parser)
        {
            this.parser = parser;
            this.ReadJsonFile(filePath);
            this.SetAllNinjasToDeleted();
            this.LoadToMySql();
            return this.catalogue.Length;
        }

        private void LoadToMySql()
        {
            foreach (var updatedNinja in this.catalogue)
            {
                var ninjaToUpdate = this.mySqlContext.Ninja_catalogue_items.FirstOrDefault(n => n.CentralID == updatedNinja.CentralID);
                if (ninjaToUpdate != null)
                {
                    ninjaToUpdate = updatedNinja;
                }
                else
                {
                    this.mySqlContext.Add(updatedNinja);
                }
            }

            this.mySqlContext.SaveChanges();
        }

        private void ReadJsonFile(string filePath)
        {
            this.Catalogue = this.parser.Parse(filePath);
        }

        private void SetAllNinjasToDeleted()
        {
            foreach (var item in this.mySqlContext.Ninja_catalogue_items)
            {
                item.IsDeleted = true;
            }

            this.mySqlContext.SaveChanges();
        }
    }
}