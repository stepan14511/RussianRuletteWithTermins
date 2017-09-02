using System;
using System.Windows.Forms;

namespace Project
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
