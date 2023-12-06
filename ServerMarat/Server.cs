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
        TcpListener listener;

        private string _answerAndQuestion = null;
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
            listener = new TcpListener(ipPoint);
            try
            {
                
               listener.Start();
                MessageBox.Show("Сервер запущен");
               TcpClient handler = await listener.AcceptTcpClientAsync();
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
                StreamReader sr = new StreamReader(@"C:\Users\Пользователь\Source\Repos\Laboratory_Number_2\Laboratory_Number_1\QuestionAndAnswer\QuestionAndAnswer.txt");
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
            openFileDialog1.ShowDialog();
        }

        
    }

}
