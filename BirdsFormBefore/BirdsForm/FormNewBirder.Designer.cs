namespace BirdsForm
{
    partial class FormNewBirder
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
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddNewBirder = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxBirderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(236, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add a new Birder";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(175, 157);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(285, 20);
            this.textBoxID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ID";
            // 
            // buttonAddNewBirder
            // 
            this.buttonAddNewBirder.Location = new System.Drawing.Point(175, 296);
            this.buttonAddNewBirder.Name = "buttonAddNewBirder";
            this.buttonAddNewBirder.Size = new System.Drawing.Size(165, 23);
            this.buttonAddNewBirder.TabIndex = 7;
            this.buttonAddNewBirder.Text = "Click to enter new Birder";
            this.buttonAddNewBirder.UseVisualStyleBackColor = true;
            this.buttonAddNewBirder.Click += new System.EventHandler(this.buttonAddNewBirder_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(240, 362);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(35, 13);
            this.labelStatus.TabIndex = 8;
            this.labelStatus.Text = "status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Birder Name";
            // 
            // textBoxBirderName
            // 
            this.textBoxBirderName.Location = new System.Drawing.Point(175, 183);
            this.textBoxBirderName.Name = "textBoxBirderName";
            this.textBoxBirderName.Size = new System.Drawing.Size(285, 20);
            this.textBoxBirderName.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Phone";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(175, 209);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(285, 20);
            this.textBoxPhone.TabIndex = 13;
            // 
            // FormNewBirder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 504);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxBirderName);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonAddNewBirder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label1);
            this.Name = "FormNewBirder";
            this.Text = "FormNewBirder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAddNewBirder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxBirderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPhone;
    }
}