
namespace ISIT310_DataAdapterReads2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.moveFirst = new System.Windows.Forms.Button();
            this.moveNext = new System.Windows.Forms.Button();
            this.movePrevious = new System.Windows.Forms.Button();
            this.moveLast = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(56, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(686, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(56, 219);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 25;
            this.dataGridView2.Size = new System.Drawing.Size(686, 150);
            this.dataGridView2.TabIndex = 1;
            // 
            // moveFirst
            // 
            this.moveFirst.Location = new System.Drawing.Point(56, 398);
            this.moveFirst.Name = "moveFirst";
            this.moveFirst.Size = new System.Drawing.Size(75, 23);
            this.moveFirst.TabIndex = 2;
            this.moveFirst.Text = "Move First";
            this.moveFirst.UseVisualStyleBackColor = true;
            this.moveFirst.Click += new System.EventHandler(this.moveFirst_Click);
            // 
            // moveNext
            // 
            this.moveNext.Location = new System.Drawing.Point(137, 398);
            this.moveNext.Name = "moveNext";
            this.moveNext.Size = new System.Drawing.Size(75, 23);
            this.moveNext.TabIndex = 3;
            this.moveNext.Text = "Move Next";
            this.moveNext.UseVisualStyleBackColor = true;
            this.moveNext.Click += new System.EventHandler(this.moveNext_Click);
            // 
            // movePrevious
            // 
            this.movePrevious.Location = new System.Drawing.Point(218, 398);
            this.movePrevious.Name = "movePrevious";
            this.movePrevious.Size = new System.Drawing.Size(97, 23);
            this.movePrevious.TabIndex = 4;
            this.movePrevious.Text = "Move Previous";
            this.movePrevious.UseVisualStyleBackColor = true;
            this.movePrevious.Click += new System.EventHandler(this.movePrevious_Click);
            // 
            // moveLast
            // 
            this.moveLast.Location = new System.Drawing.Point(321, 398);
            this.moveLast.Name = "moveLast";
            this.moveLast.Size = new System.Drawing.Size(75, 23);
            this.moveLast.TabIndex = 5;
            this.moveLast.Text = "Move Last";
            this.moveLast.UseVisualStyleBackColor = true;
            this.moveLast.Click += new System.EventHandler(this.moveLast_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.moveLast);
            this.Controls.Add(this.movePrevious);
            this.Controls.Add(this.moveNext);
            this.Controls.Add(this.moveFirst);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button moveFirst;
        private System.Windows.Forms.Button moveNext;
        private System.Windows.Forms.Button movePrevious;
        private System.Windows.Forms.Button moveLast;
    }
}

