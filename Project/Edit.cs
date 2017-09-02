using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Project
{
    partial class MyForm
    {
        Button beGoToMenu, beAdd;
        Label lAddNewDate, lMinus;
        TextBox tbNewDate, tbNewMeaning;

        private void InitializeEdit()
        {
            this.MaximumSize = this.MinimumSize = new Size(800, 500);
            this.Size = this.MinimumSize;

            beAdd = new Button();
            beAdd.Parent = this;
            beAdd.Text = "Add";
            beAdd.Size = new Size(60, 25);
            beAdd.Font = new Font("Arial", 10, FontStyle.Bold);
            beAdd.Top = 120;
            beAdd.Left = 20;
            beAdd.FlatStyle = FlatStyle.Flat;
            beAdd.FlatAppearance.BorderColor = Color.Black;
            beAdd.FlatAppearance.BorderSize = 1;
            beAdd.Click += BeAdd_Click;

            tbNewMeaning = new TextBox();
            tbNewMeaning.Parent = this;
            tbNewMeaning.Width = 550;
            tbNewMeaning.Height = 0;
            tbNewMeaning.Top = 80;
            tbNewMeaning.Left = 150;

            lMinus = new Label();
            lMinus.Parent = this;
            lMinus.Text = "-";
            lMinus.Size = new Size(700, 100);
            lMinus.Font = new Font("Arial", 20, FontStyle.Bold);
            lMinus.Top = 70;
            lMinus.Left = 125;

            tbNewDate = new TextBox();
            tbNewDate.Parent = this;
            tbNewDate.Width = 100;
            tbNewDate.Height = 0;
            tbNewDate.Top = 80;
            tbNewDate.Left = 20;

            beGoToMenu = new Button();
            beGoToMenu.Parent = this;
            beGoToMenu.Text = "MENU";
            beGoToMenu.Size = new Size(120, 40);
            beGoToMenu.Font = new Font("Arial", 20, FontStyle.Bold);
            beGoToMenu.Top = 10;
            beGoToMenu.Left = 650;
            beGoToMenu.FlatStyle = FlatStyle.Flat;
            beGoToMenu.FlatAppearance.BorderColor = Color.Black;
            beGoToMenu.FlatAppearance.BorderSize = 1;
            beGoToMenu.Click += BeGoToMenu_Click;

            lAddNewDate = new Label();
            lAddNewDate.Parent = this;
            lAddNewDate.Text = "Add new date:";
            lAddNewDate.Size = new Size(700, 100);
            lAddNewDate.Font = new Font("Arial", 20, FontStyle.Bold);
            lAddNewDate.Top = 30;
            lAddNewDate.Left = 20;
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
                MessageBox.Show("You forgot to write date!");
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
            beGoToMenu.Size = new Size(0, 0);
            lAddNewDate.Size = new Size(0, 0);
            beAdd.Size = new Size(0, 0);
            lMinus.Size = new Size(0, 0);
            tbNewDate.Size = new Size(0, 0);
            tbNewMeaning.Size = new Size(0, 0);
            InitializeChooze();
        }
    }
}
