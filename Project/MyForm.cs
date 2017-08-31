using System;
using System.Windows.Forms;
using System.Drawing;

namespace ProgramForFriend
{
    class MyForm : Form
    {
        int numberOfDates;
        string[] arrayOfDates;
        string[] arrayOpred;
        Label lShowDates;
        Button bStart, bStop, bMeaning;
        Timer timer;
        int nowNumber;
        
        public MyForm(int numberOfDates, string[] arrayOfNumber, string[] arrayOpred)
        {
            this.numberOfDates = numberOfDates;
            this.arrayOfDates = arrayOfNumber;
            this.arrayOpred = arrayOpred;
            Initialize();
        }
        
        private void Initialize()
        {
            this.Size = new Size(900, 500);
            this.MaximumSize = this.MinimumSize = this.Size;
            this.Text = "Russian rulette";
            
            lShowDates = new Label();
            lShowDates.Parent = this;
            lShowDates.Text = "Let's start playing Russian rulette!";
            lShowDates.Size = new Size(700, 100);
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
            lShowDates.Top = 150;
            lShowDates.Left = 10;
            
            Label lnumberOfDates = new Label();
            lnumberOfDates.Parent = this;
            lnumberOfDates.Text = numberOfDates.ToString();
            lnumberOfDates.Size = new Size(50, 50);
            lnumberOfDates.Font = new Font("Arial", 25, FontStyle.Bold);
            lnumberOfDates.Top = 21;
            lnumberOfDates.Left = 225;
            
            Label lnumberOfTermins = new Label();
            lnumberOfTermins.Parent = this;
            lnumberOfTermins.Text = "Dates in input file:";
            lnumberOfTermins.Size = new Size(300, 100);
            lnumberOfTermins.Font = new Font("Arial", 17, FontStyle.Bold);
            lnumberOfTermins.Top = 30;
            lnumberOfTermins.Left = 15;
            
            bStart = new Button();
            bStart.Parent = this;
            bStart.Text = "START";
            bStart.Size = new Size(200, 150);
            bStart.Font = new Font("Arial", 25, FontStyle.Bold);
            bStart.Top = 250;
            bStart.Left = 100;
            bStart.FlatStyle = FlatStyle.Flat;
            bStart.FlatAppearance.BorderColor = Color.Black;
            bStart.FlatAppearance.BorderSize = 1;
            bStart.Click += BStart_Click;
            
            bStop = new Button();
            bStop.Parent = this;
            bStop.Text = "STOP";
            bStop.Size = new Size(200, 150);
            bStop.Font = new Font("Arial", 25, FontStyle.Bold);
            bStop.Top = 250;
            bStop.Left = 350;
            bStop.FlatStyle = FlatStyle.Flat;
            bStop.FlatAppearance.BorderColor = Color.Black;
            bStop.FlatAppearance.BorderSize = 1;
            bStop.Click += BStop_Click;
            
            bMeaning = new Button();
            bMeaning.Parent = this;
            bMeaning.Text = "MEANING";
            bMeaning.Size = new Size(0, 0);
            bMeaning.Font = new Font("Arial", 25, FontStyle.Bold);
            bMeaning.Top = 250;
            bMeaning.Left = 600;
            bMeaning.FlatStyle = FlatStyle.Flat;
            bMeaning.FlatAppearance.BorderColor = Color.Black;
            bMeaning.FlatAppearance.BorderSize = 1;
            bMeaning.Click += BMeaning_Click;
        }
        
        private void BMeaning_Click(object sender, EventArgs e)
        {
            lShowDates.Text += " - " ;
            lShowDates.Text += arrayOpred[nowNumber];
            lShowDates.Font = new Font("Arial", 15, FontStyle.Bold);
            lShowDates.Top = 100;
            bMeaning.Size = new Size(0, 0);
        }
        
        private void BStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            lShowDates.Text = arrayOfDates[nowNumber];
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
            lShowDates.Top = 150;
            bStart.Size = new Size(200, 150);
            bMeaning.Size = new Size(200, 150);
        }
        
        private void BStart_Click(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 80;
            timer.Start();
            timer.Tick += Timer_Tick;
            bStart.Size = new Size(0, 0);
            bMeaning.Size = new Size(0, 0);
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            nowNumber = rnd.Next(numberOfDates);
            lShowDates.Text = arrayOfDates[nowNumber];
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
            lShowDates.Top = 150;
        }
    }
}
