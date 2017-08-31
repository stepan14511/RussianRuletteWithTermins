using System;
using System.Windows.Forms;

namespace ProgramForFriend
{
    class Program
    {
        static void Main()
        {
            MyForm form = new MyForm();
            form.Show();
            Application.Run(form);
        }
    }
}
