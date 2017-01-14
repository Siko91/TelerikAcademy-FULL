namespace NinjaFactory
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class NinjaFactoryApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        private Button addNewOrdersButton;
        private Button getReportsAndFinalizeOrdersButton;
        private Button loadCatalogueInMySQLButton;
        private Button createReportForLostNinjasButton;
        private Button removeLostNinjasButton;
        private Button createNinjaCatalogueButton;
        private Button createIncomeReportButton;
        private Button createNinjaRankingRaportButton;
        private Button setMongoDbForTestingButton;
        private Button loadNinjaCatalogueToMySqlDirectlyButton;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(NinjaFactoryApp));
            this.addNewOrdersButton = new System.Windows.Forms.Button();
            this.getReportsAndFinalizeOrdersButton = new System.Windows.Forms.Button();
            this.loadCatalogueInMySQLButton = new System.Windows.Forms.Button();
            this.createReportForLostNinjasButton = new System.Windows.Forms.Button();
            this.removeLostNinjasButton = new System.Windows.Forms.Button();
            this.createNinjaCatalogueButton = new System.Windows.Forms.Button();
            this.createIncomeReportButton = new System.Windows.Forms.Button();
            this.createNinjaRankingRaportButton = new System.Windows.Forms.Button();
            this.setMongoDbForTestingButton = new System.Windows.Forms.Button();
            this.loadNinjaCatalogueToMySqlDirectlyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddNewOrdersButton
            // 
            this.addNewOrdersButton.Location = new System.Drawing.Point(12, 12);
            this.addNewOrdersButton.Name = "AddNewOrdersButton";
            this.addNewOrdersButton.Size = new System.Drawing.Size(175, 106);
            this.addNewOrdersButton.TabIndex = 0;
            this.addNewOrdersButton.Text = "Add New Orders (zipped exel tables)";
            this.addNewOrdersButton.UseVisualStyleBackColor = true;
            this.addNewOrdersButton.Click += new System.EventHandler(this.AddNewOrders);
            // 
            // GetReportsAndFinalizeOrdersButton
            // 
            this.getReportsAndFinalizeOrdersButton.Location = new System.Drawing.Point(12, 124);
            this.getReportsAndFinalizeOrdersButton.Name = "GetReportsAndFinalizeOrdersButton";
            this.getReportsAndFinalizeOrdersButton.Size = new System.Drawing.Size(175, 106);
            this.getReportsAndFinalizeOrdersButton.TabIndex = 1;
            this.getReportsAndFinalizeOrdersButton.Text = "Get reports (from MongoDB) and finalize operations";
            this.getReportsAndFinalizeOrdersButton.UseVisualStyleBackColor = true;
            this.getReportsAndFinalizeOrdersButton.Click += new System.EventHandler(this.GetReportsAndFinalizeOrders);
            // 
            // LoadCatalogueInMySQLButton
            // 
            this.loadCatalogueInMySQLButton.Location = new System.Drawing.Point(12, 408);
            this.loadCatalogueInMySQLButton.Name = "LoadCatalogueInMySQLButton";
            this.loadCatalogueInMySQLButton.Size = new System.Drawing.Size(207, 37);
            this.loadCatalogueInMySQLButton.TabIndex = 2;
            this.loadCatalogueInMySQLButton.Text = "Load JSON Catalogue in MySQL";
            this.loadCatalogueInMySQLButton.UseVisualStyleBackColor = true;
            this.loadCatalogueInMySQLButton.Click += new System.EventHandler(this.LoadCatalogueInMySql);
            // 
            // CreateReportForLostNinjasButton
            // 
            this.createReportForLostNinjasButton.Location = new System.Drawing.Point(12, 451);
            this.createReportForLostNinjasButton.Name = "CreateReportForLostNinjasButton";
            this.createReportForLostNinjasButton.Size = new System.Drawing.Size(207, 37);
            this.createReportForLostNinjasButton.TabIndex = 3;
            this.createReportForLostNinjasButton.Text = "Create report for lost ninjas (XML)";
            this.createReportForLostNinjasButton.UseVisualStyleBackColor = true;
            this.createReportForLostNinjasButton.Click += new System.EventHandler(this.CreateReportForLostNinjas);
            // 
            // RemoveLostNinjasButton
            // 
            this.removeLostNinjasButton.Location = new System.Drawing.Point(12, 494);
            this.removeLostNinjasButton.Name = "RemoveLostNinjasButton";
            this.removeLostNinjasButton.Size = new System.Drawing.Size(207, 37);
            this.removeLostNinjasButton.TabIndex = 4;
            this.removeLostNinjasButton.Text = "Remove lost ninjas (from XML)";
            this.removeLostNinjasButton.UseVisualStyleBackColor = true;
            this.removeLostNinjasButton.Click += new System.EventHandler(this.RemoveLostNinjas);
            // 
            // CreateNinjaCatalogueButton
            // 
            this.createNinjaCatalogueButton.Location = new System.Drawing.Point(327, 12);
            this.createNinjaCatalogueButton.Name = "CreateNinjaCatalogueButton";
            this.createNinjaCatalogueButton.Size = new System.Drawing.Size(151, 106);
            this.createNinjaCatalogueButton.TabIndex = 5;
            this.createNinjaCatalogueButton.Text = "Create ninja catalogue (JSON)";
            this.createNinjaCatalogueButton.UseVisualStyleBackColor = true;
            this.createNinjaCatalogueButton.Click += new System.EventHandler(this.CreateNinjaCatalogue);
            // 
            // CreateIncomeReportButton
            // 
            this.createIncomeReportButton.Location = new System.Drawing.Point(484, 12);
            this.createIncomeReportButton.Name = "CreateIncomeReportButton";
            this.createIncomeReportButton.Size = new System.Drawing.Size(151, 106);
            this.createIncomeReportButton.TabIndex = 6;
            this.createIncomeReportButton.Text = "Create monthly income repport (PDF)";
            this.createIncomeReportButton.UseVisualStyleBackColor = true;
            this.createIncomeReportButton.Click += new System.EventHandler(this.CreateIncomeReport);
            // 
            // CreateNinjaRankingRaportButton
            // 
            this.createNinjaRankingRaportButton.Location = new System.Drawing.Point(641, 12);
            this.createNinjaRankingRaportButton.Name = "CreateNinjaRankingRaportButton";
            this.createNinjaRankingRaportButton.Size = new System.Drawing.Size(151, 106);
            this.createNinjaRankingRaportButton.TabIndex = 7;
            this.createNinjaRankingRaportButton.Text = "CreateNinja ranking raport (from MySQL and SQLite to Exel)";
            this.createNinjaRankingRaportButton.UseVisualStyleBackColor = true;
            this.createNinjaRankingRaportButton.Click += new System.EventHandler(this.CreateNinjaRankingRaport);
            // 
            // SetMongoDbForTestingButton
            // 
            this.setMongoDbForTestingButton.Location = new System.Drawing.Point(12, 236);
            this.setMongoDbForTestingButton.Name = "SetMongoDbForTestingButton";
            this.setMongoDbForTestingButton.Size = new System.Drawing.Size(175, 37);
            this.setMongoDbForTestingButton.TabIndex = 8;
            this.setMongoDbForTestingButton.Text = "Fill MongoDB for testing";
            this.setMongoDbForTestingButton.UseVisualStyleBackColor = true;
            this.setMongoDbForTestingButton.Click += new System.EventHandler(this.SetMongoDbForTesting);
            // 
            // LoadNinjaCatalogueToMySqlDirectlyButton
            // 
            this.loadNinjaCatalogueToMySqlDirectlyButton.Location = new System.Drawing.Point(12, 365);
            this.loadNinjaCatalogueToMySqlDirectlyButton.Name = "LoadNinjaCatalogueToMySqlDirectlyButton";
            this.loadNinjaCatalogueToMySqlDirectlyButton.Size = new System.Drawing.Size(207, 37);
            this.loadNinjaCatalogueToMySqlDirectlyButton.TabIndex = 9;
            this.loadNinjaCatalogueToMySqlDirectlyButton.Text = "Load Catalogue to MySQL (directly)";
            this.loadNinjaCatalogueToMySqlDirectlyButton.UseVisualStyleBackColor = true;
            this.loadNinjaCatalogueToMySqlDirectlyButton.Click += new System.EventHandler(this.LoadNinjaCatalogueToMySqlDirectly);
            // 
            // NinjaFactoryApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(804, 543);
            this.Controls.Add(this.loadNinjaCatalogueToMySqlDirectlyButton);
            this.Controls.Add(this.setMongoDbForTestingButton);
            this.Controls.Add(this.createNinjaRankingRaportButton);
            this.Controls.Add(this.createIncomeReportButton);
            this.Controls.Add(this.createNinjaCatalogueButton);
            this.Controls.Add(this.removeLostNinjasButton);
            this.Controls.Add(this.createReportForLostNinjasButton);
            this.Controls.Add(this.loadCatalogueInMySQLButton);
            this.Controls.Add(this.getReportsAndFinalizeOrdersButton);
            this.Controls.Add(this.addNewOrdersButton);
            this.Name = "NinjaFactoryApp";
            this.Text = "Ninja Factory - TeamBlackDragon";
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        #endregion
    }
}