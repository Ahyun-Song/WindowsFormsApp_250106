using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp_250106
{
    public partial class Form1 : Form
    {
        private BackgroundWorker worker;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            /*while (true)
            {
                progressBar1.Value += 1;
                if (progressBar1.Value >= 100) break;
            }*/

            this.worker = new BackgroundWorker();
            // BackGroundWorker의 ReportProgress() 메소드 활용 여부, 보통 true
            this.worker.WorkerReportsProgress = true;
            // CancelAsync()로 BackgroundWorker를 멈출 수 있게 할지, 보통 true
            this.worker.WorkerSupportsCancellation = true;

            // BackgroundWorker가 UI스레드와 별개로 수행할 메소드
            this.worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            // ReportProgress() 메소드가 수행될 떄 실행될 메소드
            this.worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            // ReportProgress()가 100으로 호출되면 마지막에 한 번 실행되는 메소드
            this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_Completed);

            if (!this.worker.IsBusy)
            {
                this.worker.RunWorkerAsync();
            }

        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(30); // 30ms
                this.worker.ReportProgress(i);
            }
        }
        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // ProgressPercentage는 0~100 사이의 값을 가짐
            progressBar1.Value = e.ProgressPercentage;
        }
        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Complete");
        }

    }
}
