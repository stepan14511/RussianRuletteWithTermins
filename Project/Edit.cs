using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Project
{
    partial class MyForm
    {
        Button beGoToMenu, beAdd, beDelete;
        Label lAddNewDate, lMinus, lDeleteDate;
        TextBox tbNewDate, tbNewMeaning;
        ListBox lbDates;

        private void InitializeEdit()
        {
            this.MinimumSize = new Size(800, 500);
            this.Size = this.MinimumSize;

            beDelete = new Button();
            beDelete.Parent = this;
            beDelete.Text = "Удалить";
            beDelete.Size = new Size(85, 25);
            beDelete.Font = new Font("Arial", 10, FontStyle.Bold);
            beDelete.FlatStyle = FlatStyle.Flat;
            beDelete.FlatAppearance.BorderColor = Color.Black;
            beDelete.FlatAppearance.BorderSize = 1;
            beDelete.Click += BeDelete_Click;

            lbDates = new ListBox();
            lbDates.Parent = this;
            string path = "Dates.txt";
            string[] readText = File.ReadAllLines(path);
            Array.Sort(readText);
            Array.Reverse(readText);
            foreach (var s in readText) {
                lbDates.Items.Add(s.Substring(0, 4));
            }

            lDeleteDate = new Label();
            lDeleteDate.Parent = this;
            lDeleteDate.Text = "Удалить дату:";
            lDeleteDate.Size = new Size(700, 100);
            lDeleteDate.Font = new Font("Arial", 20, FontStyle.Bold);

            beAdd = new Button();
            beAdd.Parent = this;
            beAdd.Text = "Добавить";
            beAdd.Size = new Size(85, 25);
            beAdd.Font = new Font("Arial", 10, FontStyle.Bold);
            beAdd.FlatStyle = FlatStyle.Flat;
            beAdd.FlatAppearance.BorderColor = Color.Black;
            beAdd.FlatAppearance.BorderSize = 1;
            beAdd.Click += BeAdd_Click;

            tbNewMeaning = new TextBox();
            tbNewMeaning.Parent = this;

            lMinus = new Label();
            lMinus.Parent = this;
            lMinus.Text = "-";
            lMinus.Size = new Size(700, 100);
            lMinus.Font = new Font("Arial", 20, FontStyle.Bold);

            tbNewDate = new TextBox();
            tbNewDate.Parent = this;
            tbNewDate.Width = 100;
            tbNewDate.Height = 0;

            beGoToMenu = new Button();
            beGoToMenu.Parent = this;
            beGoToMenu.Text = "МЕНЮ";
            beGoToMenu.Size = new Size(120, 40);
            beGoToMenu.Font = new Font("Arial", 20, FontStyle.Bold);
            beGoToMenu.FlatStyle = FlatStyle.Flat;
            beGoToMenu.FlatAppearance.BorderColor = Color.Black;
            beGoToMenu.FlatAppearance.BorderSize = 1;
            beGoToMenu.Click += BeGoToMenu_Click;

            lAddNewDate = new Label();
            lAddNewDate.Parent = this;
            lAddNewDate.Text = "Добавить новую дату:";
            lAddNewDate.Size = new Size(700, 100);
            lAddNewDate.Font = new Font("Arial", 20, FontStyle.Bold);

            Resize += MyForm_Resize2;
            ReplaceAllBlocksEdit();
        }

        private void MyForm_Resize2(object sender, EventArgs e)
        {
            ReplaceAllBlocksEdit();
        }

        private void ReplaceAllBlocksEdit()
        {
            beDelete.Top = this.Height - 80;
            beDelete.Left = 20;

            lbDates.Top = 200;
            lbDates.Left = 20;
            if (lbDates.Width != 0)
            {
                lbDates.Size = new Size(200, this.Height - 300);
            }

            lDeleteDate.Top = 160;
            lDeleteDate.Left = 15;
             
            beAdd.Top = 120;
            beAdd.Left = 20;

            tbNewMeaning.Top = 80;
            tbNewMeaning.Left = 150;
            if (tbNewMeaning.Width != 0)
            {
                tbNewMeaning.Size = new Size(this.Width - 240, 0);
            }

            lMinus.Top = 70;
            lMinus.Left = 125;

            tbNewDate.Top = 80;
            tbNewDate.Left = 20;

            beGoToMenu.Top = 10;
            if(beGoToMenu.Width != 0)
            {
                beGoToMenu.Left = this.Width - 150;
            }

            lAddNewDate.Top = 30;
            lAddNewDate.Left = 15;
        }

        private void BeDelete_Click(object sender, EventArgs e)
        {
            string deletedDate = (string)lbDates.SelectedItem;
            if(deletedDate != null)
            {
                string path = "Dates.txt";
                string pathTemp = "TempDates.txt";
                string[] readText = File.ReadAllLines(path);
                using (File.Create(pathTemp)) { }
                using (StreamReader reader = new StreamReader(path))
                {
                    using (StreamWriter writer = new StreamWriter(pathTemp))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Substring(0, 4) == deletedDate)
                                continue;
                            writer.WriteLine(line);
                        }
                    }
                }
                File.Delete(path);
                using (File.Create(path)) { }
                using (StreamReader reader = new StreamReader(pathTemp))
                {
                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                            writer.WriteLine(line);
                    }
                }
                File.Delete(pathTemp);
                DeleteAllFromEdit();
                InitializeEdit();
            }
        }

        private void BeAdd_Click(object sender, EventArgs e)
        {
            try
            {
                while (tbNewDate.Text[tbNewDate.Text.Length - 1] == ' ')
                {
                    tbNewDate.Text = tbNewDate.Text.Remove(tbNewDate.Text.Length - 1);
                }
                while (tbNewDate.Text[0] == ' ')
                {
                    tbNewDate.Text = tbNewDate.Text.Substring(1);
                }
                while (tbNewMeaning.Text[tbNewMeaning.Text.Length - 1] == ' ')
                {
                    tbNewMeaning.Text = tbNewMeaning.Text.Remove(tbNewMeaning.Text.Length - 1);
                }
                while (tbNewMeaning.Text[0] == ' ')
                {
                    tbNewMeaning.Text = tbNewMeaning.Text.Substring(1);
                }
            }
            catch { }
            if (tbNewDate.Text == "")
            {
                MessageBox.Show("Введите пожалуйста дату!");
            }
            else
            {
                if (tbNewMeaning.Text == "")
                {
                    MessageBox.Show("You forgot to write meaning!");
                }
                else
                {
                    if (tbNewDate.Text.Length <= 4)
                    {
                        if ((int.Parse(tbNewDate.Text) >= 1300) && (int.Parse(tbNewDate.Text) <= 2017))
                        {
                            string line = tbNewDate.Text + " - " + tbNewMeaning.Text;
                            try
                            {
                                File.AppendAllText(@"Dates.txt", line + Environment.NewLine);
                                MessageBox.Show("Date was successful added!");
                                DeleteAllFromEdit();
                                InitializeEdit();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error! " + ex.ToString());
                            }
                        }
                        else
                        {
                            MessageBox.Show("The date must be between 1300 and 2017!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The wrong date!");
                    }
                }
            }
        }

        private void BeGoToMenu_Click(object sender, EventArgs e)
        {
            DeleteAllFromEdit();
            InitializeChooze();
        }

        private void DeleteAllFromEdit()
        {
            beGoToMenu.Size = new Size(0, 0);
            lAddNewDate.Size = new Size(0, 0);
            beAdd.Size = new Size(0, 0);
            lMinus.Size = new Size(0, 0);
            tbNewDate.Size = new Size(0, 0);
            lbDates.Size = new Size(0, 0);
            tbNewMeaning.Size = new Size(0, 0);
            beDelete.Size = new Size(0, 0);
            lDeleteDate.Size = new Size(0, 0);
        }
    }
}
