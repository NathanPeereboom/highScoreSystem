using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace _312840HighScoreTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] highScores = new string[5];
        string[] highScoreData;
       

        public MainWindow()
        {
            InitializeComponent();

            System.IO.StreamReader readHighScores = new System.IO.StreamReader("HighScores.txt");
            for (int i = 0; i < 5; i++)
            {
                highScores[i] = readHighScores.ReadLine();
            }
            readHighScores.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            int newScore;
            int oldScore;
            Int32.TryParse(txtScore.Text, out newScore);
            System.IO.StreamWriter writeHighScore = new System.IO.StreamWriter("HighScores.txt");
            for (int i = 0; i < 5; i++)
            {
                highScoreData = highScores[i].Split(new char[] { ',' });
                Int32.TryParse(highScoreData[1], out oldScore); 
                if (newScore > oldScore)
                {
                    highScores[i] = name + "," + newScore.ToString();
                    newScore = oldScore;
                    name = highScoreData[0];
                }
                writeHighScore.WriteLine(highScores[i]);
            }
            writeHighScore.Close();
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            lblOutput.Content = "";
            for (int i = 0; i < 5; i++)
            {
                highScoreData = highScores[i].Split(new char[] { ',' });
                lblOutput.Content += i+1 + ". " + highScoreData[0] + " " + highScoreData[1] + Environment.NewLine;
            }
        }
    }
}
