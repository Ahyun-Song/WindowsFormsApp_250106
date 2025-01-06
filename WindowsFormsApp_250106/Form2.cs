using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_250106
{
    public partial class Form2 : Form
    {
        private BackgroundWorker backgroundWorker;

        public Form2()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = false;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button_search.Enabled = true;

            if (e.Result is string errorMessage)
            {
                MessageBox.Show($"An error occurred: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Result is System.Collections.Generic.List<string> files)
            {
                listBox_files.Items.AddRange(files.ToArray());
                if (files.Count == 0)
                {
                    MessageBox.Show("No files found with the specified extension.", "No Files Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var (directory, extension) = ((string, string))e.Argument;

            try
            {
                var files = Directory.EnumerateFiles(directory, $"*.{extension}", SearchOption.AllDirectories).ToList();
                e.Result = files;
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
            }
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            string directory = textBox_directory.Text;
            string extension = textBox_extension.Text;

            if (string.IsNullOrWhiteSpace(directory) || string.IsNullOrWhiteSpace(extension))
            {
                MessageBox.Show("Please provide both directory and file extension.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(directory))
            {
                MessageBox.Show("The specified directory does not exist.", "Directory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBox_files.Items.Clear();
            button_search.Enabled = false;
            backgroundWorker.RunWorkerAsync((directory, extension));
        }
    }
}
