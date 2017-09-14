using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Project
{
    partial class MyForm : Form
    {
        Label lMenuText1, lMenuText2;
        Button bPlay, bEdit;

        public MyForm()
        {
            InitializeChooze();
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
            DeleteAllFromChooze();
            InitializeEdit();
        }

        private void BPlay_Click(object sender, EventArgs e)
        {
            DeleteAllFromChooze();
            InitializeGame();
        }

        private void DeleteAllFromChooze()
        {
            lMenuText1.Size = new Size(0, 0);
            lMenuText2.Size = new Size(0, 0);
            bPlay.Size = new Size(0, 0);
            bEdit.Size = new Size(0, 0);
        }
    }
}
