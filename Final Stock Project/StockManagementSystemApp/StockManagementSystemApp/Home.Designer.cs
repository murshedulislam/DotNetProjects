namespace StockManagementSystemApp
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.categorySetupLinkLabel = new System.Windows.Forms.LinkLabel();
            this.companySetupLinkLabel = new System.Windows.Forms.LinkLabel();
            this.stockOutLinkLabel = new System.Windows.Forms.LinkLabel();
            this.itemSetupLinkLabel = new System.Windows.Forms.LinkLabel();
            this.searchSummaryLinkLabel = new System.Windows.Forms.LinkLabel();
            this.stockInLinkLabel = new System.Windows.Forms.LinkLabel();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.searchViewLinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // categorySetupLinkLabel
            // 
            this.categorySetupLinkLabel.AutoSize = true;
            this.categorySetupLinkLabel.Location = new System.Drawing.Point(315, 60);
            this.categorySetupLinkLabel.Name = "categorySetupLinkLabel";
            this.categorySetupLinkLabel.Size = new System.Drawing.Size(80, 13);
            this.categorySetupLinkLabel.TabIndex = 0;
            this.categorySetupLinkLabel.TabStop = true;
            this.categorySetupLinkLabel.Text = "Category Setup";
            this.categorySetupLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.categorySetupLinkLabel_LinkClicked);
            // 
            // companySetupLinkLabel
            // 
            this.companySetupLinkLabel.AutoSize = true;
            this.companySetupLinkLabel.Location = new System.Drawing.Point(315, 97);
            this.companySetupLinkLabel.Name = "companySetupLinkLabel";
            this.companySetupLinkLabel.Size = new System.Drawing.Size(82, 13);
            this.companySetupLinkLabel.TabIndex = 0;
            this.companySetupLinkLabel.TabStop = true;
            this.companySetupLinkLabel.Text = "Company Setup";
            this.companySetupLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.companySetupLinkLabel_LinkClicked);
            // 
            // stockOutLinkLabel
            // 
            this.stockOutLinkLabel.AutoSize = true;
            this.stockOutLinkLabel.Location = new System.Drawing.Point(328, 218);
            this.stockOutLinkLabel.Name = "stockOutLinkLabel";
            this.stockOutLinkLabel.Size = new System.Drawing.Size(58, 13);
            this.stockOutLinkLabel.TabIndex = 0;
            this.stockOutLinkLabel.TabStop = true;
            this.stockOutLinkLabel.Text = "Stock Out ";
            this.stockOutLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.stockOutLinkLabel_LinkClicked);
            // 
            // itemSetupLinkLabel
            // 
            this.itemSetupLinkLabel.AutoSize = true;
            this.itemSetupLinkLabel.Location = new System.Drawing.Point(328, 141);
            this.itemSetupLinkLabel.Name = "itemSetupLinkLabel";
            this.itemSetupLinkLabel.Size = new System.Drawing.Size(58, 13);
            this.itemSetupLinkLabel.TabIndex = 0;
            this.itemSetupLinkLabel.TabStop = true;
            this.itemSetupLinkLabel.Text = "Item Setup";
            this.itemSetupLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.itemSetupLinkLabel_LinkClicked);
            // 
            // searchSummaryLinkLabel
            // 
            this.searchSummaryLinkLabel.AutoSize = true;
            this.searchSummaryLinkLabel.Location = new System.Drawing.Point(287, 256);
            this.searchSummaryLinkLabel.Name = "searchSummaryLinkLabel";
            this.searchSummaryLinkLabel.Size = new System.Drawing.Size(146, 13);
            this.searchSummaryLinkLabel.TabIndex = 0;
            this.searchSummaryLinkLabel.TabStop = true;
            this.searchSummaryLinkLabel.Text = "Search & View Item\'s Summary";
            this.searchSummaryLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.searchSummaryLinkLabel_LinkClicked);
            // 
            // stockInLinkLabel
            // 
            this.stockInLinkLabel.AutoSize = true;
            this.stockInLinkLabel.Location = new System.Drawing.Point(339, 179);
            this.stockInLinkLabel.Name = "stockInLinkLabel";
            this.stockInLinkLabel.Size = new System.Drawing.Size(47, 13);
            this.stockInLinkLabel.TabIndex = 0;
            this.stockInLinkLabel.TabStop = true;
            this.stockInLinkLabel.Text = "Stock In";
            this.stockInLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.stockInLinkLabel_LinkClicked);
            // 
            // linkLabel7
            // 
            this.linkLabel7.AutoSize = true;
            this.linkLabel7.Location = new System.Drawing.Point(328, 330);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(0, 13);
            this.linkLabel7.TabIndex = 0;
            // 
            // searchViewLinkLabel
            // 
            this.searchViewLinkLabel.AutoSize = true;
            this.searchViewLinkLabel.Location = new System.Drawing.Point(278, 294);
            this.searchViewLinkLabel.Name = "searchViewLinkLabel";
            this.searchViewLinkLabel.Size = new System.Drawing.Size(165, 13);
            this.searchViewLinkLabel.TabIndex = 1;
            this.searchViewLinkLabel.TabStop = true;
            this.searchViewLinkLabel.Text = "View Between Two Dates Report";
            this.searchViewLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.searchViewLinkLabel_LinkClicked);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchViewLinkLabel);
            this.Controls.Add(this.stockInLinkLabel);
            this.Controls.Add(this.linkLabel7);
            this.Controls.Add(this.searchSummaryLinkLabel);
            this.Controls.Add(this.itemSetupLinkLabel);
            this.Controls.Add(this.stockOutLinkLabel);
            this.Controls.Add(this.companySetupLinkLabel);
            this.Controls.Add(this.categorySetupLinkLabel);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel categorySetupLinkLabel;
        private System.Windows.Forms.LinkLabel companySetupLinkLabel;
        private System.Windows.Forms.LinkLabel stockOutLinkLabel;
        private System.Windows.Forms.LinkLabel itemSetupLinkLabel;
        private System.Windows.Forms.LinkLabel searchSummaryLinkLabel;
        private System.Windows.Forms.LinkLabel stockInLinkLabel;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.LinkLabel searchViewLinkLabel;
    }
}