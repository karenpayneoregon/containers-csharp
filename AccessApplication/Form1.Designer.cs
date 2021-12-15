
namespace AccessApplication
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.GetCurrentButton = new System.Windows.Forms.Button();
            this.ListButton = new System.Windows.Forms.Button();
            this.TableButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.CategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.ProductsDataGridView = new System.Windows.Forms.DataGridView();
            this.CurrentProductButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CurrentProductButton);
            this.panel1.Controls.Add(this.GetCurrentButton);
            this.panel1.Controls.Add(this.ListButton);
            this.panel1.Controls.Add(this.TableButton);
            this.panel1.Controls.Add(this.ConnectButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 43);
            this.panel1.TabIndex = 0;
            // 
            // GetCurrentButton
            // 
            this.GetCurrentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GetCurrentButton.Location = new System.Drawing.Point(589, 9);
            this.GetCurrentButton.Name = "GetCurrentButton";
            this.GetCurrentButton.Size = new System.Drawing.Size(75, 23);
            this.GetCurrentButton.TabIndex = 3;
            this.GetCurrentButton.Text = "Current";
            this.GetCurrentButton.UseVisualStyleBackColor = true;
            this.GetCurrentButton.Click += new System.EventHandler(this.GetCurrentButton_Click);
            // 
            // ListButton
            // 
            this.ListButton.Location = new System.Drawing.Point(176, 9);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(75, 23);
            this.ListButton.TabIndex = 2;
            this.ListButton.Text = "List";
            this.ListButton.UseVisualStyleBackColor = true;
            this.ListButton.Click += new System.EventHandler(this.ListButton_Click);
            // 
            // TableButton
            // 
            this.TableButton.Location = new System.Drawing.Point(86, 9);
            this.TableButton.Name = "TableButton";
            this.TableButton.Size = new System.Drawing.Size(75, 23);
            this.TableButton.TabIndex = 1;
            this.TableButton.Text = "Table";
            this.TableButton.UseVisualStyleBackColor = true;
            this.TableButton.Click += new System.EventHandler(this.TableButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(5, 9);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 0;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // CategoriesComboBox
            // 
            this.CategoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoriesComboBox.FormattingEnabled = true;
            this.CategoriesComboBox.Location = new System.Drawing.Point(24, 12);
            this.CategoriesComboBox.Name = "CategoriesComboBox";
            this.CategoriesComboBox.Size = new System.Drawing.Size(148, 23);
            this.CategoriesComboBox.TabIndex = 1;
            // 
            // ProductsDataGridView
            // 
            this.ProductsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductsDataGridView.Location = new System.Drawing.Point(13, 61);
            this.ProductsDataGridView.Name = "ProductsDataGridView";
            this.ProductsDataGridView.RowTemplate.Height = 25;
            this.ProductsDataGridView.Size = new System.Drawing.Size(651, 150);
            this.ProductsDataGridView.TabIndex = 2;
            // 
            // CurrentProductButton
            // 
            this.CurrentProductButton.Location = new System.Drawing.Point(280, 9);
            this.CurrentProductButton.Name = "CurrentProductButton";
            this.CurrentProductButton.Size = new System.Drawing.Size(118, 23);
            this.CurrentProductButton.TabIndex = 4;
            this.CurrentProductButton.Text = "Current product";
            this.CurrentProductButton.UseVisualStyleBackColor = true;
            this.CurrentProductButton.Click += new System.EventHandler(this.CurrentProductButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 292);
            this.Controls.Add(this.ProductsDataGridView);
            this.Controls.Add(this.CategoriesComboBox);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ProductsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.ComboBox CategoriesComboBox;
        private System.Windows.Forms.Button TableButton;
        private System.Windows.Forms.Button ListButton;
        private System.Windows.Forms.Button GetCurrentButton;
        private System.Windows.Forms.DataGridView ProductsDataGridView;
        private System.Windows.Forms.Button CurrentProductButton;
    }
}

