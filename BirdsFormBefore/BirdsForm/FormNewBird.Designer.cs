namespace BirdsForm
{
    partial class FormNewBird
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
            this.textBoxBirdName = new System.Windows.Forms.TextBox();
            this.buttonNewBird = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(226, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add a new type of Bird";
            // 
            // textBoxBirdName
            // 
            this.textBoxBirdName.Location = new System.Drawing.Point(230, 122);
            this.textBoxBirdName.Name = "textBoxBirdName";
            this.textBoxBirdName.Size = new System.Drawing.Size(226, 20);
            this.textBoxBirdName.TabIndex = 1;
            // 
            // buttonNewBird
            // 
            this.buttonNewBird.Location = new System.Drawing.Point(297, 273);
            this.buttonNewBird.Name = "buttonNewBird";
            this.buttonNewBird.Size = new System.Drawing.Size(188, 23);
            this.buttonNewBird.TabIndex = 2;
            this.buttonNewBird.Text = "Click to Enter New Bird Type";
            this.buttonNewBird.UseVisualStyleBackColor = true;
            this.buttonNewBird.Click += new System.EventHandler(this.buttonNewBird_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.Location = new System.Drawing.Point(227, 307);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(53, 20);
            this.labelStatus.TabIndex = 3;
            this.labelStatus.Text = "status";
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(230, 166);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(226, 20);
            this.textBoxID.TabIndex = 4;
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Location = new System.Drawing.Point(230, 214);
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.Size = new System.Drawing.Size(226, 20);
            this.textBoxDesc.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "NAME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "DESCRIPTION";
            // 
            // FormNewBird
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 482);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonNewBird);
            this.Controls.Add(this.textBoxBirdName);
            this.Controls.Add(this.label1);
            this.Name = "FormNewBird";
            this.Text = "FormNewBird";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBirdName;
        private System.Windows.Forms.Button buttonNewBird;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}