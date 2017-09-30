using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Project
{
    partial class MyForm
    {
        bool WasBMeaningClickedLast;
        int numberOfDates1, numberOfDates2, numberOfDates3, numberOfDates4, numberOfDatesAtAll, nowNumber, nowNumberArray;
        int tempNumberOfDates1, tempNumberOfDates2, tempNumberOfDates3, tempNumberOfDates4;
        string[] arrayOfDates1, arrayOpred1, arrayOfDates2, arrayOpred2, arrayOfDates3, arrayOpred3, arrayOfDates4, arrayOpred4;
        Label lShowDates, lnumberOfDates, lnumberOfTermins;
        Button bStart, bStop, bMeaning, bGoToMenu;
        CheckBox cbFirstGroup, cbSecondGroup, cbThirdGroup, cbFouthGroup;
        Timer timer = new Timer();

        private void InitializeGame()
        {
            WasBMeaningClickedLast = false;
            numberOfDatesAtAll = 0;
            GetDates();

            this.MinimumSize = new Size(900, 500);
            this.Size = this.MinimumSize;
            
            cbFirstGroup = new CheckBox();
            cbFirstGroup.Parent = this;
            cbFirstGroup.Text = "20-21 века";
            cbFirstGroup.Font = new Font("Arial", 10, FontStyle.Bold);
            cbFirstGroup.Width = 130;
            cbFirstGroup.Checked = true;
            cbFirstGroup.Click += CbFirstGroup_Click;
            
            cbSecondGroup = new CheckBox();
            cbSecondGroup.Parent = this;
            cbSecondGroup.Text = "18-19 века";
            cbSecondGroup.Font = new Font("Arial", 10, FontStyle.Bold);
            cbSecondGroup.Width = 130;
            cbSecondGroup.Checked = true;
            cbSecondGroup.Click += CbSecondGroup_Click;
            
            cbThirdGroup = new CheckBox();
            cbThirdGroup.Parent = this;
            cbThirdGroup.Text = "16-17 века";
            cbThirdGroup.Font = new Font("Arial", 10, FontStyle.Bold);
            cbThirdGroup.Width = 130;
            cbThirdGroup.Checked = true;
            cbThirdGroup.Click += CbThirdGroup_Click;
            
            cbFouthGroup = new CheckBox();
            cbFouthGroup.Parent = this;
            cbFouthGroup.Text = "14-15 века";
            cbFouthGroup.Font = new Font("Arial", 10, FontStyle.Bold);
            cbFouthGroup.Width = 130;
            cbFouthGroup.Checked = true;
            cbFouthGroup.Click += CbFouthGroup_Click;
            
            bGoToMenu = new Button();
            bGoToMenu.Parent = this;
            bGoToMenu.Text = "МЕНЮ";
            bGoToMenu.Size = new Size(120, 40);
            bGoToMenu.Font = new Font("Arial", 20, FontStyle.Bold);
            bGoToMenu.FlatStyle = FlatStyle.Flat;
            bGoToMenu.FlatAppearance.BorderColor = Color.Black;
            bGoToMenu.FlatAppearance.BorderSize = 1;
            bGoToMenu.Click += BGoToMenu_Click;
            
            lShowDates = new Label();
            lShowDates.Parent = this;
            lShowDates.Text = "Чтобы начать нажмите на СТАРТ";
            lShowDates.Size = new Size(700, 100);
            lShowDates.Font = new Font("Arial", 30, FontStyle.Bold);

            lnumberOfDates = new Label();
            lnumberOfDates.Parent = this;
            lnumberOfDates.Text = (numberOfDatesAtAll).ToString();
            lnumberOfDates.Size = new Size(50, 50);
            lnumberOfDates.Font = new Font("Arial", 25, FontStyle.Bold);

            lnumberOfTermins = new Label();
            lnumberOfTermins.Parent = this;
            lnumberOfTermins.Text = "Выбрано дат:";
            lnumberOfTermins.Size = new Size(300, 100);
            lnumberOfTermins.Font = new Font("Arial", 17, FontStyle.Bold);

            bStart = new Button();
            bStart.Parent = this;
            bStart.Text = "СТАРТ";
            bStart.Size = new Size(200, 150);
            bStart.Font = new Font("Arial", 25, FontStyle.Bold);
            bStart.FlatStyle = FlatStyle.Flat;
            bStart.FlatAppearance.BorderColor = Color.Black;
            bStart.FlatAppearance.BorderSize = 1;
            bStart.Click += BStart_Click;

            bStop = new Button();
            bStop.Parent = this;
            bStop.Text = "СТОП";
            bStop.Size = new Size(200, 150);
            bStop.Font = new Font("Arial", 25, FontStyle.Bold);
            bStop.FlatStyle = FlatStyle.Flat;
            bStop.FlatAppearance.BorderColor = Color.Black;
            bStop.FlatAppearance.BorderSize = 1;
            bStop.Click += BStop_Click;

            bMeaning = new Button();
            bMeaning.Parent = this;
            bMeaning.Text = "СОБЫТИЕ";
            bMeaning.Size = new Size(0, 0);
            bMeaning.Font = new Font("Arial", 25, FontStyle.Bold);
            bMeaning.FlatStyle = FlatStyle.Flat;
            bMeaning.FlatAppearance.BorderColor = Color.Black;
            bMeaning.FlatAppearance.BorderSize = 1;
            bMeaning.Click += BMeaning_Click;

            Resize += MyForm_Resize1;
            ReplaceAllBlocksGame();
        }

        private void MyForm_Resize1(object sender, EventArgs e)
        {
            ReplaceAllBlocksGame();
        }

        private void ReplaceAllBlocksGame()
        {
            cbFirstGroup.Left = this.Width - 150;
            cbFirstGroup.Top = 90;

            cbSecondGroup.Left = this.Width - 150;
            cbSecondGroup.Top = 115;

            cbThirdGroup.Left = this.Width - 150;
            cbThirdGroup.Top = 140;

            cbFouthGroup.Left = this.Width - 150;
            cbFouthGroup.Top = 165;

            bGoToMenu.Left = this.Width - 150;
            bGoToMenu.Top = 10;

            lnumberOfDates.Left = (this.Width / 2) - 270;
            lnumberOfDates.Top = (this.Height / 2) - 229;

            lnumberOfTermins.Left = (this.Width / 2) - 432;
            lnumberOfTermins.Top = (this.Height / 2) - 220;

            bStart.Left = (this.Width / 2) - 430;
            bStart.Top = this.Height / 2;

            bStop.Left = (this.Width / 2) - 210;
            bStop.Top = this.Height / 2;

            bMeaning.Left = (this.Width / 2) + 10;
            bMeaning.Top = this.Height / 2;

            if(WasBMeaningClickedLast)
            {
                //lShowDates.Left = (this.Width / 2) - 435;
                //lShowDates.Top = (this.Height / 2) - 100;
                lShowDates.Top = (this.Height / 2) - 170;
                lShowDates.Left = (this.Width / 2) - 430;
            }
            else
            {
                lShowDates.Left = (this.Width / 2) - 435;
                lShowDates.Top = (this.Height / 2) - 100;
                //lShowDates.Top = (this.Height / 2) - 170;
                //lShowDates.Left = (this.Width / 2) - 430;
            }
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
            WasBMeaningClickedLast = false;
            DeleteAllFromGame();
            timer.Stop();
            InitializeChooze();
        }

        private void BMeaning_Click(object sender, EventArgs e)
        {
            lShowDates.Text += " - ";
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
            bMeaning.Size = new Size(0, 0);
            WasBMeaningClickedLast = true;
            ReplaceAllBlocksGame();
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
                bStart.Size = new Size(200, 150);
                bMeaning.Size = new Size(200, 150);
                WasBMeaningClickedLast = false;
                ReplaceAllBlocksGame();
            }
        }

        private void BStart_Click(object sender, EventArgs e)
        {
            WasBMeaningClickedLast = false;
            ReplaceAllBlocksGame();
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
                if (nowNumber < numberOfDates2)
                {
                    lShowDates.Text = arrayOfDates2[nowNumber];
                    nowNumberArray = 2;
                }
                else
                {
                    nowNumber -= numberOfDates2;
                    if (nowNumber < numberOfDates3)
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
            ReplaceAllBlocksGame();
        }

        private void GetDates()
        {
            string path = "Dates.txt";
            string[] readText = File.ReadAllLines(path);
            numberOfDates1 = 0;
            numberOfDates2 = 0;
            numberOfDates3 = 0;
            numberOfDates4 = 0;
            numberOfDatesAtAll = 0;
            arrayOfDates1 = new string[readText.Length];
            arrayOpred1 = new string[readText.Length];
            arrayOfDates2 = new string[readText.Length];
            arrayOpred2 = new string[readText.Length];
            arrayOfDates3 = new string[readText.Length];
            arrayOpred3 = new string[readText.Length];
            arrayOfDates4 = new string[readText.Length];
            arrayOpred4 = new string[readText.Length];
            int temp1 = 0, temp2 = 0, temp3 = 0, temp4 = 0;
            foreach (string s in readText)
            {
                if((s[1] == '0') || (s[1] == '9'))
                {
                    numberOfDates1++;
                    arrayOfDates1[temp1] = s.Substring(0, 4);
                    arrayOpred1[temp1] = s.Substring(7);
                    temp1++;
                }
                else
                {
                    if ((s[1] == '7') || (s[1] == '8'))
                    {
                        numberOfDates2++;
                        arrayOfDates2[temp2] = s.Substring(0, 4);
                        arrayOpred2[temp2] = s.Substring(7);
                        temp2++;
                    }
                    else
                    {
                        if ((s[1] == '5') || (s[1] == '6'))
                        {
                            numberOfDates3++;
                            arrayOfDates3[temp3] = s.Substring(0, 4);
                            arrayOpred3[temp3] = s.Substring(7);
                            temp3++;
                        }
                        else
                        {
                            numberOfDates4++;
                            arrayOfDates4[temp4] = s.Substring(0, 4);
                            arrayOpred4[temp4] = s.Substring(7);
                            temp4++;
                        }
                    }
                }
            }
            numberOfDatesAtAll = numberOfDates1 + numberOfDates2 + numberOfDates3 + numberOfDates4;
            tempNumberOfDates1 = numberOfDates1;
            tempNumberOfDates2 = numberOfDates2;
            tempNumberOfDates3 = numberOfDates3;
            tempNumberOfDates4 = numberOfDates4;
            //string[] tempNumber = new string[numberOfDates1];
            //string[] tempOpred = new string[numberOfDates1];
            //int j = 0;
            //foreach (var str in readText)
            //{
            //    int i = 0;
            //    tempNumber[j] = "";
            //    while ((str[i] != ' ') && (str[i + 1] != '-'))
            //    {
            //        tempNumber[j] += str[i];
            //        i++;
            //    }
            //    i += 3;
            //    tempOpred[j] = "";
            //    try
            //    {
            //        while (str[i] != '\n')
            //        {
            //            tempOpred[j] += str[i];
            //            i++;
            //        }
            //    }
            //    catch { }
            //    j++;
            //}
            //this.arrayOfDates1 = tempNumber;
            //this.arrayOpred1 = tempOpred;
            //numberOfDatesAtAll += numberOfDates1;
            //tempNumberOfDates1 = numberOfDates1;
        }

        private void DeleteAllFromGame()
        {
            bGoToMenu.Size = new Size(0, 0);
            lShowDates.Size = new Size(0, 0);
            lnumberOfDates.Size = new Size(0, 0);
            lnumberOfTermins.Size = new Size(0, 0);
            bStart.Size = new Size(0, 0);
            bStop.Size = new Size(0, 0);
            bMeaning.Size = new Size(0, 0);
            cbFirstGroup.Size = new Size(0, 0);
            cbSecondGroup.Size = new Size(0, 0);
            cbThirdGroup.Size = new Size(0, 0);
            cbFouthGroup.Size = new Size(0, 0);
        }
    }
}
