using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace ProgramForFriend
{
    class MyForm : Form
    {
        int numberOfDates1, numberOfDates2, numberOfDates3, numberOfDates4, numberOfDatesAtAll, nowNumber, nowNumberArray;
        int tempNumberOfDates1, tempNumberOfDates2, tempNumberOfDates3, tempNumberOfDates4;
        string[] arrayOfDates1, arrayOpred1, arrayOfDates2, arrayOpred2, arrayOfDates3, arrayOpred3, arrayOfDates4, arrayOpred4;
        Label lShowDates, lnumberOfDates, lnumberOfTermins, lMenuText1, lMenuText2;
        Button bStart, bStop, bMeaning, bPlay, bEdit, bGoToMenu;
        CheckBox cbFirstGroup, cbSecondGroup, cbThirdGroup, cbFouthGroup;
        Timer timer = new Timer();
        
        public MyForm()
        {
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
            lMenuText1.Size = new Size(0, 0);
            lMenuText2.Size = new Size(0, 0);
            bPlay.Size = new Size(0, 0);
            bEdit.Size = new Size(0, 0);
            //InitializeEdit();
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
            numberOfDatesAtAll = 0;
            GetFirstGroup();
            GetSecondGroup();
            GetThirdGroup();
            GetFouthGroup();

            this.MaximumSize = this.MinimumSize = new Size(900, 500);
            this.Size = this.MaximumSize;
            this.Text = "Russian rulette";

            cbFirstGroup = new CheckBox();
            cbFirstGroup.Parent = this;
            cbFirstGroup.Text = "1 Group";
            cbFirstGroup.Font = new Font("Arial", 10, FontStyle.Bold);
            cbFirstGroup.Top = 100;
            cbFirstGroup.Left = 750;
            cbFirstGroup.Checked = true;
            cbFirstGroup.Click += CbFirstGroup_Click;

            cbSecondGroup = new CheckBox();
            cbSecondGroup.Parent = this;
            cbSecondGroup.Text = "2 Group";
            cbSecondGroup.Font = new Font("Arial", 10, FontStyle.Bold);
            cbSecondGroup.Top = 125;
            cbSecondGroup.Left = 750;
            cbSecondGroup.Checked = true;
            cbSecondGroup.Click += CbSecondGroup_Click;

            cbThirdGroup = new CheckBox();
            cbThirdGroup.Parent = this;
            cbThirdGroup.Text = "3 Group";
            cbThirdGroup.Font = new Font("Arial", 10, FontStyle.Bold);
            cbThirdGroup.Top = 150;
            cbThirdGroup.Left = 750;
            cbThirdGroup.Checked = true;
            cbThirdGroup.Click += CbThirdGroup_Click;

            cbFouthGroup = new CheckBox();
            cbFouthGroup.Parent = this;
            cbFouthGroup.Text = "4 Group";
            cbFouthGroup.Font = new Font("Arial", 10, FontStyle.Bold);
            cbFouthGroup.Top = 175;
            cbFouthGroup.Left = 750;
            cbFouthGroup.Checked = true;
            cbFouthGroup.Click += CbFouthGroup_Click;

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
            lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
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

        private void CbFirstGroup_Click(object sender, EventArgs e)
        {
            if (cbFirstGroup.Checked == false)
            {
                numberOfDatesAtAll -= numberOfDates1;
                numberOfDates1 = 0;
                lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            }
            else
            {
                numberOfDates1 = tempNumberOfDates1;
                numberOfDatesAtAll += numberOfDates1;
                lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            }
        }

        private void CbSecondGroup_Click(object sender, EventArgs e)
        {
            if (cbSecondGroup.Checked == false)
            {
                numberOfDatesAtAll -= numberOfDates2;
                numberOfDates2 = 0;
                lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            }
            else
            {
                numberOfDates2 = tempNumberOfDates2;
                numberOfDatesAtAll += numberOfDates2;
                lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            }
        }

        private void CbThirdGroup_Click(object sender, EventArgs e)
        {
            if (cbThirdGroup.Checked == false)
            {
                numberOfDatesAtAll -= numberOfDates3;
                numberOfDates3 = 0;
                lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            }
            else
            {
                numberOfDates3 = tempNumberOfDates3;
                numberOfDatesAtAll += numberOfDates3;
                lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            }
        }

        private void CbFouthGroup_Click(object sender, EventArgs e)
        {
            if (cbFouthGroup.Checked == false)
            {
                numberOfDatesAtAll -= numberOfDates4;
                numberOfDates4 = 0;
                lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            }
            else
            {
                numberOfDates4 = tempNumberOfDates4;
                numberOfDatesAtAll += numberOfDates4;
                lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            }
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
            timer.Stop();
            InitializeChooze();
        }

        private void BMeaning_Click(object sender, EventArgs e)
        {
            lShowDates.Text += " - " ;
            if (nowNumberArray == 1)
            {
                lShowDates.Text += arrayOpred1[nowNumber];
            }
            if (nowNumberArray == 2)
            {
                lShowDates.Text += arrayOpred2[nowNumber];
            }
            if (nowNumberArray == 3)
            {
                lShowDates.Text += arrayOpred3[nowNumber];
            }
            if (nowNumberArray == 4)
            {
                lShowDates.Text += arrayOpred4[nowNumber];
            }
            lShowDates.Font = new Font("Arial", 15, FontStyle.Bold);
            lShowDates.Top = 100;
            bMeaning.Size = new Size(0, 0);
        }
        
        private void BStop_Click(object sender, EventArgs e)
        {
            if (numberOfDatesAtAll != 0)
            {
                timer.Stop();
                if (nowNumberArray == 1)
                {
                    lShowDates.Text = arrayOfDates1[nowNumber];
                }
                if (nowNumberArray == 2)
                {
                    lShowDates.Text = arrayOfDates2[nowNumber];
                }
                if (nowNumberArray == 3)
                {
                    lShowDates.Text = arrayOfDates3[nowNumber];
                }
                if (nowNumberArray == 4)
                {
                    lShowDates.Text = arrayOfDates4[nowNumber];
                }
                lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
                lShowDates.Top = 150;
                bStart.Size = new Size(200, 150);
                bMeaning.Size = new Size(200, 150);
            }
        }
        
        private void BStart_Click(object sender, EventArgs e)
        {
            if (numberOfDatesAtAll == 0)
            {
                lShowDates.Text = "Sorry, there isn't any dates(";
            }
            else
            {
                timer.Interval = 80;
                timer.Start();
                timer.Tick += Timer_Tick;
                bStart.Size = new Size(0, 0);
                bMeaning.Size = new Size(0, 0);
            }
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            nowNumber = rnd.Next(numberOfDatesAtAll);
            if (nowNumber < numberOfDates1)
            {
                lShowDates.Text = arrayOfDates1[nowNumber];
                nowNumberArray = 1;
            }
            else
            {
                nowNumber -= numberOfDates1;
                if(nowNumber < numberOfDates2)
                {
                    lShowDates.Text = arrayOfDates2[nowNumber];
                    nowNumberArray = 2;
                }
                else
                {
                    nowNumber -= numberOfDates2;
                    if(nowNumber < numberOfDates3)
                    {
                        lShowDates.Text = arrayOfDates3[nowNumber];
                        nowNumberArray = 3;
                    }
                    else
                    {
                        nowNumber -= numberOfDates3;
                        lShowDates.Text = arrayOfDates4[nowNumber];
                        nowNumberArray = 4;
                    }
                }
            }
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);
            lShowDates.Top = 150;
        }

        private void GetFirstGroup()
        {
            string path = "Dates1.txt";
            string[] readText = File.ReadAllLines(path);
            numberOfDates1 = 0;
            foreach (string s in readText)
            {
                numberOfDates1++;
            }
            string[] tempNumber = new string[numberOfDates1];
            string[] tempOpred = new string[numberOfDates1];
            int j = 0;
            foreach (var str in readText)
            {
                int i = 0;
                tempNumber[j] = "";
                while ((str[i] != ' ') && (str[i + 1] != '-'))
                {
                    tempNumber[j] += str[i];
                    i++;
                }
                i += 3;
                tempOpred[j] = "";
                try
                {
                    while (str[i] != '\n')
                    {
                        tempOpred[j] += str[i];
                        i++;
                    }
                }
                catch { }
                j++;
            }
            this.arrayOfDates1 = tempNumber;
            this.arrayOpred1 = tempOpred;
            numberOfDatesAtAll += numberOfDates1;
            tempNumberOfDates1 = numberOfDates1;
        }

        private void GetSecondGroup()
        {
            string path = "Dates2.txt";
            string[] readText = File.ReadAllLines(path);
            numberOfDates2 = 0;
            foreach (string s in readText)
            {
                numberOfDates2++;
            }
            string[] tempNumber = new string[numberOfDates2];
            string[] tempOpred = new string[numberOfDates2];
            int j = 0;
            foreach (var str in readText)
            {
                int i = 0;
                tempNumber[j] = "";
                while ((str[i] != ' ') && (str[i + 1] != '-'))
                {
                    tempNumber[j] += str[i];
                    i++;
                }
                i += 3;
                tempOpred[j] = "";
                try
                {
                    while (str[i] != '\n')
                    {
                        tempOpred[j] += str[i];
                        i++;
                    }
                }
                catch { }
                j++;
            }
            this.arrayOfDates2 = tempNumber;
            this.arrayOpred2 = tempOpred;
            numberOfDatesAtAll += numberOfDates2;
            tempNumberOfDates2 = numberOfDates2;
        }

        private void GetThirdGroup()
        {
            string path = "Dates3.txt";
            string[] readText = File.ReadAllLines(path);
            numberOfDates3 = 0;
            foreach (string s in readText)
            {
                numberOfDates3++;
            }
            string[] tempNumber = new string[numberOfDates3];
            string[] tempOpred = new string[numberOfDates3];
            int j = 0;
            foreach (var str in readText)
            {
                int i = 0;
                tempNumber[j] = "";
                while ((str[i] != ' ') && (str[i + 1] != '-'))
                {
                    tempNumber[j] += str[i];
                    i++;
                }
                i += 3;
                tempOpred[j] = "";
                try
                {
                    while (str[i] != '\n')
                    {
                        tempOpred[j] += str[i];
                        i++;
                    }
                }
                catch { }
                j++;
            }
            this.arrayOfDates3 = tempNumber;
            this.arrayOpred3 = tempOpred;
            numberOfDatesAtAll += numberOfDates3;
            tempNumberOfDates3 = numberOfDates3;
        }

        private void GetFouthGroup()
        {
            string path = "Dates4.txt";
            string[] readText = File.ReadAllLines(path);
            numberOfDates4 = 0;
            foreach (string s in readText)
            {
                numberOfDates4++;
            }
            string[] tempNumber = new string[numberOfDates4];
            string[] tempOpred = new string[numberOfDates4];
            int j = 0;
            foreach (var str in readText)
            {
                int i = 0;
                tempNumber[j] = "";
                while ((str[i] != ' ') && (str[i + 1] != '-'))
                {
                    tempNumber[j] += str[i];
                    i++;
                }
                i += 3;
                tempOpred[j] = "";
                try
                {
                    while (str[i] != '\n')
                    {
                        tempOpred[j] += str[i];
                        i++;
                    }
                }
                catch { }
                j++;
            }
            this.arrayOfDates4 = tempNumber;
            this.arrayOpred4 = tempOpred;
            numberOfDatesAtAll += numberOfDates4;
            tempNumberOfDates4 = numberOfDates4;
        }
        
        //private void InitializeEdit()
        //{

        //}
    }
}
