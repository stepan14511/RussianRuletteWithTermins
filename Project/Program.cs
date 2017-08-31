using System;
using System.IO;
using System.Windows.Forms;

namespace ProgramForFriend
{
    class Program
    {
        static void Main()
        {
            string path = "Dates.txt";
            string[] readText = File.ReadAllLines(path);
            int numberOfDates = 0;
            foreach (string s in readText)
            {
                numberOfDates++;
            }
            string[] tempNumber = new string[numberOfDates];
            string[] tempOpred = new string[numberOfDates];
            int j = 0;
            foreach (var str in readText)
            {
                int i = 0;
                tempNumber[j] = "";
                while((str[i] != ' ') && (str[i + 1] != '-'))
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
            MyForm form = new MyForm(numberOfDates, tempNumber, tempOpred);
            form.Show();
            Application.Run(form);
        }
    }
}
