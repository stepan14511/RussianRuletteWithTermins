using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Project
{
    partial class MyForm : Form
    {
        Label lMenuText;
        Button bPlay, bEdit;

        public MyForm()
        {
            InitializeChooze();
        }


        private void InitializeChooze()
        {
            this.MinimumSize = new Size(600, 400);
            this.Size = this.MinimumSize;
            this.Text = "Русская рулетка";

            bPlay = new Button();
            bPlay.Parent = this;
            bPlay.Text = "ИГРАТЬ";
            bPlay.Size = new Size(235, 150);
            bPlay.Font = new Font("Arial", 25, FontStyle.Bold);
            bPlay.FlatStyle = FlatStyle.Flat;
            bPlay.FlatAppearance.BorderColor = Color.Black;
            bPlay.FlatAppearance.BorderSize = 1;
            bPlay.Click += BPlay_Click;

            bEdit = new Button();
            bEdit.Parent = this;
            bEdit.Text = "НАСТРОЙКИ";
            bEdit.Size = new Size(235, 150);
            bEdit.Font = new Font("Arial", 25, FontStyle.Bold);
            bEdit.FlatStyle = FlatStyle.Flat;
            bEdit.FlatAppearance.BorderColor = Color.Black;
            bEdit.FlatAppearance.BorderSize = 1;
            bEdit.Click += BEdit_Click;

            lMenuText = new Label();
            lMenuText.Parent = this;
            lMenuText.Font = new Font("Arial", 25, FontStyle.Bold);
            lMenuText.Text = "Русская рулетка \"Даты\"";
            lMenuText.Size = new Size(500, 50);
            
            Resize += MyForm_Resize;

            ReplaceAllBlocksChooze();
        }

        private void MyForm_Resize(object sender, EventArgs e)
        {
            ReplaceAllBlocksChooze();
        }

        private void ReplaceAllBlocksChooze()
        {
            bPlay.Top = (this.Height / 2) - 20;
            bPlay.Left = (this.Width / 2) - 260;

            bEdit.Top = (this.Height / 2) - 20;
            bEdit.Left = (this.Width / 2);

            lMenuText.Left = (this.Width / 2) - 215;
            lMenuText.Top = (this.Height / 2) - 150;
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
            lMenuText.Size = new Size(0, 0);
            bPlay.Size = new Size(0, 0);
            bEdit.Size = new Size(0, 0);
        }
    }
}
