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
        Label lShowDates, lnumberOfDates, lnumberOfTermins, lMenuText1, lMenuText2;
        Button bStart, bStop, bMeaning, bPlay, bEdit, bGoToMenu;
        Timer timer = new Timer();
        int nowNumber;
        
        public MyForm(int numberOfDates, string[] arrayOfNumber, string[] arrayOpred)
        {
            this.numberOfDates = numberOfDates;
            this.arrayOfDates = arrayOfNumber;
            this.arrayOpred = arrayOpred;
            //InitializeChooze();
            InitializeGame();
        }


        private void InitializeChooze()
        {
            this.MaximumSize = this.MinimumSize = new Size(600, 400);
            this.Size = this.MaximumSize;
            this.Text = "Russian rulette";
            
            bPlay = new Button();
            bPlay.Parent = this;
            bPlay.Text = "PLAY";
            bPlay.Size = new Size(200, 150);
            bPlay.Font = new Font("Arial", 25, FontStyle.Bold);
            bPlay.Top = 180;
            bPlay.Left = 70;
            bPlay.FlatStyle = FlatStyle.Flat;
            bPlay.FlatAppearance.BorderColor = Color.Black;
            bPlay.FlatAppearance.BorderSize = 1;
            bPlay.Click += BPlay_Click;

            bEdit = new Button();
            bEdit.Parent = this;
            bEdit.Text = "EDIT";
            bEdit.Size = new Size(200, 150);
            bEdit.Font = new Font("Arial", 25, FontStyle.Bold);
            bEdit.Top = 180;
            bEdit.Left = 320;
            bEdit.FlatStyle = FlatStyle.Flat;
            bEdit.FlatAppearance.BorderColor = Color.Black;
            bEdit.FlatAppearance.BorderSize = 1;
            bEdit.Click += BEdit_Click;

            lMenuText1 = new Label();
            lMenuText1.Parent = this;
            lMenuText1.Font = new Font("Arial", 20, FontStyle.Bold);
            lMenuText1.Text = "Hi! This is russian rulette with dates.";
            lMenuText1.Size = new Size(500, 50);
            lMenuText1.Left = (this.Width / 2) - 250;
            lMenuText1.Top = 50;

            lMenuText2 = new Label();
            lMenuText2.Parent = this;
            lMenuText2.Font = new Font("Arial", 20, FontStyle.Bold);
            lMenuText2.Text = "Chooze what you want below:";
            lMenuText2.Size = new Size(500, 200);
            lMenuText2.Left = (this.Width / 2) - 210;
            lMenuText2.Top = 120;
        }

        private void BEdit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BPlay_Click(object sender, EventArgs e)
        {
            lMenuText1.Size = new Size(0, 0);
            lMenuText2.Size = new Size(0, 0);
            bPlay.Size = new Size(0, 0);
            bEdit.Size = new Size(0, 0);
            InitializeGame();
        }


        private void InitializeGame()
        {
            this.MaximumSize = this.MinimumSize = new Size(900, 500);
            this.Size = this.MaximumSize;

            this.Text = "Russian rulette";

            bGoToMenu = new Button();
            bGoToMenu.Parent = this;
            bGoToMenu.Text = "MENU";
            bGoToMenu.Size = new Size(120, 40);
            bGoToMenu.Font = new Font("Arial", 20, FontStyle.Bold);
            bGoToMenu.Top = 10;
            bGoToMenu.Left = 750;
            bGoToMenu.FlatStyle = FlatStyle.Flat;
            bGoToMenu.FlatAppearance.BorderColor = Color.Black;
            bGoToMenu.FlatAppearance.BorderSize = 1;
            bGoToMenu.Click += BGoToMenu_Click;

            lShowDates = new Label();
            lShowDates.Parent = this;
            lShowDates.Text = "Let's start playing Russian rulette!";
            lShowDates.Size = new Size(700, 100);
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
            lShowDates.Top = 150;
            lShowDates.Left = 10;
            
            lnumberOfDates = new Label();
            lnumberOfDates.Parent = this;
            lnumberOfDates.Text = numberOfDates.ToString();
            lnumberOfDates.Size = new Size(50, 50);
            lnumberOfDates.Font = new Font("Arial", 25, FontStyle.Bold);
            lnumberOfDates.Top = 21;
            lnumberOfDates.Left = 225;
            
            lnumberOfTermins = new Label();
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
            bStart.Left = 20;
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
            bStop.Left = 240;
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
            bMeaning.Left = 460;
            bMeaning.FlatStyle = FlatStyle.Flat;
            bMeaning.FlatAppearance.BorderColor = Color.Black;
            bMeaning.FlatAppearance.BorderSize = 1;
            bMeaning.Click += BMeaning_Click;
        }

        private void BGoToMenu_Click(object sender, EventArgs e)
        {
            bGoToMenu.Size = new Size(0, 0);
            lShowDates.Size = new Size(0, 0);
            lnumberOfDates.Size = new Size(0, 0);
            lnumberOfTermins.Size = new Size(0, 0);
            bStart.Size = new Size(0, 0);
            bStop.Size = new Size(0, 0);
            bMeaning.Size = new Size(0, 0);
            InitializeChooze();
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
