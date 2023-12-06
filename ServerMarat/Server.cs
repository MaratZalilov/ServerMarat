using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace ServerMarat
{
    public partial class Server : Form
    {
        private TcpListener _listener;

        private string _answerAndQuestion = null;
        private string _path = null;

        public Server()
        {
            InitializeComponent();
        }

        private void ButtonToConnect_Click(object sender, EventArgs e)
        {
            ReadTheAnswerAndQuestion();
            SendQuestionAndAnswer();

        }
        private void ButtonForUploadingQuestions_Click(object sender, EventArgs e)
        {

        }
        private void ButtonForGettingAnswers_Click(object sender, EventArgs e)
        {

        }

        public async void SendQuestionAndAnswer()
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            _listener = new TcpListener(ipPoint);
            try
            {
                
               _listener.Start();
                MessageBox.Show("Сервер запущен");
               TcpClient handler = await _listener.AcceptTcpClientAsync();
               NetworkStream stream = handler.GetStream();
                stream.Write(Encoding.UTF8.GetBytes(_answerAndQuestion),0, _answerAndQuestion.Length);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ReadTheAnswerAndQuestion()
        {
            
            string name;
            try
            {
                StreamReader sr = new StreamReader(@_path);
                for (int i = 0; i < 5; i++)
                {
                    name = sr.ReadLine();

                    _answerAndQuestion += name;
                    _answerAndQuestion += '\n';
                   

                };
                MessageBox.Show(_answerAndQuestion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = null;
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;
            _path = Path.GetFullPath(fileName);

            MessageBox.Show(_path);
        }

        
    }

}
