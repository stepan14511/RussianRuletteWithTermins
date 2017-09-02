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
        RadioButton rbAdd1, rbAdd2, rbAdd3, rbAdd4;

        private void InitializeEdit()
        {
            this.MaximumSize = this.MinimumSize = new Size(800, 500);
            this.Size = this.MinimumSize;

            beAdd = new Button();
            beAdd.Parent = this;
            beAdd.Text = "Add";
            beAdd.Size = new Size(60, 25);
            beAdd.Font = new Font("Arial", 10, FontStyle.Bold);
            beAdd.Top = 200;
            beAdd.Left = 20;
            //beAdd.FlatStyle = FlatStyle.Flat;
            //beAdd.FlatAppearance.BorderColor = Color.Black;
            //beAdd.FlatAppearance.BorderSize = 1;
            beAdd.Click += BeAdd_Click;

            rbAdd1 = new RadioButton();
            rbAdd1.Parent = this;
            rbAdd1.Text = "1 Group";
            rbAdd1.Left = 20;
            rbAdd1.Top = 110;

            rbAdd2 = new RadioButton();
            rbAdd2.Parent = this;
            rbAdd2.Text = "2 Group";
            rbAdd2.Left = 20;
            rbAdd2.Top = 130;

            rbAdd3 = new RadioButton();
            rbAdd3.Parent = this;
            rbAdd3.Text = "3 Group";
            rbAdd3.Left = 20;
            rbAdd3.Top = 150;

            rbAdd4 = new RadioButton();
            rbAdd4.Parent = this;
            rbAdd4.Text = "4 Group";
            rbAdd4.Left = 20;
            rbAdd4.Top = 170;

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
                while (tbNewMeaning.Text[0] == ' ')
                {
                    tbNewMeaning.Text = tbNewMeaning.Text.Substring(1);
                }
            }
            catch { }
            if (tbNewDate.Text == "")
            {
                MessageBox.Show("Write please date!");
            }
            else
            {
                if (tbNewMeaning.Text == "")
                {
                    MessageBox.Show("Write please meaning!");
                }
                else
                {
                    if (rbAdd1.Checked == true)
                    {
                        MessageBox.Show(AddDateToFile(1, tbNewDate.Text, tbNewMeaning.Text) ? "Date added succesfuly" : "Error!!! Please restart program and try again.");
                        tbNewDate.Text = "";
                        tbNewMeaning.Text = "";
                    }
                    else
                    {
                        if (rbAdd2.Checked == true)
                        {
                            MessageBox.Show(AddDateToFile(2, tbNewDate.Text, tbNewMeaning.Text) ? "Date added succesfuly" : "Error!!! Please restart program and try again.");
                            tbNewDate.Text = "";
                            tbNewMeaning.Text = "";
                        }
                        else
                        {
                            if (rbAdd3.Checked == true)
                            {
                                MessageBox.Show(AddDateToFile(3, tbNewDate.Text, tbNewMeaning.Text) ? "Date added succesfuly" : "Error!!! Please restart program and try again.");
                                tbNewDate.Text = "";
                                tbNewMeaning.Text = "";
                            }
                            else
                            {
                                if (rbAdd4.Checked == true)
                                {
                                    MessageBox.Show(AddDateToFile(4, tbNewDate.Text, tbNewMeaning.Text) ? "Date added succesfuly" : "Error!!! Please restart program and try again.");
                                    tbNewDate.Text = "";
                                    tbNewMeaning.Text = "";
                                }
                                else
                                {
                                    MessageBox.Show("Chooze group please!");
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool AddDateToFile(int numberOfFile, string date, string meaning)
        {
            string line = date + " - " + meaning;
            try
            {
                if (numberOfFile == 1)
                {
                    File.AppendAllText(@"Dates1.txt", line + Environment.NewLine);
                }
                else
                {
                    if (numberOfFile == 2)
                    {
                        File.AppendAllText(@"Dates2.txt", line + Environment.NewLine);
                    }
                    else
                    {
                        if (numberOfFile == 3)
                        {
                            File.AppendAllText(@"Dates3.txt", line + Environment.NewLine);
                        }
                        else
                        {
                            File.AppendAllText(@"Dates4.txt", line + Environment.NewLine);
                        }
                    }
                }
            }
            catch { return false; }
            return true;
        }

        private void BeGoToMenu_Click(object sender, EventArgs e)
        {
            beGoToMenu.Size = new Size(0, 0);
            lAddNewDate.Size = new Size(0, 0);
            rbAdd1.Size = new Size(0, 0);
            rbAdd2.Size = new Size(0, 0);
            rbAdd3.Size = new Size(0, 0);
            rbAdd4.Size = new Size(0, 0);
            beAdd.Size = new Size(0, 0);
            lMinus.Size = new Size(0, 0);
            tbNewDate.Size = new Size(0, 0);
            tbNewMeaning.Size = new Size(0, 0);
            InitializeChooze();
        }
    }
}
