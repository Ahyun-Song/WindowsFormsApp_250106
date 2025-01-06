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
            backgroundWorker.WorkerReportsProgress = true; // Progress 보고 활성화
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;

        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // 리스트박스에 파일을 추가합니다. (e.UserState는 파일 리스트)
            var files = e.UserState as List<string>;
            if (files != null)
            {
                listBox_files.Items.AddRange(files.ToArray());
            }
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button_search.Enabled = true;

            if (e.Result is string errorMessage)
            {
                MessageBox.Show($"An error occurred: {errorMessage}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (e.Result is List<string> files)
            {
                // 모든 파일이 처리된 후, 파일이 하나도 없다면 메시지를 띄움
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
                // 파일 목록을 가져옴
                var allFiles = Directory.EnumerateFiles(directory, $"*.{extension}", SearchOption.AllDirectories).ToList();

                // 파일들을 작은 덩어리로 나누어 ProgressChanged를 호출하여 UI에 추가
                const int chunkSize = 10; // 한 번에 처리할 파일 수
                for (int i = 0; i < allFiles.Count; i += chunkSize)
                {
                    var chunk = allFiles.Skip(i).Take(chunkSize).ToList();
                    // ProgressChanged 이벤트를 호출하여 UI에 덩어리별로 파일을 추가
                    backgroundWorker.ReportProgress(0, chunk);
                }

                // 모든 파일을 다 처리한 후에는 최종 결과로 파일 목록을 반환
                e.Result = allFiles;
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
