
namespace AccessApplication
{
    partial class EmployeeForm
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
            this.EmployeesComboBox = new System.Windows.Forms.ComboBox();
            this.GetSingleEmployeeButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ReadDatSetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // EmployeesComboBox
            // 
            this.EmployeesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EmployeesComboBox.FormattingEnabled = true;
            this.EmployeesComboBox.Location = new System.Drawing.Point(12, 12);
            this.EmployeesComboBox.Name = "EmployeesComboBox";
            this.EmployeesComboBox.Size = new System.Drawing.Size(256, 23);
            this.EmployeesComboBox.TabIndex = 0;
            // 
            // GetSingleEmployeeButton
            // 
            this.GetSingleEmployeeButton.Location = new System.Drawing.Point(291, 12);
            this.GetSingleEmployeeButton.Name = "GetSingleEmployeeButton";
            this.GetSingleEmployeeButton.Size = new System.Drawing.Size(75, 23);
            this.GetSingleEmployeeButton.TabIndex = 1;
            this.GetSingleEmployeeButton.Text = "button1";
            this.GetSingleEmployeeButton.UseVisualStyleBackColor = true;
            this.GetSingleEmployeeButton.Click += new System.EventHandler(this.GetSingleEmployeeButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(354, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // ReadDatSetButton
            // 
            this.ReadDatSetButton.Location = new System.Drawing.Point(12, 226);
            this.ReadDatSetButton.Name = "ReadDatSetButton";
            this.ReadDatSetButton.Size = new System.Drawing.Size(75, 23);
            this.ReadDatSetButton.TabIndex = 3;
            this.ReadDatSetButton.Text = "DataSet";
            this.ReadDatSetButton.UseVisualStyleBackColor = true;
            this.ReadDatSetButton.Click += new System.EventHandler(this.ReadDatSetButton_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 261);
            this.Controls.Add(this.ReadDatSetButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GetSingleEmployeeButton);
            this.Controls.Add(this.EmployeesComboBox);
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox EmployeesComboBox;
        private System.Windows.Forms.Button GetSingleEmployeeButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ReadDatSetButton;
    }
}