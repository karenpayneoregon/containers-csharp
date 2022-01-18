
namespace PupilsProject
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPupil = new System.Windows.Forms.DataGridView();
            this.FirstNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPupil)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPupil
            // 
            this.dgvPupil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPupil.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstNameColumn,
            this.LastNameColumn,
            this.BirthDateColumn});
            this.dgvPupil.Location = new System.Drawing.Point(37, 47);
            this.dgvPupil.Name = "dgvPupil";
            this.dgvPupil.Size = new System.Drawing.Size(392, 136);
            this.dgvPupil.TabIndex = 0;
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.DataPropertyName = "FirstName";
            this.FirstNameColumn.HeaderText = "First";
            this.FirstNameColumn.Name = "FirstNameColumn";
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.DataPropertyName = "LastName";
            this.LastNameColumn.HeaderText = "Last";
            this.LastNameColumn.Name = "LastNameColumn";
            // 
            // BirthDateColumn
            // 
            this.BirthDateColumn.DataPropertyName = "BirthDate";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.BirthDateColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.BirthDateColumn.HeaderText = "Birth";
            this.BirthDateColumn.Name = "BirthDateColumn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 230);
            this.Controls.Add(this.dgvPupil);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Code Sample";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPupil)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPupil;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDateColumn;
    }
}

