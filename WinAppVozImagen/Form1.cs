using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace WinAppVozImagen
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine objVoz = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            buttonVoz.Focus();
            button1.Enabled = false;
            pictureBox1.Visible = false;
        }

        private void buttonVoz_Click(object sender, EventArgs e)
        {
            objVoz.SetInputToDefaultAudioDevice();
            objVoz.LoadGrammar(new DictationGrammar());
            objVoz.SpeechRecognized += enlazar;
            objVoz.RecognizeAsync(RecognizeMode.Multiple);
            buttonVoz.Enabled = false;
            button1.Enabled = true;
        }

        void enlazar(object sender, SpeechRecognizedEventArgs e)
        {
            textBox1.Text = e.Result.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            buttonVoz.Enabled = true;
            button1.Enabled = false;
            objVoz.RecognizeAsyncStop();
            pictureBox1.Visible = true;
            if (textBox1.Text == "Auto" || textBox1.Text == "Carro" || textBox1.Text == "Automóvil")
            {
                pictureBox1.Image = Properties.Resources.auto;
                pictureBox1.Refresh();
            }
            else if (textBox1.Text == "Pelota" || textBox1.Text == "Balón")
            {
                pictureBox1.Image = Properties.Resources.pelota;
                pictureBox1.Refresh();
            }
            else if (textBox1.Text == "Casa")
            {
                pictureBox1.Image = Properties.Resources.casa;
                pictureBox1.Refresh();
            }
            else {
                pictureBox1.Image = Properties.Resources._404;
                pictureBox1.Refresh();
            }
        }
    }
}
