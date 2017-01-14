namespace NinjaFactory
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using NinjaFactory.DataBase;
    using NinjaFactory.DataBase.MySql;
    using NinjaFactory.ExcelReporting;
    using NinjaFactory.Imports;
    using NinjaFactory.NinjaCatalogue;
    using NinjaFactory.PDFReporting;
    using NinjaFactory.XMLReporting;

    /// <summary>
    /// Every ninja fabricator should buy this!
    /// </summary>
    public partial class NinjaFactoryApp : Form
    {
        /// <summary>
        /// My SQL database
        /// </summary>
        private NinjaCatalogueModel mySqlDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjaFactoryApp" /> class.
        /// </summary>
        public NinjaFactoryApp()
        {
            this.InitializeComponent();
            this.DB = new NinjasData();
            this.mySqlDb = new NinjaCatalogueModel();
        }
        
        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value> The database. </value>
        private INinjaFactoryData DB { get; set; }

        /// <summary>
        /// Adds the new orders.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void AddNewOrders(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "ZIP files (*.zip)|*.zip";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                string directoryOfExtractedFiles = "UnimportedJobs";
                string pattern = string.Empty;

                ExcelImport.ExtractFile(filePath, directoryOfExtractedFiles);
                ExcelImport.ProcessExcelFiles(directoryOfExtractedFiles, pattern, db);

                Directory.Delete(directoryOfExtractedFiles, true);
                MessageBox.Show("Done");
            }
        }

        /// <summary>
        /// Creates the income report.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void CreateIncomeReport(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FileName = "IncomeReports";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                // TODO: Implement and use a library doing this task. Use the filePath and db from above.
                PDFIncomeReportCreator pdfCreator = new PDFIncomeReportCreator();
                pdfCreator.CreatePDFReport(db, filePath);
                MessageBox.Show("Income reports created successfully!");
            }
        }

        /// <summary>
        /// Creates the ninja catalogue.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void CreateNinjaCatalogue(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.FileName = "NinjaCatalogue";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                NinjaCatalogueCreator creator = new NinjaCatalogueCreator();
                creator.CreateJson(db, filePath);
                MessageBox.Show("Ninjas catalog created successfully!");
            }
        }

        /// <summary>
        /// Creates the ninja ranking raport.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void CreateNinjaRankingRaport(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "NinjaRankingReport";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                NinjaCatalogueModel mySqlDb = this.mySqlDb;

                ExcelSuccessRateReportCreator excelCreator = new ExcelSuccessRateReportCreator();
                excelCreator.CreateSuccessRateReport(mySqlDb, filePath);
                MessageBox.Show("NinjaRankingReport generated!");
            }
        }

        /// <summary>
        /// Creates the report for lost ninjas.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void CreateReportForLostNinjas(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "xml files (*.xml)|*.xml";
            saveFileDialog.FileName = "LostNinjasReport";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                INinjaFactoryData db = this.DB;
                XmlLostNinjaReportCreator creator = new XmlLostNinjaReportCreator();
                creator.CreateLostNinjasReport(db, filePath);
                MessageBox.Show("Done");
            }
        }

        /// <summary>
        /// Gets the reports and finalize orders.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void GetReportsAndFinalizeOrders(object sender, EventArgs e)
        {
            INinjaFactoryData db = this.DB;
            MongoDBImport.InsertMongoDbReportsInDatabse(db);
            MessageBox.Show("Done");
        }

        /// <summary>
        /// Creates the backup.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void LoadCatalogueInMySql(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "JSON files (*.json)|*.json";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                NinjaCatalogueModel mySqlDb = this.mySqlDb;

                JsonToMySqlImporter importer = new JsonToMySqlImporter(mySqlDb);
                var recordCount = importer.Run(filePath, new NinjaCatalogueJsonParser());
                MessageBox.Show("Loaded " + recordCount + " records.");
            }
        }

        /// <summary>
        /// Loads the ninja catalogue to my SQL directly.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        private void LoadNinjaCatalogueToMySqlDirectly(object sender, EventArgs e)
        {
            NinjaCatalogueModel mySqlDb = this.mySqlDb;
            JsonToMySqlImporter importer = new JsonToMySqlImporter(mySqlDb);
            var catalogue = new NinjaCatalogueCreator().GetNinjaCatalogueFromDb(this.DB);
            int recordCount = importer.Run(catalogue);
            MessageBox.Show("Loaded " + recordCount + " records.");
        }

        /// <summary>
        /// Removes the lost ninjas.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        /// <exception cref="System.NotImplementedException"> Not Implemented </exception>
        private void RemoveLostNinjas(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "xml files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                INinjaFactoryData db = this.DB;

                XmlLostNinjaReportParser reportParser = new XmlLostNinjaReportParser();
                reportParser.DeleteNinjasMentionedInLostNinjaReport(db, filePath);
                MessageBox.Show("Done");
            }
        }

        /// <summary>
        /// Sets the mongo database for testing.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The <see cref="EventArgs" /> instance containing the event data. </param>
        private void SetMongoDbForTesting(object sender, EventArgs e)
        {
            MongoDBImport.SetMongoDBForTesting(this.DB);
        }
    }
}