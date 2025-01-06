namespace WindowsFormsApp_250106
{
    partial class Form2
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
            this.textBox_directory = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.listBox_files = new System.Windows.Forms.ListBox();
            this.textBox_extension = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_directory
            // 
            this.textBox_directory.Location = new System.Drawing.Point(74, 66);
            this.textBox_directory.Name = "textBox_directory";
            this.textBox_directory.Size = new System.Drawing.Size(377, 28);
            this.textBox_directory.TabIndex = 0;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(477, 66);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(84, 83);
            this.button_search.TabIndex = 1;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // listBox_files
            // 
            this.listBox_files.FormattingEnabled = true;
            this.listBox_files.ItemHeight = 18;
            this.listBox_files.Location = new System.Drawing.Point(74, 166);
            this.listBox_files.Name = "listBox_files";
            this.listBox_files.Size = new System.Drawing.Size(487, 238);
            this.listBox_files.TabIndex = 2;
            // 
            // textBox_extension
            // 
            this.textBox_extension.Location = new System.Drawing.Point(74, 121);
            this.textBox_extension.Name = "textBox_extension";
            this.textBox_extension.Size = new System.Drawing.Size(377, 28);
            this.textBox_extension.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(71, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Extension";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_extension);
            this.Controls.Add(this.listBox_files);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_directory);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_directory;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.ListBox listBox_files;
        private System.Windows.Forms.TextBox textBox_extension;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}