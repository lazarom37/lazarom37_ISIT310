namespace BirdsForm
{
    partial class FormNewRegion
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRegionName = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddNewRegion = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(276, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add a new Region";
            // 
            // textBoxRegionName
            // 
            this.textBoxRegionName.Location = new System.Drawing.Point(220, 119);
            this.textBoxRegionName.Name = "textBoxRegionName";
            this.textBoxRegionName.Size = new System.Drawing.Size(278, 20);
            this.textBoxRegionName.TabIndex = 2;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(220, 155);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(278, 20);
            this.textBoxID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Region Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Region ID";
            // 
            // buttonAddNewRegion
            // 
            this.buttonAddNewRegion.Location = new System.Drawing.Point(220, 220);
            this.buttonAddNewRegion.Name = "buttonAddNewRegion";
            this.buttonAddNewRegion.Size = new System.Drawing.Size(244, 23);
            this.buttonAddNewRegion.TabIndex = 6;
            this.buttonAddNewRegion.Text = "Click to enter new Region";
            this.buttonAddNewRegion.UseVisualStyleBackColor = true;
            this.buttonAddNewRegion.Click += new System.EventHandler(this.buttonAddNewRegion_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(310, 282);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(35, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "status";
            // 
            // FormNewRegion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 477);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonAddNewRegion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxRegionName);
            this.Controls.Add(this.label1);
            this.Name = "FormNewRegion";
            this.Text = "FormNewRegion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRegionName;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddNewRegion;
        private System.Windows.Forms.Label labelStatus;
    }
}